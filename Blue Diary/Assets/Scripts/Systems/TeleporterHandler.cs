using UnityEngine;
using System.Collections;
using Collections.Shaders.CircleTransition;

public class TeleporterHandler : MonoBehaviour
{
    public GameObject teleportTarget;
    public Directions teleportDirection;

    public bool teleportedCountDown = false;
    public bool isActive = true;
    public bool isTeleporting = false;

    private CircleTransition circleTransition; // CircleTransition referansı

    [System.Obsolete]
    void Start()
    {
        Debug.Log("Working");
        // Initialize the teleporter if needed
        if (teleportTarget == null)
        {
            Debug.LogError("Teleport target not set for " + gameObject.name);
        }
        else
        {
            teleportDirection = teleportTarget.GetComponent<TeleporterHandler>().teleportDirection;
        }

        // Scene içinde CircleTransition objesini bul
        circleTransition = FindObjectOfType<CircleTransition>();
        if (circleTransition == null)
        {
            Debug.LogError("CircleTransition component not found in the scene!");
        }
    }

    private IEnumerator TeleportWithDelay(GameObject player)
    {
        if (teleportTarget != null && !teleportedCountDown)
        {
            if (circleTransition != null)
            {
                circleTransition.CloseBlackScreen(); // Daire efekti başlat
            }

            yield return new WaitForSeconds(0.4f); // 1 saniye gecikme
            player.GetComponent<PlayerMovement>().canMove = false; // Oyuncunun hareketini durdur
            player.GetComponent<PlayerMovement>().StopCharacter();
            yield return new WaitForSeconds(0.6f); // 1 saniye gecikme


            Vector3 targetPosition = teleportTarget.transform.position;
            targetPosition += teleportTarget.transform.up * 0.5f; // Move slightly inside the teleport target
            player.transform.position = targetPosition;
            teleportTarget.GetComponent<TeleporterHandler>().teleportedCountDown = true;
        }

        yield return new WaitForSeconds(0.5f); // Küçük bir gecikme ekleyerek efektin daha net görünmesini sağlıyoruz

        if (circleTransition != null)
        {
            circleTransition.OpenBlackScreen(); // Daire efektini kapat
        }
        player.GetComponent<PlayerMovement>().canMove = true; // Oyuncunun hareketini tekrar başlat
        player.GetComponent<PlayerMovement>().ResumeCharacter();
        isTeleporting = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isActive && !isTeleporting)
        {
            isTeleporting = true;
            Debug.Log("INSIDE");
            StartCoroutine(TeleportWithDelay(collision.gameObject));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTeleporting = false;
            Debug.Log("OUTSIDE");
            teleportedCountDown = false;
        }
    }
}