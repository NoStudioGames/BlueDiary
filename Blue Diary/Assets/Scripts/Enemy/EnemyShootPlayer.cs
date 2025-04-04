using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootPlayer : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    public float shootingRange;
    public float fireRate = 1f;
    private float nextFireTime;
    private Transform player;
    public GameObject bullet;
    public GameObject bulletParent;
    public Animator animator;
    public float health = 200;
    public Shake shake;
    public CameraShake cameraShake;
    public bool followHorizontally;
    public bool followVertically;
    public Vector3 refPos;
    public bool isActive;
    void Start()
    {
        StartCoroutine(HoldForStart());
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = gameObject.GetComponent<Animator>();
        shake = gameObject.GetComponent<Shake>();
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        refPos = player.transform.position;
    }

    void Update()
    {
        if (isActive)
        {
            if(followHorizontally){
                refPos = new Vector3(player.position.x, this.transform.position.y, transform.position.z);
            }
            if(followVertically)
            {
                refPos = new Vector3(this.transform.position.x, player.position.y, transform.position.z);
            }
            if(followHorizontally && followVertically){
                refPos = new Vector3(player.position.x, player.position.y, transform.position.z);
            }

            if(health > 0){
                float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
                if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
                {
                    transform.position = Vector2.MoveTowards(this.transform.position, refPos, speed * Time.deltaTime);
                }
                else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time) { 
                    GameObject fire = Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
                    Vector3 moveDirection = gameObject.transform.position -player.transform.position; 
        		    float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
		            fire.transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);

                    cameraShake.ControllableTriggerShake(0.1f, 0.3f);
                    nextFireTime = Time.time + fireRate;
                }
            }
        }
        else
        {
            if (!followHorizontally)
            {
                refPos = new Vector3(player.position.x, this.transform.position.y, transform.position.z);
            }
            if (!followVertically)
            {
                refPos = new Vector3(this.transform.position.x, player.position.y, transform.position.z);
            }
            if (!followHorizontally && !followVertically)
            {
                refPos = new Vector3(player.position.x, player.position.y, transform.position.z);
            }

            float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
            if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, refPos, speed * Time.deltaTime);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Throwable"){
            Hurt();
            Destroy(collision.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Throwable"){
            Hurt();
            Destroy(collision.gameObject);
        }
    }

    public void Hurt(){
        animator.SetTrigger("hurt");
        shake.TriggerShake();
        health -= 50;
        if(health <= 0){
            Death();
        }
    }
    public void Death(){
        float delay = animator.GetCurrentAnimatorStateInfo(0).length*0.8f;
        shake.TriggerShake();
        Destroy(this.gameObject, delay);
    }
    IEnumerator HoldForStart()
    {
        isActive = false;
        yield return new WaitForSeconds(2);
        isActive = true;
    }
}
