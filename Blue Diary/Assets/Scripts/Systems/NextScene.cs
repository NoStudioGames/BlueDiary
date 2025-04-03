using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public bool inArea;
    public int nextLevelIndex;
    public GameObject canvas;
    void Start()
    {
        
    }

    void Update()
    {
        canvas.SetActive(inArea);
        if(Input.GetKeyDown(KeyCode.E) && inArea){
            SceneManager.LoadScene(nextLevelIndex);
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
}
