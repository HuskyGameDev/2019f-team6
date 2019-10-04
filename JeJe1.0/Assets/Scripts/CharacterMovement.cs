using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    public float playerSpeed = 5f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float playerXScalar = Input.GetAxisRaw("Horizontal");
        Vector3 playerVector = new Vector3(playerXScalar, 0, 0);

        
        
        transform.position += playerVector * Time.deltaTime * playerSpeed;
        if(transform.position.y < -10)
        {
            SceneManager.LoadScene("Title Scene");
        }
    }
    
}
