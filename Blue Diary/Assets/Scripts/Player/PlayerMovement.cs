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
    [SerializeField]private GameObject sprite;
    public GameManager gameManager;
    public CameraShake cameraShake;

    [SerializeField]private bool isCarrying;
    [SerializeField]private bool canDash;
    [SerializeField]private bool canMove;

    [SerializeField]private Transform carryingPoint;
    [SerializeField]private GameObject carryingObject;

    void Start()
    {
        canMove = true; 
        activeMoveSpeed = speed;
        orderLayer = sprite.gameObject.GetComponent<SpriteRenderer>().sortingOrder;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        canDash = true;
        isCarrying = false;
        if(gameManager != null){
            gameManager = null;
        }
    }

    void FixedUpdate()
    {
        if(canMove)
            Move();
        //Dash();
    }
    private void Update()
    {
        if(canMove){
            if(!isCarrying || canDash){
                Dash();
            }
            if(isCarrying && Input.GetKeyDown(KeyCode.Q)){
                Drop();
            }
        }
    }

    public void Move()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        body.MovePosition(body.position + movement * activeMoveSpeed * Time.fixedDeltaTime);
        if((isCarrying && movement.y != 0) || (isCarrying && movement.x != 0)){
            movement.x = 0f;
            movement.y = -1f;
        }
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);


    }
    public void Dash(){
        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
            if(gameManager != null)
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
        if(gameManager != null)
            gameManager.SliderValue(0, dashLength);
        yield return new WaitForSeconds(dashLength);
        isDashing = false;
        activeMoveSpeed = speed;
        dashCoolCounter = dashCooldown;
        if(gameManager != null)
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
        if(collision.gameObject.tag == "RuneBoxes"){
            if(Input.GetKeyDown(KeyCode.E) && !isCarrying){
                BoxesRune boxesRune = collision.gameObject.GetComponent<BoxesRune>();
                if(!boxesRune.isEmpty){
                    Carry(boxesRune.boxes[0]);
                    boxesRune.TakeBox();
                }
                Debug.Log("PressedE ");
            }
            Debug.Log("aroundruneboxes");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Solid" && isDashing)
        {
            cameraShake.TriggerShake();
        }
        
        if(collision.gameObject.tag == "RuneBox"){
            if(Input.GetKeyDown(KeyCode.E) && !isCarrying){
                Carry(collision.gameObject);
            }
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "RuneBox"){
            if(Input.GetKeyDown(KeyCode.E) && !isCarrying){
                Carry(collision.gameObject);
            }
        }
    }

    public void Carry(GameObject box){
        isCarrying = true;
        carryingObject = box;
        carryingObject.transform.position = carryingPoint.transform.position;
        carryingObject.transform.parent = carryingPoint.transform;
        carryingObject.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 11;
    }   
    public void Drop(){
        isCarrying = false;
        carryingObject.transform.parent = null;
        carryingObject.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 9;
    }


    public void StopCharacter(){
        canMove = false;
        animator.SetFloat("Horizontal", 0);
        animator.SetFloat("Vertical", 0);
        animator.SetFloat("speed", 0);
    }
    public void ResumeCharacter(){
        canMove = true;
    }
}
