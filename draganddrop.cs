using UnityEngine;
using UnityEngine.InputSystem;  // new input system namespace (optional if set to "Both")

// Put this component on your enemy prefabs / objects
// adds and removes 

/*
public class EnemyController : MonoBehaviour
{
    // every instance registers to and removes itself from here
    private static readonly HashSet<EnemyController> _instances = new HashSet<EnemyController>();

    // Readonly property, I would return a new HashSet so nobody on the outside can alter the content
    public static HashSet<EnemyController> Instances => new HashSet<EnemyController>(_instances);

    // If possible already drag the Rigidbody into this slot via the Inspector!
    [SerializedField] private Rigidbody2D rb;

    // public read-only access
    public Rigidbody2D Rb => rb;

    private void Awake()
    {
        if (!rb) rb = GetComponent<Rigidbody2D>();
        _instances.Add(this);
    }

    private void OnDestroy()
    {
        _instances.Remove(this);
    }
}
*/

public class DragAndDrop : MonoBehaviour
{
    private Vector3 offset;
    private BoxCollider2D m_Collider, this_Collider;

    void OnMouseDown()
    {
        //Debug.Log("OnMouseDown called on " + gameObject.name);
        offset = transform.position - MouseWorldPosition();
    }

    void OnMouseDrag()
    {
        //Debug.Log("OnMouseDrag called on " + gameObject.name);
        transform.position = MouseWorldPosition() + offset;
    }


void OnMouseUp()
{

    // don't actually do this here.
    var objects = GameObject.FindGameObjectsWithTag("port");        
    this_Collider = GetComponent<BoxCollider2D>();

    foreach (var obj in objects)
    {
        //Debug.Log("Collision called on " + obj.name);
        var m_Collider = obj.GetComponent<BoxCollider2D>();

        if (m_Collider == null)
            Debug.Log("!! Port " + obj.name + " has no collider!");

        // check to see if the object underneith has collided
        if (this_Collider.bounds.Intersects(m_Collider.bounds))
        {
            Debug.Log("Collision called on " + obj.name);
        }
    }
}

/*
    void OnMouseUp()
    {
        var thisCollider = GetComponent<BoxCollider2D>();
        Debug.Log("Touching port - origin" + thisCollider);

        //if (thisCollider == null)
        //    return;

        // Debug.Log("Touching port?");

        var objects = GameObject.FindGameObjectsWithTag("port");

        //Debug.Log("Touching port?" + objects.Length);

        foreach (var obj in objects)
        {
            var otherCollider = obj.GetComponent<BoxCollider2D>();
            Debug.Log("Touching other port: " + otherCollider);
            //if (otherCollider == null)
            //    continue;

            if (thisCollider.bounds.Intersects(otherCollider.bounds))
            {
                Debug.Log("-----Touching port: " + otherCollider);
            }
        }
    }
*/

    void Update()
    {
        // Check for left mouse release
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            var thisCollider = GetComponent<BoxCollider2D>();
            Debug.Log("Touching port - origin " + thisCollider);

            var objects = GameObject.FindGameObjectsWithTag("port");
            foreach (var obj in objects)
            {
                var otherCollider = obj.GetComponent<BoxCollider2D>();
                Debug.Log("Touching other port: " + otherCollider);

                if (thisCollider.bounds.Intersects(otherCollider.bounds))
                {
                    Debug.Log("-----Touching port: " + otherCollider);
                }
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("port"))
        {
            Debug.Log("Trigger entered: " + other.name);
        }
    }

    private Vector3 MouseWorldPosition()
    {
        // If using new Input System only:
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();

        // If set to "Both", you could use Input.mousePosition instead.
        // var mouseScreenPos = Input.mousePosition;

        float z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, z));
    }
}


/*
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Collider2D))]
public class DragAndDropNewInput : MonoBehaviour
{
    Vector3 offset;
    bool dragging = false;

    void Update()
    {
        var mouse = Mouse.current;
        if (mouse == null) return; // new input system not available

        // Start drag: left button pressed this frame + raycast hit this object
        if (mouse.leftButton.wasPressedThisFrame)
        {
            var ray = Camera.main.ScreenPointToRay(mouse.position.ReadValue());
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                dragging = true;
                offset = transform.position - MouseWorldPosition(mouse);
                Debug.Log("▶ Started dragging: " + gameObject.name);
            }
        }

        // During drag
        if (mouse.leftButton.isPressed && dragging)
        {
            transform.position = MouseWorldPosition(mouse) + offset;
        }

        // On release
        if (mouse.leftButton.wasReleasedThisFrame && dragging)
        {
            dragging = false;
            Debug.Log("⏹ Released: " + gameObject.name);
            CheckPortsOnRelease();
        }
    }

    Vector3 MouseWorldPosition(Mouse mouse)
    {
        Vector2 ms = mouse.position.ReadValue();
        float z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(new Vector3(ms.x, ms.y, z));
    }

    void CheckPortsOnRelease()
{
    var thisCollider = GetComponent<Collider2D>();
    if (thisCollider == null)
    {
        Debug.LogWarning("No Collider2D on " + gameObject.name);
        return;
    }

    Debug.Log($"ThisCollider bounds center={thisCollider.bounds.center} size={thisCollider.bounds.size}");

    var ports = GameObject.FindGameObjectsWithTag("port");
    Debug.Log("Checking " + ports.Length + " ports on release.");

    foreach (var p in ports)
    {
        var other = p.GetComponent<Collider2D>();
        if (other == null) continue;

        Debug.Log($"Port {p.name} bounds center={other.bounds.center} size={other.bounds.size}");

        if (thisCollider.bounds.Intersects(other.bounds))
        {
            Debug.Log("✅ Overlapping port: " + p.name);
        }
        else
        {
            Debug.Log("❌ Not overlapping port: " + p.name);
        }
    }
}

}
*/
