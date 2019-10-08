using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonePhysics : MonoBehaviour
{

    public Rigidbody2D boneBody;
    public float startForce = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        boneBody.freezeRotation = true;
        boneBody.AddForce(new Vector2(-2*startForce, startForce), ForceMode2D.Force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
