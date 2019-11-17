using UnityEngine;
using UnityEngine.SceneManagement;

public class winCondition : MonoBehaviour
{
    public GameManager1 gameManager;
    void OnTriggerEnter()
    {
        gameManager.winGame();
    }
}
