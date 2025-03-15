using UnityEngine;

public class ChangeMainPlayer : MonoBehaviour
{
    public PlayerMovement Movlud;
    public PlayerMovement Ziver;
    void Start()
    {
        Ziver.enabled = false;
        Movlud.enabled = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
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
}
