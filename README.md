# Cryostat Control
This project consists of software to control a cryostat. The software is written in C# and is divided in two components, a server and a client.
The server contains all the logic of the system. The client is the GUI that controls and reads out the server.
Both server and client run on Windows.

CryostatControlClient
---
This project represents the GUI client as can be seen below. It is build as MVVM in WPF. It connects to the server automaticly with WCF.
![Overview Tab](https://github.com/BBekker/CryostatControl/blob/dev/documents/Screenshots/OverviewTab.png)


CryostatControlServer
---
This project represents the server that comunicates with the cryostat devices and sends this data to connected clients.
The server is also accessible with Phyton scripts.

Running the program
----
Running the program is as easy as just starting up the server and a client. The server should run on the PC which is connected to the cryostat components in order to retrieve data or execute actions from the client.
