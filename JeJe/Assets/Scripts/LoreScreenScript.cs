using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoreScreenScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey) // start game (Enter)
        {
            SceneManager.LoadScene("Main Scene"); // name of the first scene we want to pull up 
        }
        if (Input.GetButtonDown("Cancel")) // exit game (Escape)
        {
            SceneManager.LoadScene("Menu");
        }
    }

 }
