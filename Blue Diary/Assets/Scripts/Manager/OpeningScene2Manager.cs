using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningScene2Manager : MonoBehaviour
{

    public GameObject[] cams;
    public CheckCollider[] collidedCams;
    public int currentCamIndex;
    public int gameLevelIndex;
    void Start()
    {
        currentCamIndex = 0;
    }

    void Update()
    {
        if(collidedCams[currentCamIndex].isColliding && currentCamIndex + 1 < cams.Length){
            cams[currentCamIndex].SetActive(false);
            cams[currentCamIndex + 1].SetActive(true);
            currentCamIndex ++;
        }if(currentCamIndex >= 1){
            StartCoroutine(ChangeCam(5));
        }
    }

    IEnumerator ChangeCam(float delay){
        yield return new WaitForSeconds(delay);
        if(currentCamIndex + 1 < cams.Length){
            cams[currentCamIndex].SetActive(false);
            cams[currentCamIndex + 1].SetActive(true);
            currentCamIndex++;
            if(currentCamIndex == cams.Length-1){
                yield return new WaitForSeconds(delay);
                SceneManager.LoadScene(gameLevelIndex);
            }
        }
    }
}
