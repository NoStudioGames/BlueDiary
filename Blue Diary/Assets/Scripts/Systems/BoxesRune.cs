using UnityEngine;

public class BoxesRune : MonoBehaviour
{
    public GameObject[] boxes;
    public bool isEmpty;
    [SerializeField]private int emptyTry = 0;
    void Start()
    {
        isEmpty = false;
        emptyTry = 0;
    }

    void Update()
    {

    }

    public void TakeBox(){
        if(boxes[0] == boxes[boxes.Length-1]){
            emptyTry += 1;
            if(emptyTry >= 0){
                isEmpty = true;
            }
        }
        GameObject[] boxesCopy = boxes;
        for(int i = 0; i < boxes.Length-1; i++){
            boxes[i] = boxesCopy[i+1];
        }

    }
}
