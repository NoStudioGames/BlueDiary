using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLayerManager : MonoBehaviour
{
    public GameObject player;
    public int orderLayer;
    void Start()
    {
        orderLayer = gameObject.GetComponent<SpriteRenderer>().sortingOrder;
    }

    void Update()
    {
        if(player.transform.position.y > transform.position.y)
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = orderLayer + 1;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = orderLayer - 1;
        };
    }
}
