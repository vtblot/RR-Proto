using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour {

    public static bool isGamePaused = false;
    public GameObject pauseMenuUI;
    public GameObject SuccessMenuUI;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!SuccessMenuUI.activeInHierarchy)
            {
                if (isGamePaused)
                {
                    Resume();
                }
                else
                {
                    PauseGame();
                }
            }
        }
	}

    public void Resume()
    {
        FindObjectOfType<AudioManager>().Play("Bouton");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void MenuButton()
    {
        FindObjectOfType<AudioManager>().Play("Bouton");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scenes/StartMenu");
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("Bouton");
        Application.Quit();
    }
}
