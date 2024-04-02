using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip playedSound;
    public AudioSource player;
    public void playAudio()
    {
        if (playedSound != null)
        {
            player.clip = playedSound;
            player.Play();
        }
    }
}
