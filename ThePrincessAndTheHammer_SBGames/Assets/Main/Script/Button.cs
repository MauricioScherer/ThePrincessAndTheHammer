using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private bool isClicked;

    public ButtonsOrder btnOrder;
    public Material[] matButton;
    public Transform[] posButton;
    public MeshRenderer btnMesh;
    public Transform btnTransform;
    public AudioSource btnSound;

    public void ImpactButton()
    {
        if (!isClicked)
            DragBtn();
        else
            DropBtn();
        btnSound.Play();
    }

    public void DragBtn()
    {
        btnMesh.material = matButton[1];
        btnTransform.position = posButton[1].position;
        isClicked = true;
        btnOrder.CheckOrder();
    }

    public void DropBtn()
    {
        btnMesh.material = matButton[0];
        btnTransform.position = posButton[0].position;
        isClicked = false;
    }

    public void ErrorBtn()
    {
        btnMesh.material = matButton[2];
        btnTransform.position = posButton[0].position;
        isClicked = false;

        Invoke("DropBtn", 0.6f);
    }

    public bool GetIsClicked()
    {
        return isClicked;
    }
}
