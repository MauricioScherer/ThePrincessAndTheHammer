using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBlade : MonoBehaviour
{
    public AudioSource sound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (!sound.isPlaying)
                sound.Play();
            else
                sound.Stop();
        }
    }
}
