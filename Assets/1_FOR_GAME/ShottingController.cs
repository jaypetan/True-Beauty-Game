using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform playerCamera;
    public float shootRate;
    public float shootForce;
    private float m_shootRateTimeStamp;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (playerCamera != null)
        {
            // If you're using a first-person setup, you might want to spawn bullets at the camera's position
            // For third-person, you might want to adjust the spawn position based on your game's requirements
            Vector3 spawnPosition = playerCamera.position + playerCamera.forward*2f;

            if (Input.GetMouseButtonDown(0))
            {
                if (Time.time > m_shootRateTimeStamp)
                {
                    GameObject bullet = Instantiate(bulletPrefab, spawnPosition, playerCamera.rotation);

                    Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

                    bulletRigidbody.velocity = playerCamera.forward * shootForce;

                    m_shootRateTimeStamp = Time.time + shootRate; // update time stamp to avoid shooting too fast

                }
            }
        }

    }
}
