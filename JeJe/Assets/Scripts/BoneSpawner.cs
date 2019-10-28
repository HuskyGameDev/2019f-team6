using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneSpawner : MonoBehaviour
{


    private float nextSpawn = 0;

    public GameObject bonePrefab;
    public float spawnDelay = 3;




    // Start is called before the first frame update
    void Start()
    {
    

    }

    // Update is called once per frame
    void Update()
    {
        nextSpawn += Time.deltaTime;
        //Debug.Log(nextSpawn);
        if (nextSpawn >= spawnDelay)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        nextSpawn = 0;
        bonePrefab = Instantiate(Resources.Load("Prefabs/Bone") as GameObject, transform.position, transform.rotation);
        bonePrefab.GetComponent<BonePhysics>().setVelocityTowardPlayer();

    }
}
