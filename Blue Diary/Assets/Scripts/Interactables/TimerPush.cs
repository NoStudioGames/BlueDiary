using UnityEngine;
using UnityEngine.UI;

public class TimerPush : MonoBehaviour
{
    public Interract interract;
    public GameObject minigamePanel;
    public bool isDone;
    public GameObject timerHand;
    public float rotStrength = -20f;
    public float speed = 0.1f;
    Quaternion currentRot;
    Quaternion targetRot;
    public PushButton pushButton;
    void Start()
    {
        interract = gameObject.GetComponent<Interract>();
        minigamePanel.SetActive(false);
        currentRot = timerHand.transform.rotation;
        targetRot = currentRot;       
    }

    void Update()
    {
        if (interract.isOn && !isDone)
        {
            currentRot = timerHand.transform.rotation;
            minigamePanel.SetActive(true);
            if(!pushButton.buttonPressed)
            {
                timerHand.transform.rotation = Quaternion.Slerp(currentRot, targetRot, speed*Time.deltaTime);
            }
            if(Mathf.Abs(timerHand.transform.rotation.z) >= 0.85f)
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

    public void ButtonPush()
    {
        timerHand.transform.Rotate(0, 0, rotStrength*Time.deltaTime*10);
    }
}
