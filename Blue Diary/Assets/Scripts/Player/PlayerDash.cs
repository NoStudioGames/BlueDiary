using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D rb;
    public Animator animator;

    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    [Header("Dash Settings")]
    public float dashForce = 30f;
    public float dashDuration = 0.1f;
    public float dashCooldown = 1f;

    private bool isDashing = false;
    private float dashCooldownTimer = 0f;

    private Vector2 dashDirection;
    public float attackDamage = 100;
    public float health = 200;

    void Update()
    {
        // Handle dash cooldown timer
        if (dashCooldownTimer > 0)
        {
            dashCooldownTimer -= Time.deltaTime;
        }

        // Check for dash input
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldownTimer <= 0 && !isDashing)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            // Only dash if there is a direction to move
            if (horizontalInput != 0 || verticalInput != 0)
            {
                dashDirection = new Vector2(horizontalInput, verticalInput).normalized;
                StartCoroutine(Dash());
            }
        }
    }

    void FixedUpdate()
    {
        // Skip normal movement while dashing
        if (isDashing) return;

        // Handle normal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        animator.SetBool("dashSide", isDashing);
        dashCooldownTimer = dashCooldown;


        // Reset velocity and apply dash force
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(dashDirection * dashForce, ForceMode2D.Impulse);

        // Wait for dash duration
        yield return new WaitForSeconds(dashDuration);

        // Restore gravity and reset dash state
        isDashing = false;
        animator.SetBool("dashSide", isDashing);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                animator.SetTrigger("attack");
                collision.gameObject.GetComponent<Enemy>().Attacked(attackDamage);
            }
        }
    }
}
