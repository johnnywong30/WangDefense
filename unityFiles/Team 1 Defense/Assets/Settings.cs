﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public string mainMenu = "MainMenu";
    public void Back()
    {
        Debug.Log("MainMenu");
        SceneManager.LoadScene(mainMenu);
    }
}
