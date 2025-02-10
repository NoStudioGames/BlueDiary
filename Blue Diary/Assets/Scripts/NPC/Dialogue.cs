using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    public GameObject Panel;

    private int index;

    public bool isNear;
    public bool hasFinished;

    public DialogueManager dManager;
    public SfxManager sfxManager;


    void Start()
    {
        textComponent.text = string.Empty;
        StartDiologue();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isNear && !hasFinished)
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && hasFinished)
        {
            hasFinished = false;
            RestartDiologue(0);
        }
    }

    public void StartDiologue()
    {
        index = 0;
        hasFinished = false;
        sfxManager.PlaySound(2);
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            sfxManager.PlaySound(2);
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            hasFinished = true;
            dManager.FinishDiologue();
        }
    }

    public void RestartDiologue(int sIndex)
    {
        dManager.StartDiologueCn();
        index = sIndex;
        textComponent.text = string.Empty;
        StartDiologue();
    }
}
