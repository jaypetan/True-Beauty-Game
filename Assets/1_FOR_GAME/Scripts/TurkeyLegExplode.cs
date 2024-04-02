using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurkeyLegExplode : MonoBehaviour
{
    public GameObject ham;

    public GameObject explosionEffect;
    public AudioClip explosionSound;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<PlayerHealth>().getHealth() == 100)
            {
                Destroy(ham.gameObject);
                ham.GetComponent<InteractableObject>().OutOfRange();

                //Explosion
                GameObject explosion = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);

                // Play explosion sound
                if (explosionSound != null)
                {
                    AudioSource.PlayClipAtPoint(explosionSound, transform.position);
                }
            }
        }
    }
}
