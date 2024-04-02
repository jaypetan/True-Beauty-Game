using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactions;

    public GameObject PromptText;

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            if( Input.GetKeyDown(interactKey))
            {
                interactions.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InRange();
            Debug.Log("Player is in range");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            OutOfRange();
            Debug.Log("Player is out of range");
        }
    }

    public void InRange()
    {
        isInRange = true;
        PromptText.SetActive(true);
    }

    public void OutOfRange()
    {
        isInRange = false;
        PromptText.SetActive(false);
    }
}
