using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSuccess : MonoBehaviour
{
    public void MenuButton()
    {
        SceneManager.LoadScene("Scenes/StartMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
