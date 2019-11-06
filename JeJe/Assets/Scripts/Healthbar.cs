using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    public const int maxHealth = 4; // Max health
    public static int numHeads; // Num heads on screen

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
        }
    }
}
