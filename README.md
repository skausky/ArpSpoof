# ArpSpoof
Address Resolution Protocol (ARP) spoofing, also known as ARP poisoning, is a network attack technique in which an attacker sends falsified ARP messages over a local network. This allows the attacker to associate their MAC address with the IP address of another device (typically a target device or gateway), intercepting or manipulating network traffic. Here’s a breakdown of how ARP spoofing works:

ARP Basics: ARP is used in local networks to map IP addresses to MAC addresses. When a device wants to communicate with another, it sends an ARP request to obtain the MAC address associated with the IP.

Spoofing the ARP Table: In ARP spoofing, the attacker sends crafted ARP responses to the network, falsely linking their MAC address to the IP address of a target device. The target device updates its ARP table, associating the attacker’s MAC address with the intended IP.

Traffic Interception: Once the target device has an incorrect MAC-IP association, traffic meant for the legitimate IP is sent to the attacker. The attacker can then choose to:

Passively eavesdrop on the traffic for data capture.
Modify the traffic before forwarding it (man-in-the-middle attack).
Disrupt communication by dropping packets.
Detection and Mitigation: Network monitoring tools can detect ARP spoofing by identifying inconsistent ARP mappings. Mitigations include using static ARP entries, enabling network segmentation, and employing secure network protocols.

This project demonstrates ARP spoofing by automating the attack and providing a GUI to observe and log changes in the network state.

![image](https://github.com/user-attachments/assets/a84401a4-c1f3-4643-b2f3-59755decdd6f)
