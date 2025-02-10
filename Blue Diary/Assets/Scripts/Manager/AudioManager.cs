using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Source")]
    public AudioSource source;
    [Header("Musics")]
    public AudioClip music1;
    public AudioClip music2;


    void Start()
    {
        source = GetComponent<AudioSource>();

        music1 = Resources.Load<AudioClip>("Soundtracks/music1");
        music2 = Resources.Load<AudioClip>("Soundtracks/music2");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlaySound(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlaySound(2);
        }
    }

    public void PlaySound(float sfxId)
    {
        switch (sfxId)
        {
            case 0:
                return;
            case 1:
                source.clip = music1;
                source.Play();
                return;
            case 2:
                source.clip = music2;
                source.Play();
                return;
            default:
                break;
        }

    }
}
