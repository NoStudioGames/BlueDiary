using UnityEngine;

public class PlayerMovementAli : MonoBehaviour
{
    private int DIRECTION = 0; // 0: down, 1: up, 2: left, 3: right
    
    private bool MOVING = false;

    private float speed = 5f;

    private GameObject player;
    
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        player = gameObject; // Fixed typo: gameobject -> gameObject
        animator = player.GetComponent<Animator>(); // Initialize animator
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Prevent moving if both left and right or both up and down are pressed
        if ((Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)))
        {
            horizontal = 0;
            vertical = 0;
        }

        MOVING = horizontal != 0 || vertical != 0; // Check if the player is moving

        // Prioritize the first key pressed
        if (Input.GetKey(KeyCode.W)) // Up
            DIRECTION = 1; 
        else if (Input.GetKey(KeyCode.S)) // Down
            DIRECTION = 0;
        else if (Input.GetKey(KeyCode.D)) // Right
            DIRECTION = 3;
        else if (Input.GetKey(KeyCode.A)) // Left
            DIRECTION = 2;

        animator.SetInteger("DIRECTION", DIRECTION);
        animator.SetBool("MOVING", MOVING);

        // Adjust vertical speed to be 30% slower
        Vector3 movement = new Vector3(horizontal, vertical * 0.7f, 0f) * speed * Time.deltaTime;
        player.transform.Translate(movement);
    }
}
