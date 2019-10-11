using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics2 : MonoBehaviour
{
    protected BoxCollider2D boxCollider;

    protected Vector2 velocity;

    protected bool grounded = false;

    protected bool ignorePlayer = true;

    protected void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected void Update()
    {

        if (grounded)
        {
            velocity.y = 0;
        }

        velocity.y += Physics2D.gravity.y * Time.deltaTime;

        transform.Translate(velocity * Time.deltaTime);

        grounded = false;

        // Retrieve all colliders we have intersected after velocity has been applied.
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, boxCollider.size, 0);

        foreach (Collider2D hit in hits)
        {
            // Ignore his object's own collider
            if (hit == boxCollider)
                continue;

            // If the object is set to ignore the player's collider, ignore it
            if (ignorePlayer && hit.gameObject.CompareTag("Player"))
                continue;

            ColliderDistance2D colliderDistance = hit.Distance(boxCollider);

            // If overlaped
            if (colliderDistance.isOverlapped)
            {
                transform.Translate(colliderDistance.pointA - colliderDistance.pointB);

                // If on the ground, set grounded to true
                if (Vector2.Angle(colliderDistance.normal, Vector2.up) < 90 && velocity.y < 0)
                {
                    grounded = true;
                }
            }
        }
    }
}
