using System.Collections;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public GameObject[] scenes;
    public int sceneIndex;
    public float sceneDelay = 2;
    public bool canSkip;
    void Start()
    {
        sceneIndex = 0;
        foreach (var scene in scenes)
        {
            scene.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CutscenePlay(scenes);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canSkip = true;
        }
    }

    public void CutscenePlay(GameObject[] scenes)
    {
        StartCoroutine(HoldScene(sceneDelay, scenes));
    }
    IEnumerator HoldScene(float delay, GameObject[] scenes)
    {
        foreach (GameObject scene in scenes)
        {
            if (canSkip)
            {
                break;
            }
            scene.SetActive(true);
            yield return new WaitForSeconds(delay);
            scene.SetActive(false);
        }
        canSkip = false;
    }
}
