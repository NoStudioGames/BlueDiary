using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceSound : MonoBehaviour
{
    public Collider2D Area;
    public GameObject Player;
    public AudioSource audioSource;
    public float fadeSpeed = 1.0f;
    public float volume = 1;
    public float maxVolume = 1;

    public float maxdistance;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 closestPoint = Area.ClosestPoint(Player.transform.position);
        transform.position = closestPoint;
        float distance = Vector2.Distance(Player.transform.position, gameObject.transform.position);
        if (Mathf.Abs(distance) > maxdistance)
        {
            volume = 0;
        }
        else if(distance == 0 || Mathf.Abs(distance) < maxdistance)
        {
            volume = maxVolume;
        }

        audioSource.volume = Mathf.Lerp(audioSource.volume, volume, Time.deltaTime * fadeSpeed);
    }
}
