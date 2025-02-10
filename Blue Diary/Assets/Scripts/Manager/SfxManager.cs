using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    [Header("Source")]
    public AudioSource source;
    [Header("AudioClips")]
    public AudioClip buttonClick;
    public AudioClip villagerSound;
    public AudioClip suprise;


    void Start()
    {
        source = GetComponent<AudioSource>();

        buttonClick = Resources.Load<AudioClip>("buttonClick");
        villagerSound = Resources.Load<AudioClip>("Sfx/villager");
        suprise = Resources.Load<AudioClip>("Sfx/suprise2");

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaySound(0);
        }
    }

    public void PlaySound(float sfxId)
    {
        switch (sfxId)
        {
            case 0:
                return;
            case 1:
                source.PlayOneShot(buttonClick);
                return;
            case 2:
                source.PlayOneShot(villagerSound);
                return;
            default:
                break;
        }

    }

}
