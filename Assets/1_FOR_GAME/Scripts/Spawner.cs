using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform player;
    public GameObject objectToSpawn; 

    void Awake()
    {
        // Example: Call the SpawnObject method at the start of the game
        SpawnObject();
    }


    public void SpawnObject()
    {
        GameObject spawnedObject = Instantiate(objectToSpawn, transform.position, transform.rotation);

        // Attach a script to handle destruction events
        ObjectDestroyer destroyer = spawnedObject.AddComponent<ObjectDestroyer>();
        destroyer.SetSpawner(this);  
       
    }
}
