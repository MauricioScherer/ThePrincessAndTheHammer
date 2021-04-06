using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger2 : MonoBehaviour
{
    private Vector3 targetCurrent;
    private int currentPosition;
    private bool movement = true;

    public bool delayStart = false;
    public float delay;
    public float speedUp;
    public float speedDown;
    public float downtimeUp;
    public float downtimeDown;
    public Transform plataform;
    public Transform[] target;
    public AudioSource hit;
    public GameObject alert;
    public Collider triggerDamage;

    private void Start()
    {
        if (delayStart)
        {
            movement = false;
            Invoke("StartMovement", delay);
        }
        else
        {
            movement = true;
        }

        targetCurrent = target[0].position;
    }

    private void StartMovement()
    {
        movement = true;
    }

    void Update()
    {
        if (movement)
        {
            float _speed;
            _speed = currentPosition == 0 ? speedDown : speedUp;

            plataform.position = Vector3.MoveTowards(plataform.position, targetCurrent, _speed * Time.deltaTime);

            if (plataform.position == targetCurrent)
            {
                movement = false;
                if(currentPosition == 0)
                {
                    Invoke("SetTargetAutomatic", downtimeDown);
                    Invoke("ViewAlert", downtimeDown * 0.65f);
                    triggerDamage.enabled = false;
                }
                else
                {
                    triggerDamage.enabled = true;
                    Invoke("SetTargetAutomatic", downtimeUp);
                }
            }
        }
    }

    private void ViewAlert()
    {
        alert.SetActive(true);
    }

    private void SetTargetAutomatic()
    {
        movement = true;
        currentPosition = currentPosition == 0 ? 1 : 0;
        targetCurrent = target[currentPosition].position;

        if (currentPosition == 1)
        {
            hit.Play();
            alert.SetActive(false);
        }
    }
}
