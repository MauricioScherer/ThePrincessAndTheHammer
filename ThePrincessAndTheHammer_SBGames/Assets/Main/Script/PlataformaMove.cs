using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMove : MonoBehaviour
{
    private Vector3 targetCurrent;
    private int currentPosition;
    private bool movement;

    public bool automatic;
    public float speed;
    public float downtime;
    public Transform plataform;
    public Transform[] target;

    private void Start()
    {
        if(automatic)
            movement = true;
        targetCurrent = target[0].position;
    }

    void Update()
    {
        if(automatic)
        {
            if(movement)
            {
                plataform.position = Vector3.MoveTowards(plataform.position, targetCurrent, speed * Time.deltaTime);

                if (plataform.position == targetCurrent)
                {
                    movement = false;
                    Invoke("SetTargetAutomatic", downtime);
                }
            }
        }
    }

    private void SetTargetAutomatic()
    {
        movement = true;
        currentPosition = currentPosition == 0 ? 1 : 0;
        targetCurrent = target[currentPosition].position;
    }
}
