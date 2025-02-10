using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public Animator animator;
    public float attackDamage = 50;

    public float speed;
    public float lineOfSite;
    public float shootingRange;
    public float fireRate = 1f;
    private float nextFireTime;
    private GameObject playerObject;
    private Transform player;

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (health < 0){
            Destroy(this.gameObject);
        }
        else{
            float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
            if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            }
            else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
            {
                Attack(attackDamage);
                nextFireTime = Time.time + fireRate;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
    public void Attacked(float damage)
    {
        health -= damage;
    }
    public void Attack(float damage)
    {
        animator.SetTrigger("attack");
        playerObject.GetComponent<PlayerDash>().health -= damage;
    }
}
