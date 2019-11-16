using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    public const int maxHealth = 4; // Max health
    public static int numHeads; // Num heads on screen
    int hits=0;

    public Image[] heads;
    public Sprite JeHead;

    

    // Start is called before the first frame update
    void Start()
    {
        numHeads = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
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
