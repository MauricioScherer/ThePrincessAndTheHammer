using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ManagerHistory : MonoBehaviour
{
    private int status;

    public VideoPlayer video;
    private int counterframe = 0;
    public float[] frames;
    public GameObject[] legendaPor;
    public GameObject[] legendaEng;

    void Start()
    {
        status = PlayerPrefs.GetInt("Language");
    }

    // Update is called once per frame
    void Update()
    {
        if(status == 0) //portugues
        {
            if(counterframe < frames.Length)
            {
                if (video.frame == frames[counterframe])
                {
                    print(counterframe);

                    if (!legendaPor[counterframe].activeSelf)
                    {
                        if (counterframe > 0)
                            legendaPor[counterframe - 1].SetActive(false);

                        legendaPor[counterframe].SetActive(true);
                        counterframe++;
                    }
                }
            }
        }
        else //english
        {
            if (counterframe < frames.Length)
            {
                if (video.frame == frames[counterframe])
                {
                    print(counterframe);

                    if (!legendaEng[counterframe].activeSelf)
                    {
                        if (counterframe > 0)
                            legendaEng[counterframe - 1].SetActive(false);

                        legendaEng[counterframe].SetActive(true);
                        counterframe++;
                    }
                }
            }
        }

    }
}
