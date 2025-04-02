using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

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
    void Start()
    {
        movludInPlace = false;
        ziverInPlace = false;
    }

    void Update()
    {
        movludInPlace = isMovludCol.isColliding;
        ziverInPlace = isZiverCol.isColliding;

        if(!movludInPlace && !ziverInPlace){
            pressBtnText.text = "press >";
        }if(movludInPlace && !ziverInPlace){
            pressBtnText.text = "press <";
            if(changeMainPlayer.Movlud.enabled){
                changeMainPlayer.ChangePlayer();
            }
        }if(movludInPlace && ziverInPlace){
            pressBtnText.text = "press E";
            if(changeMainPlayer.Ziver.enabled){
                changeMainPlayer.DeactivatePlayers();
                dialogueManager.isActivated = true;
            }
        }
        if(dialogueManager.dialogue.hasFinished){
            StartCoroutine(HoldForNextScene(2));
        }
    }
    IEnumerator HoldForNextScene(float delay){
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(gameLevelIndex);
    }
}
