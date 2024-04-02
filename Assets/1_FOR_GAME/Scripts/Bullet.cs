using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosionEffect;
    public AudioClip explosionSound;
    public float life = 3;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the object with the specific tag
            Destroy(collision.gameObject);

            //Explosion
            GameObject explosion = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);
            
                // Play explosion sound
            if (explosionSound != null)
            {
                AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            }

        }

        Destroy(gameObject);
    }
}
