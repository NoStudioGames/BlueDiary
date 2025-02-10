using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private float originalScale = 5.5f;
    private float zoom;
    private float zoomMultiplier = 4f;
    private float minZoom = 1.5f;
    private float maxZoom = 8f;
    private float velocity = 0f;
    private float smoothTime = 0.25f;

    [SerializeField] private Camera cam;



    void Start()
    {
        zoom = cam.orthographicSize;
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        zoom -= scroll * zoomMultiplier;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Zoom(originalScale);
        }
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
}
