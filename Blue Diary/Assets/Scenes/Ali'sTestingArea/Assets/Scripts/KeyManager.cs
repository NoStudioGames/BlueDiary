using System.Collections;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject selfKey = null;
    private GameObject hoverKey = null;

    private bool isKeyHovering = true;
    private bool isKeyHovered = false;

    private void Awake()
    {
        selfKey = gameObject.transform.GetChild(0).gameObject;
        hoverKey = gameObject.transform.GetChild(1).gameObject;
    }

    private void Start()
    {
        if (isKeyHovering)
        {
            StartCoroutine(SwitchKeys());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SwitchKeys()
    {
        yield return new WaitForSeconds(0.5f); // Wait for 200ms
        selfKey.SetActive(isKeyHovered);
        hoverKey.SetActive(!isKeyHovered);
        isKeyHovered = !isKeyHovered;
        StartCoroutine(SwitchKeys());
    }
}
