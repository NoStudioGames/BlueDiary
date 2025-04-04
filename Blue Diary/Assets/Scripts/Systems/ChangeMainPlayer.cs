using UnityEngine;

public class ChangeMainPlayer : MonoBehaviour
{
    public PlayerMovement Movlud;
    public PlayerMovement Ziver;
    public bool canTab;
    void Start()
    {
        Ziver.enabled = false;
        Movlud.enabled = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && canTab){
            ChangePlayer();
        }
    }
    public void ChangePlayer(){
        if(Movlud.enabled){
            Movlud.StopCharacter();
            Movlud.enabled = false;
            Ziver.ResumeCharacter();
            Ziver.enabled = true;
        }
        else{
            Ziver.StopCharacter();
            Ziver.enabled = false;
            Movlud.ResumeCharacter();
            Movlud.enabled = true;
        }
    }
    public void DeactivatePlayers(){
        Movlud.StopCharacter();
        Movlud.enabled = false;
        Ziver.StopCharacter();
        Ziver.enabled = false;
    }
    public void ActivatePlayers()
    {
        Movlud.ResumeCharacter();
        Movlud.enabled = true;
        Ziver.ResumeCharacter();
        Ziver.enabled = true;
    }
}
