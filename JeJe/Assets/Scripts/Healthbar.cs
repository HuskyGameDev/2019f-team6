using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    
    public const int maxHealth = 4; // Max health
    public static int numHeads; // Num heads on screen
    public int tempHeads;
    public bool changeHeads = false;
    int hits=0;
    public AudioClip hurtClip;

    public AudioSource hurtSource;
    public Image[] heads;
    public Sprite JeHead;

    // Start is called before the first frame update
    void Start()
    {
        numHeads = maxHealth;
        tempHeads = numHeads;
        hurtSource.clip = hurtClip;

    }

    // Update is called once per frame
    void Update()
    {
        if (tempHeads != numHeads)
        {
            hurtSource.Play();
            tempHeads = numHeads;


        }
        hits = 0;
        for (int i = 0; i < heads.Length; i++)
        {
            if (i < maxHealth)
            {
                
                heads[i].sprite = JeHead;
            }

            if (i < numHeads)
            {
                heads[i].enabled = true;
            }
            else
            {
                heads[i].enabled = false;
            }
            if (heads[i].enabled == false) {
                hits=hits+1;
            }
        }

        if (hits == maxHealth) {
            FindObjectOfType<GameManager1>().endGame();
        }
    }
}
