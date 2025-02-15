using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.EventSystems;
using TMPro;

public class ButtonSelection : MonoBehaviour
{
    EventSystem eventSystem;
    public GameObject selectedButton;
    public GameObject currSelectedButton;
    public GameObject nullGameObject;
    Color selected = Color.white;
    Color notSelected = Color.white;
    public GameObject[] buttons;

    void OnEnable()
    {
        //Fetch the current EventSystem. Make sure your Scene has one.
        eventSystem = EventSystem.current;

    }

    void Start()
    {
        // button.navigation = Navigation.defaultNavigation;
        // eventSystem.SetSelectedGameObject(selectedButton);
        UnityEngine.Color newColor;
        if (UnityEngine.ColorUtility.TryParseHtmlString("#4A90E2", out newColor))
        {
            selected = newColor;
        }
        else
        {
            Debug.Log("Failed to parse color");
        }
        UnityEngine.Color newColor2;
        if (UnityEngine.ColorUtility.TryParseHtmlString("#BAA6A5", out newColor2))
        {
            notSelected = newColor2;
        }
        else
        {
            Debug.Log("Failed to parse color");
        }
    }
    private void Update() {
        currSelectedButton = eventSystem.currentSelectedGameObject;
        
        if(Input.GetMouseButtonDown(0)){
            if(currSelectedButton){
                if(currSelectedButton != selectedButton){
                    if(!currSelectedButton.gameObject.GetComponent<Button>()){
                        eventSystem.SetSelectedGameObject(selectedButton);
                    }else{
                        eventSystem.SetSelectedGameObject(nullGameObject);
                    }
                }else{
                    eventSystem.SetSelectedGameObject(nullGameObject);
                }
            }else{
                eventSystem.SetSelectedGameObject(selectedButton);
            }
        }
        if(Input.GetMouseButtonDown(1)){
            ResetButtons();
        }
        if(!currSelectedButton) return;
        if(currSelectedButton.gameObject.GetComponent<Button>())
        {
            currSelectedButton.GetComponentInChildren<TextMeshProUGUI>().color = selected;
        }
        for(int i = 0; i<buttons.Length; i++)
        {
            if (buttons[i] != currSelectedButton)
            {
                buttons[i].GetComponentInChildren<TextMeshProUGUI>().color = notSelected;
            }
        }
    }

    public void ResetButtons(){
        for(int i = 0; i<buttons.Length; i++)
        {
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().color = notSelected;
        }
    }
}
