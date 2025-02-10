using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SmoothTranslator : MonoBehaviour
{
    [SerializeField]private float FollowSpeed;
    private Vector3 defPoint;
    private Vector3 activePoint;
    public float activeDiff;
    public bool active;
    public bool canActivate;
    private void Start()
    {
        defPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        activePoint = new Vector3(transform.position.x, transform.position.y+activeDiff, transform.position.z);
    }
    void Update()
    {
        if (canActivate)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                active = !active;
            }
        }
        if (active)
        {
            ActivatePos();
        }
        else
        {
            DeactivatePos();
        }
    }

    public void ActivatePos()
    {
        transform.position = Vector3.Slerp(transform.position, activePoint, FollowSpeed * Time.deltaTime);
    }
    public void DeactivatePos()
    {
        transform.position = Vector3.Slerp(transform.position, defPoint, FollowSpeed * Time.deltaTime);
    }
}
