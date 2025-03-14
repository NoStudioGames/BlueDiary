using UnityEngine;

public class RuneBoxType : MonoBehaviour
{
    public int typeIndex;
    public Transform artifactPos;
    public bool isActive;
    public RuneBoxManager runeBoxManager;
    public float activationRange = 1;
    void Start()
    {
        
    }

    void Update()
    {
        if(transform.parent == null){
            if(Vector2.Distance(transform.position, artifactPos.position) <= activationRange){
                transform.position = artifactPos.position;
                isActive = true;
                runeBoxManager.ActivateBox();
                gameObject.GetComponent<Collider2D>().isTrigger = true;
            }
        }
    }
}
