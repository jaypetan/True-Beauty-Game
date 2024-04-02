using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    public float life = 3;
    public float damage = 1;
    public bool hitObject = false; 
    void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Transform hitTransform = collision.transform;
        if (hitTransform.CompareTag("Player") && hitObject == false)
        {
            Debug.Log("HitPlayer");
            hitTransform.GetComponent<PlayerHealth>().TakeDamage(damage);
            hitObject = true;
        }
        Destroy(gameObject);
    }
}
