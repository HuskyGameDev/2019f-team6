using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonePhysics : Physics2
{

    public float speed = 5;

    private int num = 0;
    public Transform player;

    // Start is called before the first frame update
    protected new void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        setVelocityTowardPlayer();
        base.ignoreGravity = true;
    }



    public void setVelocityTowardPlayer()
    {
        base.boxCollider = GetComponent<BoxCollider2D>();
        Vector2 aimVelocity = player.position - transform.position;
        aimVelocity.Normalize();
        base.velocity = aimVelocity * speed;
    }



    // Update is called once per frame
    protected new void Update()
    {

        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, base.boxCollider.size, 0);
        foreach (Collider2D hit in hits)
        {

            if (hit.gameObject.CompareTag("Player"))
            {
                if(!base.grounded)
                {
                    Destroy(this.gameObject);
                }
                
            }

            // Ignore the bone's colider and the player's collider
            if ((hit == base.boxCollider) || hit.gameObject.CompareTag("Player"))
                continue;

            ColliderDistance2D colliderDistance = hit.Distance(base.boxCollider);

            // If overlapped
            if (colliderDistance.isOverlapped)
            {
                transform.Translate(colliderDistance.pointA - colliderDistance.pointB);

                if (hit.gameObject.CompareTag("Bone") && !(hit == boxCollider))
                {
                    if (Vector2.Angle(colliderDistance.normal, Vector2.up) < 90 && velocity.y < 0)
                    {
                        this.grounded = true;
                    }

                }
            }
        }

        // Do not use the superclass's update method if grounded
        // This ensures that the object won't keep falling or responding to
        // collisions if grounded
        if (!base.grounded)
        {

            base.Update();
        }
        else
        {
            // If grounded, set x velocity to zero
            base.velocity.x = 0;
        }

    }

}
