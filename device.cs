Using System.Globalization;
using System.Runtime.CompilerServices;
using UnityEngine;

//Types: NAS< switch, UPS, gig switch, etc.

public class device : MonoBehaviour
{
    public bool Movable;

    //Get_device_soft_configuration
    //Get_device_hard_configuration



    // number of ports
    //private int NumPorts;

    // if movable, then the device can be moved.
    void Start()
    {
        Movable = true;
        //NumPorts = 6; // this should be an argument in a constructor class

        // loop through the ports and poop them out
        //for (int = 0; int < Num_ports; int++) { 
        //}

    }

    // Update is called once per frame
    void Update()
    {
        // set the movability on the switch if the port is connected.
        Debug.Log("Movable" + Movable);
    }
}

/*
Packets

 If port.active && port_enabled 
   Change_image (enabled)
 Else change_image (disabled)

Send_message(port,vlan)
   If port.active && port_enabled && vlan
     Out.packet = packet

Receive_message(port,vlan)
  If port.active && port_enabled && vlan
   Packet = in.packet

Routing tables
Packets have destination ip, vlan, (message)
*/

