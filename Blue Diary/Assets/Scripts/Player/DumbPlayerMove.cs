using UnityEngine;

public class DumbPlayerMove : MonoBehaviour
{

    public float speed;
    public Rigidbody2D body;
    public Vector2 movement;
    public Animator animator;
    //public GameObject Sword;
    //public bool isAttacking;
    //public bool isDead;
    //public float playerSpeed;


    [SerializeField]private float activeMoveSpeed;
    [SerializeField]private bool isDashing;
    [SerializeField]private float dashCoolCounter;
    [SerializeField]private int orderLayer;
    [SerializeField]private GameObject sprite;
    public GameManager gameManager;
    public bool canMove;

    void Start()
    {
        canMove = true; 
        activeMoveSpeed = speed;
        orderLayer = sprite.gameObject.GetComponent<SpriteRenderer>().sortingOrder;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void FixedUpdate()
    {
        if(canMove)
            Move();
    }

    public void Move()
    {
        if(movement.x >= 0.1f){
            movement.x = 1;
        }else{
            movement.x = Input.GetAxis("Horizontal");
        }
        movement.y = Input.GetAxis("Vertical");
        body.MovePosition(body.position + movement * activeMoveSpeed * Time.fixedDeltaTime);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);

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
