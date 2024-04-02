using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Scrollbar scrollbar;
    public float minSensitivity = 0.1f; // Minimum sensitivity
    public float maxSensitivity = 10f; // Maximum sensitivity

    // Reference to the PlayerLook script that controls camera rotation
    public PlayerLook playerLook;

    void Start()
    {
        // Get the Scrollbar component attached to this GameObject
        scrollbar = GetComponent<Scrollbar>();

        // Get the PlayerLook script attached to the player GameObject
        playerLook = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLook>();

        if (scrollbar != null && playerLook != null)
        {
            // Subscribe to the scrollbar's onValueChanged event
            scrollbar.onValueChanged.AddListener(OnScrollbarValueChanged);
        }
        else
        {
            Debug.LogError("Scrollbar component or PlayerLook script not found.");
        }
    }

    void OnScrollbarValueChanged(float value)
    {
        // Map the scrollbar's value to the sensitivity range
        float sensitivity = Mathf.Lerp(minSensitivity, maxSensitivity, value);

        // Set the sensitivity in the PlayerLook script
        playerLook.xSensitivity = sensitivity;
        playerLook.ySensitivity = sensitivity;
    }
}
