using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
using Collections.Shaders.CircleTransition;

public class MonologueSceneManager : MonoBehaviour
{
    public Transform movludCol;
    public Transform ziverCol;

    public bool movludInPlace;
    public bool ziverInPlace;
    public TMP_Text pressBtnText;
    public ChangeMainPlayer changeMainPlayer;
    public CheckCollider isMovludCol;
    public CheckCollider isZiverCol;

    public DialogueManager dialogueManager;
    public int gameLevelIndex;
    public CircleTransition circleTransition;
    void Start()
    {
        movludInPlace = false;
        ziverInPlace = false;
        circleTransition = GameObject.FindGameObjectWithTag("CircleTransitionCanvas").GetComponent<CircleTransition>();
        if (circleTransition != null)
        {
            circleTransition.OpenBlackScreen();
        }
    }

    void Update()
    {
        movludInPlace = isMovludCol.isColliding;
        ziverInPlace = isZiverCol.isColliding;

        if(!movludInPlace && !ziverInPlace){
            pressBtnText.text = "press >";
        }
        if(movludInPlace && !ziverInPlace){
            pressBtnText.text = "press E";
            if (changeMainPlayer.Movlud.enabled){
                changeMainPlayer.ChangePlayer();
                changeMainPlayer.DeactivatePlayers();
                dialogueManager.isActivated = true;
            }
        }
        if (dialogueManager.dialogue.hasFinished) {
            pressBtnText.text = "press <";
            if (!changeMainPlayer.Movlud.enabled)
            {
                changeMainPlayer.ActivatePlayers();
                changeMainPlayer.ChangePlayer();
            }
        }
        if (movludInPlace && ziverInPlace)
        {
            changeMainPlayer.DeactivatePlayers();
            StartCoroutine(HoldForNextScene(2));
        }
    }
    IEnumerator HoldForNextScene(float delay){
        if(circleTransition != null)
        {
            circleTransition.CloseBlackScreenForCamera();
        }
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(gameLevelIndex);
    }
}
