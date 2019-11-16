using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
   void Start()
    {
        
    }
    void Update()
    {
        
        
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("LoreScene");
    }
    public void QuitGame()
    {
        //Debug.Log("quit game!");
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif 
    }
}
