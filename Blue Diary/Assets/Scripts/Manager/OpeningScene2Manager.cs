using System;
using System.Collections;
using Collections.Shaders.CircleTransition;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningScene2Manager : MonoBehaviour
{

    public GameObject[] cams;
    public CheckCollider[] collidedCams;
    public int currentCamIndex;
    public int gameLevelIndex;
    public CircleTransition circleTransition;
    void Start()
    {
        currentCamIndex = 0;
        circleTransition = GameObject.FindGameObjectWithTag("CircleTransitionCanvas").GetComponent<CircleTransition>();
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
            if (currentCamIndex == cams.Length-1){
                yield return new WaitForSeconds(delay-1);
                if (circleTransition != null)
                {
                    circleTransition.CloseBlackScreenForCamera();
                }
                yield return new WaitForSeconds(1.2f);
                SceneManager.LoadScene(gameLevelIndex);
            }
        }
    }
}
