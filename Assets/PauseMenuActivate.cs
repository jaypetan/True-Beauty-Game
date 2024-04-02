using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuActivate : MonoBehaviour
{
    public PauseMenu pauseMenu;
        
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseMenu.Pause();
        }
    }
}
