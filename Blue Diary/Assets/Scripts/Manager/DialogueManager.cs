using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    public bool isNear;
    public GameObject DiologueCanvas;
    public Dialogue dialogue;

    void LateUpdate()
    {
        if (isNear && Input.GetKeyDown(KeyCode.E))
        {
            DiologueCanvas.SetActive(true);
            dialogue.isNear = true;
        }
        if(!isNear && DiologueCanvas.gameObject.activeSelf)
        {
            dialogue.isNear = false;
            DiologueCanvas.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isNear = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isNear = false;
        }
    }

    public void FinishDiologue()
    {
        DiologueCanvas.SetActive(false);
    }
    public void StartDiologueCn()
    {
        DiologueCanvas.SetActive(true);
    }
}
