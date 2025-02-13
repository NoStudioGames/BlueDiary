using UnityEngine;

public class CutsceneCamera : MonoBehaviour
{
    public CameraController cam;
    public GameObject cameraObj;
    public GameObject target;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float followspeed;

    public float followSpeedRef;
    public GameObject targetRef;
    public GameObject[] targets;
    public int targetIndex;
    public SmoothTranslator[] translator;
    public bool isEnabled;

    void Start()
    {
        cameraObj = this.gameObject;
        isEnabled = false;
        targetIndex = 0;
        target = targets[targetIndex];
        DirectPoint();
    }

    void Update()
    {
        if (isEnabled)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (targetIndex + 1 >= targets.Length)
                {
                    targetIndex = 0;
                    isEnabled = false;
                }
                else
                {
                    targetIndex = targetIndex + 1;
                }
                target = targets[targetIndex];
            }
            DirectPoint();
        }
        for (int i = 0; i < translator.Length; i++)
        {
            if (!translator[i].canActivate)
            {
                translator[i].active = isEnabled;
            }   
        }
        cam.enabled = !isEnabled;
        cam.target.GetComponent<PlayerMovement>().enabled = !isEnabled;
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
    public void DirectPoint()
    {
        Vector3 pos = new Vector3(); 
        pos.Set(target.transform.position.x, target.transform.position.y, transform.position.z);
        cameraObj.transform.position = Vector3.Lerp(transform.position, pos, followspeed * Time.deltaTime);
    }
}
