using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class CameraController : MonoBehaviour
{
    public GameObject target;
    public GameObject cameraObj;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float followspeed;

    public float followSpeedRef;
    public GameObject targetRef;

    void Start()
    {
        cameraObj = this.gameObject;
    }

    void Update()
    {

        if (Mathf.Abs(cameraObj.transform.position.x - target.transform.position.x) >= maxX)
        {
            Vector3 pos = new Vector3();
            pos.Set(target.transform.position.x, transform.position.y, transform.position.z);
            cameraObj.transform.position = Vector3.Lerp(transform.position, pos, followspeed * Time.deltaTime);
        }
        if (Mathf.Abs(cameraObj.transform.position.y - target.transform.position.y) >= maxY)
        {
            Vector3 pos = new Vector3();
            pos.Set(transform.position.x, target.transform.position.y - minY, transform.position.z);
            cameraObj.transform.position = Vector3.Lerp(transform.position, pos, followspeed * Time.deltaTime);
        }
    }

    public void GoPoint()
    {
        if (Mathf.Abs(cameraObj.transform.position.x - target.transform.position.x) >= maxX)
        {
            Vector3 pos = new Vector3();
            pos.Set(target.transform.position.x, transform.position.y, transform.position.z);
            cameraObj.transform.position = Vector3.Lerp(transform.position, pos, followspeed * Time.deltaTime);
        }
        if (Mathf.Abs(cameraObj.transform.position.y - target.transform.position.y) >= maxY)
        {
            Vector3 pos = new Vector3();
            pos.Set(transform.position.x, target.transform.position.y - minY, transform.position.z);
            cameraObj.transform.position = Vector3.Lerp(transform.position, pos, followspeed * Time.deltaTime);
        }
    }
}
