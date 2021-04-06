using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Transform player;
    public Transform target;

    public GameObject objDesative;

    private void Start()
    {
        if(PlayerPrefs.GetInt("Checkpoint") == 1)
        {
            player.position = target.position;
            objDesative.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("Checkpoint", 1);
        }
    }
}
