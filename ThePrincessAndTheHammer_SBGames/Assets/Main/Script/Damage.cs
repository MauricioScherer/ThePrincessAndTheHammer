using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject death;
    public Transform deathPosition;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            Instantiate(death, deathPosition.position, new Quaternion(0,0,0,1));
            Invoke("Reload", 2.0f);
        }
    }

    private void Reload()
    {
        gameManager.Dead();
    }
}
