using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public int health = 4;
    public int numHeads = 4;

    public Image[] heads;
    public Sprite JeHead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < heads.Length; i++)
        {
            if (i < health)
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
