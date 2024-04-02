using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRespawn : MonoBehaviour
{
    public Transform playerSpawnPoint;
    public Transform player;
    public GameObject playerGameObject;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerDeath();
        }
    }

    void RespawnPlayer()
    {

        if (playerSpawnPoint != null)
        {
            playerGameObject.SetActive(false);

            // Move the player to the current spawn point
            player.position = playerSpawnPoint.position;
            player.rotation = playerSpawnPoint.rotation;

            playerGameObject.SetActive(true);
        }
        

        Debug.Log("Player respawned");

    }

    void PlayerDeath()
    {
        // Respawn the player
        RespawnPlayer();
        Debug.Log("Player has died");
    }

}
