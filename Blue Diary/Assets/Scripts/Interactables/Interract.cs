using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interract : MonoBehaviour
{
    public GameObject uiElement;
    public bool inTrigger;
    public bool isOn;
    void Start()
    {
        
    }

    void LateUpdate()
    {
        if(inTrigger && Input.GetKeyDown(KeyCode.E) && !isOn)
        {
            isOn = true;
            TriggeredCollider(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            inTrigger = true;
            TriggeredCollider(inTrigger);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inTrigger = false;
            TriggeredCollider(inTrigger);
        }
    }

    public void TriggeredCollider(bool cantrigger)
    {
        uiElement.SetActive(cantrigger);
    }
}
