using System.Collections;
using UnityEngine;

public class BookPass : MonoBehaviour
{
    public GameObject panel;
    public GameManager gameManager;
    public CameraShake cameraShake;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        StartCoroutine(holdforAnimation(2));
    }

    IEnumerator holdforAnimation(float delay){
        cameraShake.ControllableTriggerShake(0.4f, 5);
        yield return new WaitForSeconds(delay);
        panel.SetActive(true);
        yield return new WaitForSeconds(1);
        gameManager.LoadNextLevel();
    }
}
