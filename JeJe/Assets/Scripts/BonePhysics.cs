using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonePhysics : Physics2
{

    public float startXforce = -3.0f;
    public float startYforce = 3.0f;

    // Start is called before the first frame update
    protected new void Start()
    {
        base.boxCollider = GetComponent<BoxCollider2D>();
        base.velocity += new Vector2(startXforce, startYforce);
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
