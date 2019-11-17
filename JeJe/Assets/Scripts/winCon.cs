using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winCon : MonoBehaviour
{
    public GameManager1 gameManager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.winGame();
    }
}
