using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject settings;
    public int levelindex;
    public Slider dashSlider;
    public PlayerMovement playerMovement;

    void Start()
    {
        ResumeGame();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(menu.gameObject.activeSelf)
            {
                ResumeGame();
            }
            else
            {
                MenuPanel();
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            LoadNextLevel(levelindex);
        }
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene(0);
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

    public void MenuPanel()
    {
        SetPanelsFalse();
        menu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        SetPanelsFalse();
        Time.timeScale = 1.0f;
    }

    public void SetPanelsFalse()
    {
        menu.SetActive(false);
        settings.SetActive(false);
    }

    public void LoadNextLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void SliderValue(float value, float changeSpeed)
    {
        if(changeSpeed == -1)
            dashSlider.value = value;
        else
            dashSlider.value = Mathf.MoveTowards(dashSlider.value, value, changeSpeed * Time.deltaTime);
    }
}
