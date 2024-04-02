using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private Spawner spawner;
    private bool hasCollided = false;

    // Set the reference to the Spawner
    public void SetSpawner(Spawner _spawner)
    {
        spawner = _spawner;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasCollided && collision.gameObject.CompareTag("Bullet"))
        {
            // Set the flag to true to avoid multiple calls
            hasCollided = true;

            // Check if a Spawner is attached and call SpawnObject
            if (spawner != null)
            {
                spawner.SpawnObject();
            }
        }
    }
}
