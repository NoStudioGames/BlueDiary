using UnityEngine;

public class MinigameTrigger : MonoBehaviour
{
    public Interract interract;
    public GameObject minigamePanel;
    public bool isDone;
    void Start()
    {
        interract = gameObject.GetComponent<Interract>();
        minigamePanel.SetActive(false);
    }

    void Update()
    {
        if (interract.isOn)
        {
            minigamePanel.SetActive(true);
        }
    }
}
