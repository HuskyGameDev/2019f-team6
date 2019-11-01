using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    AudioSource src;

    public void SetVolume(float volume)
    {
        src.volume = (Mathf.Log10(volume + 0.1f) + 1) / (Mathf.Log10(1.1f) + 1);
            Debug.Log(volume+", "+src.volume);
        
    }


    // Start is called before the first frame update
    void Start()
    {
        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
