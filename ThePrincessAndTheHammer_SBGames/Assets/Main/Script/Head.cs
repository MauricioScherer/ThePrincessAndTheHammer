using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    private GameObject objCurrent;
    private Vector3 position;

    public Player playerScript;
    public GameObject effectImpact;

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.5f))
        {
            if(hit.collider.CompareTag("Bloco"))
            {
                if (Input.GetButtonDown("Jump") && playerScript.GetGrounded())
                {
                    if (hit.collider.GetComponent<Bloco>())
                    {                
                        //hit.collider.GetComponent<Bloco>().Impact();
                        objCurrent = hit.collider.gameObject;
                        position = hit.point;
                        playerScript.ImpactPlayer();
                    }
                }
            }
            else if(hit.collider.CompareTag("Button"))
            {
                if (Input.GetButtonDown("Jump") && playerScript.GetGrounded())
                {
                    if (hit.collider.GetComponent<Button>())
                    {
                        objCurrent = hit.collider.gameObject;
                        position = hit.point;
                        playerScript.ImpactPlayer();
                    }
                }
            }
        }
        else if(objCurrent != null)
        {
            objCurrent = null;
        }
    }

    public void Impact()
    {
        if (objCurrent != null)
        {
            if(objCurrent.GetComponent<Bloco>())
            {
                if (!objCurrent.GetComponent<Bloco>().metal)
                    objCurrent.GetComponent<Bloco>().Impact();

                playerScript.PlaySoundImpact(objCurrent.GetComponent<Bloco>().metal);
            }
            else if (objCurrent.GetComponent<Button>())
            {
                objCurrent.GetComponent<Button>().ImpactButton();
            }

            GameObject _obj = Instantiate(effectImpact, position, new Quaternion(0, 0, 0, 0));
            Destroy(_obj, 2.0f);
        }
    }

}
