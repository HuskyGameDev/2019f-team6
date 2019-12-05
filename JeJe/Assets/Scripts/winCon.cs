using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winCon : MonoBehaviour
{
    public GameManager1 gameManager;
    public GameObject player;
    public GameObject daddy;
    public int tally=0;
    void Update() {

        if (player.transform.position.x>=18) {
            gameManager.winGame();
        }
        if (player.transform.position.y < -11) {
            gameManager.endGame();
        }
    }

  
}
