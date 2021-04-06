using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDash : MonoBehaviour
{
    public GameObject power;
    public AudioSource sound;

    public Animator estrutura;
    public AudioSource soundEstrutura;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GetComponent<Collider>().enabled = false;
            other.GetComponent<Player>().GetPowerUpDash();
            estrutura.enabled = true;
            soundEstrutura.Play();
            power.SetActive(false);
            sound.Play();
        }
    }
}
