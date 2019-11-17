using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundParallax : MonoBehaviour
{

    public Transform background;
    private float parallaxScale;

    public float parallaxMagnitude = 10;

    private Transform camTransform;

    private Vector3 prevCamPos;



    // Start is called before the first frame update
    void Start()
    {
        camTransform = Camera.main.transform;
        prevCamPos = camTransform.position;

        parallaxScale = background.position.z * -parallaxMagnitude;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float parallaxOffset = (prevCamPos.x - camTransform.position.x) * parallaxScale;

        float newPosX = background.position.x + parallaxOffset;

        Vector3 newPos = new Vector3(newPosX, background.position.y, background.position.z);

        background.position = Vector3.Lerp(background.position, newPos, 0.5f * Time.deltaTime);

        prevCamPos = camTransform.position;
    }
}
