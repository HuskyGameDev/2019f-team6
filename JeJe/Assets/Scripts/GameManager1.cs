
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager1 : MonoBehaviour
{
    public void endGame() {
        SceneManager.LoadScene("Lose Scene");
    }
    public void winGame()
    { 
    }
    }
