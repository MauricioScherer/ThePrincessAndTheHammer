using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneFinal : MonoBehaviour
{
    public GameObject btnQuit;

    public GameObject[] objsLanguage;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if(objsLanguage.Length > 0)
        {
            objsLanguage[PlayerPrefs.GetInt("Language")].SetActive(true);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            btnQuit.SetActive(true);
        }
    }
}
