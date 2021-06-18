using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDeathAudio : MonoBehaviour
{
   public AudioSource audioSource;

   
    void PlayAudio()
    {
        audioSource.Play();
    }
}
