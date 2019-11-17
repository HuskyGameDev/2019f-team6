using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundParallax : MonoBehaviour
{

    public Transform backgroundParent;

    private Transform[] backgrounds;
    private float[] parallaxScales;

    public float parallaxMagnitude = 2f;
    public float interpolateScale = 0.5f;

    private Transform camTransform;

    private Vector3 prevCamPos;

    private int numBackgrounds = 0;

 



    // Start is called before the first frame update
    void Start()
    {
        camTransform = Camera.main.transform;
        prevCamPos = camTransform.position;


        backgrounds = backgroundParent.GetComponentsInChildren<Transform>();

        numBackgrounds = backgrounds.Length;

        parallaxScales = new float[numBackgrounds];

        for(int i = 0; i < numBackgrounds; i++) {
            parallaxScales[i] = backgrounds[i].position.z * -parallaxMagnitude;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for(int i = 0; i < numBackgrounds; i++)
        {
            //float parallaxOffset = (prevCamPos.x - camTransform.position.x) * parallaxScales[i];

            //float newPosX = backgrounds[i].position.x + parallaxOffset;

            //Vector3 newPos = new Vector3(newPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            Vector3 parallaxOffset = (prevCamPos - camTransform.position) * parallaxScales[i];

            parallaxOffset.z = 0;

            Vector3 newPos = backgrounds[i].position + parallaxOffset;


            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, newPos, interpolateScale * Time.deltaTime);
        }


        prevCamPos = camTransform.position;
    }
}
