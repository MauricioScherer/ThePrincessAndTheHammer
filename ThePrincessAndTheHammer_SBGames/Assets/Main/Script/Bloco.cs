using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour
{
    private int status;

    public bool metal;
    public Material materialInpact;

    public void Impact()
    {
        if (status == 0)
        {
            GetComponent<MeshRenderer>().material = materialInpact;
            status++;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
