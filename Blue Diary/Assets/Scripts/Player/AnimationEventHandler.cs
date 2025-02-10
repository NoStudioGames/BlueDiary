using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private MapManager mapManager;
    [SerializeField] private GameObject player;
    

    private void Awake()
    {

        if (mapManager == null || audioSource == null)
        {
            mapManager = FindAnyObjectByType<MapManager>();
            audioSource = GetComponentInChildren<AudioSource>();
        }
    }

    public void Step()
    {
        if(mapManager != null && audioSource != null)
        {
            AudioClip currentFloorClip = mapManager.GetCurrentFloorClip(player.transform.position);
            if(currentFloorClip != null)
            {
                audioSource.PlayOneShot(currentFloorClip);
            }
        }
        else
        {
            return;
        }
    }

}
