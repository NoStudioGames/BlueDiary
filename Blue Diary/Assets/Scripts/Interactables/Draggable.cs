using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool dragging = false;
    private Vector3 offset;

    private float posX;


    void Update()
    {
        posX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        if (dragging)
        {
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y, transform.position.z);
        }
    }

    private void OnMouseDown()
    {
        dragging = true;
    }

    private void OnMouseUp()
    {
        dragging = false;
    }
}
