using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Item : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    void Update()
    {
        
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
