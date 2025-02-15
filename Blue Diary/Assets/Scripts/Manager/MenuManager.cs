using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject settings;
    public GameObject credits;
    //public GameObject startGameCanvas;
    //public bool haspressed;
    void Start()
    {
        MainMenuPanel();
        //haspressed = false;
    }

    void Update()
    {
        
    }

    public void NewGame()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SettingsPanel()
    {
        SetPanelsFalse();
        settings.SetActive(true);
    }
    public void CreditsPanel()
    {
        SetPanelsFalse();
        credits.SetActive(true);
    }
    public void MainMenuPanel()
    {
        SetPanelsFalse();
        menu.SetActive(true);
    }

    public void SetPanelsFalse()
    {
        menu.SetActive(false);
        credits.SetActive(false);
        settings.SetActive(false);
    }
}
