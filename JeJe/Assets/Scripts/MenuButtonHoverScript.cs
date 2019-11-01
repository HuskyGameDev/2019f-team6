using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonHoverScript : MonoBehaviour
{
    private Color startcolor;
    Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }
    void OnMouseEnter()
    {
        Debug.Log("mouse enter");
        startcolor = rend.material.color;
        rend.material.color = startcolor + new Color(0.1f, 0.1f, 0.1f);
    }
    void OnMouseExit()
    {
        Debug.Log("mouse enter");
        rend.material.color = startcolor;
    }
}
