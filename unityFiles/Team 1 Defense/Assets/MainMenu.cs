using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string level1 = "Level 1";
    public void Play()
    {
        Debug.Log("Play");
        SceneManager.LoadScene(level1);
    }

    public void Settings()
    {
        Debug.Log("Settings");
    }

    public void Quit()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }
}
