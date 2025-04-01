using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator.SetTrigger("open");
    }

    void Update()
    {
        Debug.Log(animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        Debug.Log(animator.IsInTransition(0));
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Opening")){
            if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.75f && !animator.IsInTransition(0))
                SceneManager.LoadScene(1);
        }
    }
}
