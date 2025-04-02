using UnityEngine;

public class Door : MonoBehaviour
{
    public bool hasKnocked;
    public bool locked;
    public bool isNear;
    void Start()
    {
        
    }

    void Update()
    {
        if (isNear)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (!locked)
                {
                    Knock();
                }
                else
                {
                    return;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isNear = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
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

    public void Knock()
    {
        hasKnocked = true;
    }
}
