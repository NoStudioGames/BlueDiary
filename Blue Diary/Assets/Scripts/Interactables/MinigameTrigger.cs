using UnityEngine;

public class MinigameTrigger : MonoBehaviour
{
    public Interract interract;
    public GameObject minigamePanel;
    public bool isDone;
    public bool isAdder;
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
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(isAdder)
                minigamePanel.transform.position += Vector3.up*2;
                else if(!isAdder)
                minigamePanel.transform.position += Vector3.down*2;
            }
        }
        else
        {
            minigamePanel.SetActive(false);
        }
    }
}
