using UnityEngine;

public class ItemInspect : MonoBehaviour
{
    public Camera myCam;
    private Vector3 sceenPos;
    private float angleOffset;
    private Collider2D col;

    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        Vector3 mousePos = myCam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if(col == Physics2D.OverlapPoint(mousePos))
            {
                sceenPos = myCam.WorldToScreenPoint(transform.position);
                Vector3 vec3 = Input.mousePosition - sceenPos;
                angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x) -  Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;
            }
        }
        if (Input.GetMouseButton(0))
        {
            if(col == Physics2D.OverlapPoint(mousePos))
            {
                Vector3 vec3 = Input.mousePosition - sceenPos;
                float angle = Mathf.Atan2(vec3.x, vec3.y) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, 0, angle + angleOffset);
            }
        }
    }
}
