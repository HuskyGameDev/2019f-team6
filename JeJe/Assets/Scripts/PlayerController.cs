using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    float speed = 4;

    float walkAcceleration = 75;

    float airAcceleration = 30;

    float groundDeceleration = 70;

    float jumpHeight = 2;

    private BoxCollider2D boxCollider;

    private Vector2 velocity;

    private bool grounded;

    bool lastFace = true;

    public AudioClip MusicClip;

    public AudioSource MusicSource;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        MusicSource.clip = MusicClip;
    }

    private void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        // Check for facing left or right for animation
       
        if (Input.GetAxis("Horizontal") > 0.01)
        {
            animator.SetBool("FacingRight", true);
            lastFace = true;
        } else if (Input.GetAxis("Horizontal") < -0.01)
        {
            animator.SetBool("FacingRight", false);
            lastFace = false;
        } else
        {
            animator.SetBool("FacingRight", lastFace);
        }

        // Get the move input from the keyboard
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (grounded)
        {
            velocity.y = 0;
            animator.SetBool("Jumping", false);


            if (Input.GetButtonDown("Jump"))
            {
                // Calculate the velocity required to achieve the target jump height.
                // MusicSource.Play();
                velocity.y = Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics2D.gravity.y));
                animator.SetBool("Jumping", true);
                
            }
        } else
        {
            // fast fall input
            if (Input.GetKeyDown("s"))
            {
                velocity.y = -Mathf.Sqrt(jumpHeight * Mathf.Abs(Physics2D.gravity.y));
            }
        }

        float acceleration = grounded ? walkAcceleration : airAcceleration;
        float deceleration = grounded ? groundDeceleration : 0;

        if (moveInput != 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, speed * moveInput, acceleration * Time.deltaTime);
        }

        else
        
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
        }

        velocity.y += Physics2D.gravity.y * Time.deltaTime;

        transform.Translate(velocity * Time.deltaTime);

        grounded = false;

        // Get a list of all colliders intersecting the player
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, boxCollider.size, 0);

        foreach (Collider2D hit in hits)
        {
            // Do nothing with the player's own collider
            if (hit == boxCollider)
                continue;

            ColliderDistance2D colliderDistance = hit.Distance(boxCollider);

            // If overlapped
            if (colliderDistance.isOverlapped)
            {
                transform.Translate(colliderDistance.pointA - colliderDistance.pointB);

                // If hitting the ground, set grounded to true
                if (Vector2.Angle(colliderDistance.normal, Vector2.up) < 90 && velocity.y < 0)
                {
                    grounded = true;
                }
            }
        }
    }
}
