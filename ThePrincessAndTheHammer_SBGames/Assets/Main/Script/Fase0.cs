using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Fase0 : MonoBehaviour
{
    public VideoPlayer video;

    private void Update()
    {
        if(video.frame >= 2320)
        {
            LoadLevel(2);
        }
    }

    public void LoadLevel(int p_status)
    {
        SceneManager.LoadScene(p_status);
    }
}
