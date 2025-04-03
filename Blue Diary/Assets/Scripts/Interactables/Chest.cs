using UnityEngine;

public class Chest : MonoBehaviour
{

    public Animator animator;
    public bool unlocked;
    public bool itemTaken;
    public Interract interract;
    public GameObject item;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        interract = gameObject.GetComponent<Interract>();
        unlocked = false;
        animator.SetBool("unlocked", unlocked);
    }

    void LateUpdate()
    {
        if(unlocked && interract.isOn && Input.GetKeyDown(KeyCode.E) && !itemTaken){
            unlocked = false;
            itemTaken = true;
            item.SetActive(true);
            animator.SetBool("unlocked", unlocked);
        }
        if(interract.isOn && !unlocked && !itemTaken){
            animator.SetTrigger("unlock");
            unlocked = true;
            animator.SetBool("unlocked", unlocked);
        }
    }

}
