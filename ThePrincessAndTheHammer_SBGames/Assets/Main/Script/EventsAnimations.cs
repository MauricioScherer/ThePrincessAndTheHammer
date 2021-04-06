using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventsAnimations : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        if(GameObject.FindGameObjectWithTag("GameManager"))
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void ReloadLevel()
    {
        gameManager.ReloadLevel();
    }

    public void DeactiveObject()
    {
        gameObject.SetActive(false);
    }

    public void LoadLevel0()
    {
        SceneManager.LoadScene(0);
    }
}
