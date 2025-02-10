using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcQuest : MonoBehaviour
{
    public CutsceneCamera Camera;
    public bool canActivate;
    public bool canFocus;
    public bool hasActivated;
    public GameObject canvas;
    public Animator animator;
    public GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canvas.SetActive(false);
        canActivate = false;
        canFocus = false;
        hasActivated = false;
        if(animator == null)
        {
            animator = GetComponent<Animator>();
        }
        animator.SetBool("lookdown", false);
    }

    void Update()
    {
        if (canActivate)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                canFocus = true;
                canvas.SetActive(false);
                if (canFocus && !hasActivated)
                {
                    Camera.isEnabled = true;
                    hasActivated = true;
                }
                if(player.transform.position.y < transform.position.y)
                {
                    animator.SetBool("lookdown", true);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            canActivate = true;
            canvas.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canActivate = false;
            canFocus = false;
            hasActivated = false;
            canvas.SetActive(false);
            animator.SetBool("lookdown", false);
        }
    }
}
