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

            // Ignore our own collider.
            if ((hit == base.boxCollider) || hit.gameObject.CompareTag("Player"))
                continue;

            ColliderDistance2D colliderDistance = hit.Distance(base.boxCollider);

            // Ensure that we are still overlapping this collider.
            // The overlap may no longer exist due to another intersected collider
            // pushing us out of this one.
            if (colliderDistance.isOverlapped)
            {
                transform.Translate(colliderDistance.pointA - colliderDistance.pointB);
            }
        }

        if (!base.grounded)
        {

            base.Update();
        }
        else
        {
            // Retrieve all colliders we have intersected after velocity has been applied.
            base.velocity.x = 0;
        }

    }

}
