using UnityEngine;

public class RuneBoxManager : MonoBehaviour
{
    public RuneBoxType[] runeBoxTypes;
    private int activeBoxes;
    public SmoothTranslator statueTranslator;
    void Update()
    {

    }
    public void ActivateBox(){
        activeBoxes = 0;
        foreach(RuneBoxType runeBox in runeBoxTypes){
            if(runeBox.isActive){
                activeBoxes ++;
            }
        }
        if(activeBoxes == runeBoxTypes.Length){
            statueTranslator.active = true;
        }else{
            statueTranslator.active = false;
        }
    }
}
