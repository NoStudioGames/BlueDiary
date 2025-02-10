using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalking : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed;

    private int currentwaypointIndex = 0;
   
    void Update()
    {
        if (waypoints.Length == 0) return;

        Transform targetWaypoit = waypoints[currentwaypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetWaypoit.position, speed * Time.deltaTime);

        if (transform.position.x < targetWaypoit.position.x)
        {

            transform.localScale = new Vector3(1, 1, 1);

        }

        else if (transform.position.x > targetWaypoit .position . x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }


        if (Vector2.Distance(transform.position , targetWaypoit .position ) <0.1f)
        {

            currentwaypointIndex = (currentwaypointIndex + 1) % waypoints.Length;
        }
    }
}
