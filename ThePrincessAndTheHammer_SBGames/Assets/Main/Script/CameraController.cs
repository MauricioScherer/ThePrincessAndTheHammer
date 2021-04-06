using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public int speed = 100;
    public Player playerScript;

    void Update()
    {
        if (Input.GetKeyDown("e") || Input.GetKeyDown("q"))
        {
            playerScript.enabled = false;
        }

        if (Input.GetKey("e"))
        {
            float turnSpeed = speed * Time.deltaTime;
            gameObject.transform.Rotate(Vector3.up * turnSpeed);
        }
        else if (Input.GetKey("q"))
        {
            float turnSpeed = -speed * Time.deltaTime;
            gameObject.transform.Rotate(Vector3.up * turnSpeed);
        }

        if(Input.GetKeyUp("e") || Input.GetKeyUp("q"))
        {
            playerScript.enabled = true;
        }
    }
}
