using UnityEditor.Rendering.LookDev;
using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour
{
    public CameraShake cameraShake;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cameraShake.TriggerShake();
        }
    }
}
