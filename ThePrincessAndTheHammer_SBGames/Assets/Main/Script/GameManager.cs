using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    public GameObject fade;

    public GameObject Tutorial1;
    public GameObject Tutorial2;
    public GameObject pauseMenu;

    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unpaused;

    public AudioMixer masterMixer;

    private void Awake()
    {
        if(!PlayerPrefs.HasKey("Fase1"))
            PlayerPrefs.SetInt("Fase1", 0);
        if (!PlayerPrefs.HasKey("Dash"))
            PlayerPrefs.SetInt("Dash", 0);

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    private void Start()
    {
        if(PlayerPrefs.GetInt("Fase1") == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Tutorial1.SetActive(true);
            PlayerPrefs.SetInt("Fase1", 1);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
        {
            if(Tutorial1 || Tutorial2)            
                if(Tutorial1.activeSelf || Tutorial2.activeSelf)                
                    return;              
            
            Pause();
        }
    }

    public void ResetPrefab()
    {
        PlayerPrefs.SetInt("Fase1", 0);
        PlayerPrefs.SetInt("Dash", 0);
    }

    public void Dead()
    {
        fade.SetActive(true);
    }

    public void ReloadLevel()
    {
        int _current = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(_current);
    }

    public void NextLevel()
    {
        int _current = SceneManager.GetActiveScene().buildIndex;
        _current++;
        SceneManager.LoadScene(_current);
    }

    public void LoadLevel(int p_status)
    {
        SceneManager.LoadScene(p_status);
    }

    public void ViewTutorial2()
    {
        if(PlayerPrefs.GetInt("Dash") == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Tutorial2.SetActive(true);
            PlayerPrefs.SetInt("Dash", 1);
        }
    }

    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pauseMenu.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }

        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        //Lowpass();
    }

    public void ResetCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    private void Lowpass()
    {
        if(Time.timeScale == 0)
        {
            paused.TransitionTo(0.01f);
        }
        else
        {
            unpaused.TransitionTo(0.01f);
        }
    }

    public void SetSfxLvl(float sfxLvl)
    {
        masterMixer.SetFloat("SfxVol", sfxLvl);
    }
    public void SetMusicLvl(float musicLvl)
    {
        masterMixer.SetFloat("MusicVol", musicLvl);
    }
}