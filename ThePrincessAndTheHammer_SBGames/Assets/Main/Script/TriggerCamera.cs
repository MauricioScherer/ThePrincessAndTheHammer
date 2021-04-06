using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCamera : MonoBehaviour
{
    private bool move;

    public float speed;
    public Transform conjCamera;
    public Transform target;
    public AudioSource audioMove;

    private void Update()
    {
        if(move)
        {
            conjCamera.position = Vector3.MoveTowards(conjCamera.position, target.position, speed * Time.deltaTime);

            if(conjCamera.position == target.position)
            {
                move = false;
                //Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (conjCamera.position != target.position)
            {
                move = true;
                audioMove.Play();
            }

            //GetComponent<Collider>().enabled = false;
        }
    }
}
