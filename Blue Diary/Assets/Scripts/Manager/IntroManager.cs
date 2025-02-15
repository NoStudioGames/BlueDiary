using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        
    }

    void Update()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Opening")){
            if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
                SceneManager.LoadScene(1);
        }
    }
}
