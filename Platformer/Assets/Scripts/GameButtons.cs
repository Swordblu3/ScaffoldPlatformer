﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameButtons : MonoBehaviour
{
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
    public void QuitGame()
    {
        Application.Quit();
    }
}
