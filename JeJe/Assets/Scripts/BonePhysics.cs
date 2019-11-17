using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonePhysics : Physics2
{

    
    
    public Transform player;

    public float speed = 10;

    // Start is called before the first frame update
    protected new void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        setVelocityTowardPlayer();
        base.ignoreGravity = true;
    }

    

    public void setVelocityTowardPlayer()
    {
        
        boxCollider = GetComponent<BoxCollider2D>();
        Vector2 linVelocity = player.position - transform.position;

     

        linVelocity.Normalize();
   
        base.velocity = linVelocity * speed;
    }



    // Update is called once per frame
    protected new void Update()
    {


        // If bone is grounded, it is in a fixed position. No need to detect collisions
        if (base.grounded) return;

        Vector2 boxDimRevised = boxCollider.size;
        boxDimRevised.x /= 4;
        boxDimRevised.y /= 4;

        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, boxDimRevised, 0);

        foreach (Collider2D hit in hits)
        {

            if (hit.gameObject.CompareTag("Player"))
            {
                base.ignoreGravity = true;
                if(!base.grounded)
                {
                    // Delete bone game object
                    // Decrement JeJe's health
                    Destroy(this.gameObject);
                    Healthbar.numHeads--;
                }
                
            }

            // Ignore the bone's colider and the player's collider
            if ((hit == base.boxCollider) || hit.gameObject.CompareTag("Player"))
                continue;


            ColliderDistance2D colliderDistance = hit.Distance(base.boxCollider);

            // If overlapped, translate bone in the opposite direction of the overlap and ground it
            if (colliderDistance.isOverlapped)
            {
                transform.Translate(colliderDistance.pointA - colliderDistance.pointB);

                if ( (hit.gameObject.CompareTag("Bone") || hit.gameObject.CompareTag("Ground") ) && !(hit == boxCollider))
                {
                    // If on top of bone
                    if (Vector2.Angle(colliderDistance.normal, Vector2.up) < 90 && velocity.y < 0)
                    {
                        this.grounded = true;
                        base.ignoreGravity = true;
                    }

                    // If colliding from the side
                    if ( (Vector2.Angle(colliderDistance.normal, Vector2.right) < 90 ||
                        Vector2.Angle(colliderDistance.normal, Vector2.left) < 90 ) && velocity.y < 0)
                    {
                        velocity.x = 0;
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
            base.ignoreGravity = true;
        }

    }

}
