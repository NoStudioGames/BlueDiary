using Collections.Shaders.CircleTransition;
using UnityEngine;

public class Chapter1CutsceneManager : MonoBehaviour
{
    public CutsceneCamera cutCamera;
    public GameObject mainCam;
    public GameObject cutCam;
    public PlayerMovement playerMovement;
    public CircleTransition circleTransition;
    public GameObject ziver;

    void Start()
    {
        circleTransition = GameObject.FindGameObjectWithTag("CircleTransitionCanvas").GetComponent<CircleTransition>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        mainCam.SetActive(false);
        cutCam.SetActive(true);
        cutCamera.isEnabled = true;
        cutCamera.triggerable = true;
        cutCamera.StartCutscene(2);
    }

    void Update()
    {
        if (cutCamera.hasFinished)
        {
            cutCam.SetActive(false);
            mainCam.SetActive(true);
            Destroy(ziver);
            Destroy(this.gameObject);
        }
    }
}
