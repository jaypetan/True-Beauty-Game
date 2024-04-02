using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoostIcon : MonoBehaviour
{
    public GameObject UIimage;
    private bool isActive = false;

    public void showIcon()
    {
        if (!isActive)
        {
            UIimage.SetActive(true);
            isActive = true;
            
            StartCoroutine(applyShowIcon());
        }
    }

    IEnumerator applyShowIcon()
    {   
        yield return new WaitForSeconds(10f);

        UIimage.SetActive(false);

        isActive = false;
    }
}
