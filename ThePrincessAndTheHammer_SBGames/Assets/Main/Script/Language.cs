using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    public string portuguese;
    public string english;

    void Start()
    {
        SetLanguage();
    }

    public void SetLanguage()
    {
        if (PlayerPrefs.GetInt("Language") == 0)
            GetComponent<Text>().text = portuguese;
        else
            GetComponent<Text>().text = english;
    }
}
