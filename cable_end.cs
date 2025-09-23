using UnityEngine;

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

public class cable_end : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool Movable;
    public bool Connected; // for checking if it's connected by other things? Needed?

    /*
    Location x
    Location y
    Port
    Device
    CableID
    */

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Movable = true;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
