using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Menu : MonoBehaviour
{
    public GameObject[] title;
    public Language[] Btns;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Language"))        
            PlayerPrefs.SetInt("Language", 0);//portugues        
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("Language"))
        {
            SetTitle();
        }
    }

    public void SetTitle()
    {
        title[0].SetActive(false);
        title[1].SetActive(false);
        title[PlayerPrefs.GetInt("Language")].SetActive(true);

        Btns[0].SetLanguage();
        Btns[1].SetLanguage();
    }

    public void SetLanguage(int p_value)
    {
        PlayerPrefs.SetInt("Language", p_value);
        SetTitle();
    }

    public void Play()
    {
        SceneManager.LoadScene(1);

        if (PlayerPrefs.HasKey("Fase1"))
            PlayerPrefs.SetInt("Fase1", 0);
        if (PlayerPrefs.HasKey("Dash"))
            PlayerPrefs.SetInt("Dash", 0);
        if (PlayerPrefs.HasKey("Checkpoint"))
            PlayerPrefs.SetInt("Checkpoint", 0);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
