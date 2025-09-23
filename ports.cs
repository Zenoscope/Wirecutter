using System.Runtime.CompilerServices;
using Mono.Cecil.Cil;
using UnityEngine;

public class ports : MonoBehaviour
{

    // if movable is true then the parent can be moved.
    public bool Connected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Connected = false;
    }

    // Update is called once per frame
    void Update()
    {
        // sets the parent to movable.        
        if (Connected && transform.parent != null)
        {
            // get the device from the gameObject
            Debug.Log($"Found parent: {transform.parent.name}");
            
            var parentDevice = transform.parent.gameObject.GetComponent<device>();

            if (parentDevice != null)
            {
                parentDevice.Movable = false;
            }
            else
            {
                Debug.LogWarning($"Parent of {transform.parent.name} has no 'device' component!");
            }
        }

    }
    
}
