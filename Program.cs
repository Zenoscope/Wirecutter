// Drag and drop - get it working
// Get the name of the object the dragged item is over.
// https://u3ds.blogspot.com/2023/07/drag-drop-2d-world-space-2d-objects-c.html


using UnityEngine;
 
public class DragDrop2D : MonoBehaviour
{
    Vector3 offset;
    Collider2D collider2d;
    public string destinationTag = "DropArea";
 
    void Awake()
    {
        collider2d = GetComponent<Collider2D>();
    }
 
    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
    }
 
    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
    }
 
    void OnMouseUp()
    {
        collider2d.enabled = false;
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
        RaycastHit2D hitInfo;
        if (hitInfo = Physics2D.Raycast(rayOrigin, rayDirection))
        {
            if (hitInfo.transform.tag == destinationTag)
            {
                transform.position = hitInfo.transform.position + new Vector3(0, 0, -0.01f);
            }
        }
        collider2d.enabled = true;
    }
 
    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}
