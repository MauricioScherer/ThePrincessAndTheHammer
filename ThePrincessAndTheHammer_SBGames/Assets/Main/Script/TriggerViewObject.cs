using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerViewObject : MonoBehaviour
{
    public GameObject[] objects;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            for(int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(!objects[i].activeSelf);
            }
        }
    }
}
