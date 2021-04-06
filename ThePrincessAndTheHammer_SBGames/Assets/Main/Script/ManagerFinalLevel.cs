using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerFinalLevel : MonoBehaviour
{
    private bool isAlarm;
    private int counterShoot;

    public GameManager gameManager;
    public AudioSource music;
    public AudioSource alarm;
    public GameObject alarmLamp;

    public GameObject tiro;
    public CameraShake cameraShake;
    public GameObject dust;

    private int mseg = 60;
    private string sMseg;
    private int seg = 15;
    private string sSeg;
    private int min;
    private string sMin;
    public int minStart;
    public Text timer;

    public GameObject portao;

    private void Start()
    {
        min = minStart;
        sMin = min.ToString();
        sSeg = seg.ToString();
        sMseg = mseg.ToString();
    }

    private void Update()
    {
        if(isAlarm)
        {
            mseg--;

            if (mseg < 10)
                sMseg = "0" + mseg;
            else
                sMseg = mseg.ToString();

            if (mseg == 0)
            {
                seg--;
                if (seg < 10)
                    sSeg = "0" + seg;
                else
                    sSeg = seg.ToString();
                mseg = 60;

                if(seg == 0)
                {
                    min--;
                    if (min < 10)
                        sMin = "0" + min;
                    else
                        sMin = min.ToString();

                    seg = 60;

                    if(min == -1)
                    {
                        gameManager.Dead();
                    }
                }
            }

            timer.text = sMin + ":" + sSeg + ":" + sMseg;
        }
    }

    public void Shoot()
    {
        counterShoot++;

        if(counterShoot >= 5)
        {
            portao.SetActive(false);
        }
        tiro.SetActive(true);
        dust.SetActive(true);
        StartAlarm();
        cameraShake.shakeDuration = 1.0f;
        Invoke("ResetShoot", 5.0f);
    }

    private void ResetShoot()
    {
        tiro.SetActive(false);
        dust.SetActive(false);
    }

    public void StartAlarm()
    {
        if(!isAlarm)
        {
            music.Play();
            alarm.Play();
            alarmLamp.SetActive(true);

            isAlarm = true;
        }
        
    }
}
