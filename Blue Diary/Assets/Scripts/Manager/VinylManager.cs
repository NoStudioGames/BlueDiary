using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VinylManager : MonoBehaviour
{
    public CameraController camController;
    public CameraZoom camZoom;

    public bool inArea;
    public bool canPlay;
    public bool hasSetup;

    public GameObject targetPoint;

    public GameObject vinylPanel;

    void Start()
    {
        vinylPanel.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && inArea && !hasSetup)
        {
            VinylSetup();
            Debug.Log("InArea");
        }
        if(Input.GetKeyDown(KeyCode.F) && hasSetup)
        {
            VinylExit();
            Debug.Log("shutting down");
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            VinylExit();
            Debug.Log("shutting down esc");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            inArea = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inArea = false;
            VinylExit();
        }
    }

    public void VinylSetup()
    {
        camZoom.Zoom(2);
        camController.target = targetPoint;
        StopAllCoroutines();
        StartCoroutine(SetupTime(1.5f));
        camController.GoPoint();
        vinylPanel.SetActive(true);
    }
    public void VinylExit()
    {
        camZoom.ResetZoom();
        camController.target = camController.targetRef;
        camController.followspeed = camController.followSpeedRef;
        hasSetup = false;
        vinylPanel.SetActive(false);
    }

    IEnumerator SetupTime(float timewait)
    {
        yield return new WaitForSeconds(timewait);
        hasSetup = true;
    }
}
