using System.Collections;
using Collections.Shaders.CircleTransition;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public bool inArea;
    public int nextLevelIndex;
    public GameObject canvas;
    public CircleTransition circleTransition;
    public bool hasClicked;
    void Start()
    {
        circleTransition = GameObject.FindGameObjectWithTag("CircleTransitionCanvas").GetComponent<CircleTransition>();
    }

    void Update()
    {
        canvas.SetActive(inArea);
        if(Input.GetKeyDown(KeyCode.E) && inArea && !hasClicked){
            hasClicked = true;
            circleTransition.CloseBlackScreen(); 
            StartCoroutine(Holdfortransition());
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            inArea = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            inArea = false;
        }        
    }

    IEnumerator Holdfortransition()
    {
        yield return new WaitForSeconds(1.2F);
        SceneManager.LoadScene(nextLevelIndex);
    }
}
