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

    void OnMouseDown()
    {
        Debug.Log("OnMouseDown called on " + gameObject.name);
        offset = transform.position - MouseWorldPosition();
    }

    void OnMouseDrag()
    {
        Debug.Log("OnMouseDrag called on " + gameObject.name);
        transform.position = MouseWorldPosition() + offset;
    }

    void OnMouseUp()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided with an enemy!");
            // Perform actions like reducing health, playing sound, etc.
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
