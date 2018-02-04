using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private void Start()
    {
        if (Time.timeScale == 0f)
            Time.timeScale = 1f;
    }
    public void PlayLaserScene()
    {
        SceneManager.LoadScene("Scenes/LaserRoom");
    }
    public void PlayMazeScene()
    {
        SceneManager.LoadScene("Scenes/MazeScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
