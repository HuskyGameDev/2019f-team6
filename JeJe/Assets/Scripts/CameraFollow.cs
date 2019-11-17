using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{

    public Transform player;

    private Vector3 camVelocity = Vector3.zero;

    public float smoothFactor = .1f;


    public float xMin = 0;
    public float xMax = 0;


    public float yMin = 0;
    public float yMax = 0;


    // Start is called before the first frame update
    void Start()
    { 
    }


    void FixedUpdate()
    {
        Vector3 newPos = player.position;
        newPos.z = transform.position.z;

        newPos.x = Mathf.Clamp(player.position.x, xMin, xMax);
        newPos.y = Mathf.Clamp(player.position.y, yMin, yMax);

        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref camVelocity, smoothFactor);
    } 
}
