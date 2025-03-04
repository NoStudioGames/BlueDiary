using UnityEngine;

public class PutToPlace : MonoBehaviour
{
    public Interract interract;
    public GameObject minigamePanel;
    public bool isDone;
    public GameObject part;
    public GameObject back;
    void Start()
    {
        interract = gameObject.GetComponent<Interract>();
        minigamePanel.SetActive(false);
    }

    void Update()
    {
        if (interract.isOn && !isDone)
        {
            minigamePanel.SetActive(true);
            if (part.transform.position == back.transform.position)
            {
                interract.isOn = false;
                isDone = true;
            }
        }
        else
        {
            minigamePanel.SetActive(false);
        }
    }
}
