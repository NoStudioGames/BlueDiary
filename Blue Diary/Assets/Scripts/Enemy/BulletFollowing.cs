using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFollowing : MonoBehaviour
{
    public float speed = 5;
    Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Destroy(this.gameObject, 10);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed*Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
