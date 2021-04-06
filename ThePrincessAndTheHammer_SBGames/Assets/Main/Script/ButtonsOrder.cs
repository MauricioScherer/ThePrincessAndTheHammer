using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsOrder : MonoBehaviour
{
    private bool error;
    public Button[] btns;
    public Animator machineAnim;
    public Animator conjFinal;
    public AudioSource machine;

    public AudioSource feedbackAudio;
    public AudioClip[] feedbackClip;

    public ManagerFinalLevel managerFinalLvl;

    public void CheckOrder()
    {
        int status = 0;

        for (int i = 1; i < btns.Length; i++)
        {
            if(btns[i].GetIsClicked() && !btns[i - 1].GetIsClicked())
            {
                error = true;
                for (int j = 0; j < btns.Length; j++)
                {
                    btns[j].ErrorBtn();
                }
                break;
            }
        }

        if(!error)
        {
            feedbackAudio.clip = feedbackClip[0];
            feedbackAudio.Play();
        }
        else
        {
            feedbackAudio.clip = feedbackClip[1];
            feedbackAudio.Play();
            error = false;
        }


        for (int i = 0; i < btns.Length; i++)
        {
            if (btns[i].GetIsClicked())
                status++;
        }

        if(status == btns.Length)
        {
            if(!managerFinalLvl)
            {
                machineAnim.enabled = false;
                conjFinal.enabled = true;
                machine.Stop();
            }
            else
            {
                foreach(Button p_obj in btns)
                    p_obj.GetComponent<Collider>().enabled = false;

                managerFinalLvl.Shoot();
            }
        }
    }
}
