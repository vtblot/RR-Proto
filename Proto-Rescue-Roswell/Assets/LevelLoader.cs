using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

    public GameObject loadingScreen;
    public Slider slider;

    private void Start()
    {
        if (Time.timeScale == 0f)
            Time.timeScale = 1f;

    }

    public void LoadLevel(string sceneName)
    {
        FindObjectOfType<AudioManager>().Play("Bouton");
        StartCoroutine(LoadAsync(sceneName));
    }

    IEnumerator LoadAsync(string sceneName)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
        float progress;
        loadingScreen.SetActive(true);
        while (!op.isDone)
        {
            progress = Mathf.Clamp01(op.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
