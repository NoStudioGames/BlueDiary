using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target; // The object to follow
    public float smoothSpeed = 5f; // Speed for smooth movement
    public bool useSmoothFollow = true; // Toggle between teleport and smooth follow

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            FollowTarget();
        }
        else
        {
            HandleTargetLost();
        }
    }

    void FollowTarget()
    {
        if (useSmoothFollow)
        {
            // Smoothly move towards the target
            transform.position = Vector3.Lerp(transform.position, target.position, smoothSpeed * Time.deltaTime);
        }
        else
        {
            // Instantly teleport to the target
            transform.position = target.position;
        }
    }

    void HandleTargetLost()
    {
        // Logic to handle when the target is null
        // For example, stop movement or reset the camera to a default position
        Debug.LogWarning("Target is null. Camera has stopped following.");
        // Optionally reset the camera position:
        // transform.position = Vector3.zero;
    }

    public void SetTarget(Transform newTarget, bool smoothFollow)
    {
        target = newTarget;
        useSmoothFollow = smoothFollow;
    }
}
