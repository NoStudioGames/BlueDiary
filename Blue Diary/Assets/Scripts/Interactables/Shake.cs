using UnityEngine;
using System.Collections;

public class Shake : MonoBehaviour
{

    // Duration of the shake effect
    public float shakeDuration = 0.5f;

    // Intensity of the shake effect
    public float shakeMagnitude = 0.2f;

    // How quickly the shake effect should diminish
    public float dampingSpeed = 1.5f;

    // Original position of the camera
    private Vector3 initialPosition;
    public float initialShakeMagnitude;
    public bool hasEnabled;

    private void Start()
    {
        initialPosition = transform.localPosition;
        initialShakeMagnitude = shakeMagnitude;
    }

    void Update()
    {
        
    }


    public void TriggerShake()
    {
        if (!hasEnabled)
        {
            initialPosition = transform.position;
            hasEnabled = true;
            StartCoroutine(ShakeCoroutine());
        }
    }

    private IEnumerator ShakeCoroutine()
    {
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-0.1f, 0.1f) * shakeMagnitude;
            float y = Random.Range(-0.1f, 0.1f) * shakeMagnitude;

            transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z);

            elapsed += Time.deltaTime;

            // Gradually reduce the shake effect
            shakeMagnitude = Mathf.Lerp(shakeMagnitude, 0f, Time.deltaTime * dampingSpeed);

            yield return null;
        }

        // Reset the camera to its original position
        shakeMagnitude = initialShakeMagnitude;
        transform.position = initialPosition;
        hasEnabled = false;
    }
}
