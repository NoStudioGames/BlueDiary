using UnityEngine;

public class Item : MonoBehaviour
{
    public float speed;
    Vector3 starPos;
    Vector3 endPos;
    public bool inStartPos;
    void Start()
    {
        starPos = new Vector3(transform.position.x, transform.position.y-1, transform.position.z);
        endPos = new Vector3(transform.position.x, transform.position.y+1, transform.position.z);
        transform.position = starPos;
    }

    void Update()
    {
        if(inStartPos)
        {
            transform.position = Vector3.Slerp(transform.position, endPos, speed * Time.deltaTime);
        }
        if (!inStartPos)
        {
            transform.position = Vector3.Slerp(transform.position, starPos, speed * Time.deltaTime);
        }
        if(transform.position == starPos)
        {
            inStartPos = true;
            Debug.Log("Start");
        }
        if (transform.position == endPos)
        {
            inStartPos = false;
            Debug.Log("End");
        }
    }
    public void IdleDrop()
    {
        Vector3 starPos = new Vector3(transform.position.x, transform.position.y-2, transform.position.z);
        Vector3 endPos = new Vector3(transform.position.x, transform.position.y+2, transform.position.z);
        if(transform.position == starPos)
        {
            transform.position = Vector3.Slerp(transform.position, endPos, speed * Time.deltaTime);
        }
        if (transform.position == endPos)
        {
            transform.position = Vector3.Slerp(transform.position, starPos, speed * Time.deltaTime);
        }
    }
}
