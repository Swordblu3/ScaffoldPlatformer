﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameButtons : MonoBehaviour
{
    private AudioSource audio;

    private void Start()
    {
        audio = GameObject.Find("Music").GetComponent<AudioSource>();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

     public void GoToHowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    public void GoToMainMenu()
    {
       SceneManager.LoadScene("MainMenu"); 
    }
    public void GoToLevelOne()
    {
        SceneManager.LoadScene("L1");
    }
    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void Pause()
    {
        Time.timeScale = Mathf.Approximately(Time.timeScale, 0.0f) ? 1.0f : 0.0f;
        audio.mute = true;
        if (Time.timeScale > 0)
        {
            audio.mute = false;
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
