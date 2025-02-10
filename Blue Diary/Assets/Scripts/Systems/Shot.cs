using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float Force;
    public Rigidbody2D rb;
    public GameObject blood;
    
    void Start()
    {
        
    }

    void Update()
    {
        rb.AddForce(transform.up*Force*Time.fixedDeltaTime, ForceMode2D.Impulse);
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<Enemy>() != null){
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(blood, transform.position, Quaternion.identity);
        }
    }
}
