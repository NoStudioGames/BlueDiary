using UnityEngine;
using System.Collections;

public class TeleporterHandler : MonoBehaviour
{
    public GameObject teleportTarget;
    public Directions teleportDirection;
    
    public bool teleportedCountDown = false;
    public bool isActive = true;


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

    }

    private IEnumerator TeleportWithDelay(GameObject player)
    {

        if (teleportTarget != null && !teleportedCountDown)
        {

            yield return new WaitForSeconds(0.4f); // 1 saniye gecikme
            player.GetComponent<PlayerMovement>().canMove = false; // Oyuncunun hareketini durdur
            yield return new WaitForSeconds(0.6f); // 1 saniye gecikme


            Vector3 targetPosition = teleportTarget.transform.position;
            targetPosition += teleportTarget.transform.up * 0.5f; // Move slightly inside the teleport target
            player.transform.position = targetPosition;
            teleportTarget.GetComponent<TeleporterHandler>().teleportedCountDown = true;
        }

        yield return new WaitForSeconds(0.5f); // Küçük bir gecikme ekleyerek efektin daha net görünmesini sağlıyoruz
        player.GetComponent<PlayerMovement>().canMove = true; // Oyuncunun hareketini tekrar başlat
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isActive)
        {
            StartCoroutine(TeleportWithDelay(collision.gameObject));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            teleportedCountDown = false;
        }
    }
}