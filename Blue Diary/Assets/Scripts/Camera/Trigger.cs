using UnityEngine;

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
