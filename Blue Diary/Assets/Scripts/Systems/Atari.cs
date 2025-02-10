using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Atari : MonoBehaviour
{
    public int gameindex;
    public static float maxscore = 1000;
    public static float score;
    public static bool hasPassed = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(gameindex);
            }
        }
    }
}
