using System;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D body;
    Vector2 movement;
    public Animator animator;
    //public GameObject Sword;
    //public bool isAttacking;
    //public bool isDead;
    //public float playerSpeed;


    [SerializeField]private float activeMoveSpeed;
    public float dashSpeed;
    public float dashLength = 0.5f, dashCooldown = 1f;
    [SerializeField]private bool isDashing;
    [SerializeField]private float dashCoolCounter;
    [SerializeField]private int orderLayer;
    [SerializeField] private GameObject sprite;
    public GameManager gameManager;
    public CameraShake cameraShake;

    void Start()
    {
        activeMoveSpeed = speed;
        orderLayer = sprite.gameObject.GetComponent<SpriteRenderer>().sortingOrder;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
    }

    void FixedUpdate()
    {
        Move();
        //Dash();
    }
    private void Update()
    {
        Dash();
    }

    public void Move()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        body.MovePosition(body.position + movement * activeMoveSpeed * Time.fixedDeltaTime);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);

    }
    public void Dash(){
        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
            gameManager.SliderValue((1 - (dashCoolCounter/dashCooldown)), -1);
        }
        if (Input.GetKeyDown(KeyCode.Space) && dashCoolCounter <= 0 && (movement.x != 0 || movement.y != 0))
        {
            isDashing = true;
            StartCoroutine(DashCooldown());
        }

    }

    IEnumerator DashCooldown()
    {
        activeMoveSpeed = dashSpeed;
        gameManager.SliderValue(0, dashLength);
        yield return new WaitForSeconds(dashLength);
        isDashing = false;
        activeMoveSpeed = speed;
        dashCoolCounter = dashCooldown;
        gameManager.SliderValue(dashCoolCounter, -1);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Npc" && collision.gameObject.GetComponent<SpriteRenderer>() != null)
        {
            if (collision.transform.position.y > transform.position.y)
            {
                collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = orderLayer - 1;
            }
            else
            {
                collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = orderLayer + 1;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Solid" && isDashing)
        {
            cameraShake.TriggerShake();
        }
    }
}
