using UnityEngine;

public class CameraZoomManager : MonoBehaviour
{

    private float originalScale = 1.5f;
    private float zoom;
    private float zoomMultiplier = 4f;
    private float minZoom = 1.5f;
    private float maxZoom = 12.5f;
    private float velocity = 0f;
    private float smoothTime = 3f;
    private Vector3 positionVelocity;
    [SerializeField] private Camera cam;

    public GameObject starting;
    public GameObject ending;
    private Vector3 targetPosition;

    void Start()
    {
        zoom = cam.orthographicSize;
        targetPosition = transform.position;
    }

    void Update()
    {
        float scroll = Input.GetAxis("Horizontal");
        zoom += scroll * zoomMultiplier;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        if(scroll > 0){
            cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime);
            SmoothTranslatioon(ending);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Zoom(originalScale);
            SmoothTranslatioon(starting);
        }
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref positionVelocity, smoothTime+0.2f);
    }

    public void Zoom(float newzoom)
    {
        zoom = Mathf.Clamp(newzoom, minZoom, maxZoom);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime);
    }
    public void ResetZoom()
    {
        zoom = originalScale;
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime);
    }
    public void SmoothTranslatioon(GameObject target)
    {
        targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }
}
