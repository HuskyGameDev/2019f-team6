using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCollision : MonoBehaviour
{
    public GameManager1 gameManager;

    public AudioClip MusicClip;

    //public AudioSource MusicSource;
    private BoxCollider2D boxCollider;


    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        //MusicSource.clip = MusicClip;
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, boxCollider.size, 0);

        foreach (Collider2D hit in hits)
        {
            // Ignore non bone colliders.
            if (!boxCollider.CompareTag("Bone"))  
            continue;
          
            //Destroy(hit.gameObject);
            
            //MusicSource.Play();
            Debug.Log("Boned!");
        }
        
    }
    
}
