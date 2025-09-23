// constructor class for cables.

using System.Runtime.CompilerServices;

// if the cable is CompilerMarshalOverride, check to see what the ennd is over
// tell the switch that the cable has been plugged in.

/* cables have properties:
length
colour
end1
    port_type
    x,y location
    connected
    // in inventory
    (device?)
end2
    port_type
    x,y location
    connected
    // in inventory
    (device?)


Cable length 0.25, 0.5, 1m, 2m, 5m, 10m
Connector/port types:
USB
Video (hdmi etc)

Port types:
USB
RJ45
Power
*/

public var Connected
Location x
Location y
Port
Device
CableID

On mouse release
  
If (switch.port && switch.port_empty)
  Set location to port location
  If (self.end(other end).connected
    Switch.port.active = true

Else
 Go floppy/hover/whatever?
 Switch.port.active = false


Device

Get_device_soft_configuration
Get_device_hard_configuration

Packet

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
