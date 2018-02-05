using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class LazersPath
{
    public GameObject[] lazers;
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [HideInInspector]
    public string currentScene;

    public Transform playerPosition;
    public Vector3 playerStartingPos;
    public LazersPath[] lazersPath;
    private int nbPath;
    public Sprite[] sprites;
    public SpriteRenderer pathImage;
    public Renderer xRays;

    void Awake()
    {
        currentScene = SceneManager.GetActiveScene().name;
        if (instance == null)
            instance = this;
        if (instance != this)
            Destroy(gameObject);

        //DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        playerStartingPos = playerPosition.position;
        if (currentScene == "MazeScene")
            GeneratePath();
    }

    public void GeneratePath()
    {

        nbPath = Random.Range(0, lazersPath.Length);

        foreach (var item in lazersPath)
        {
            foreach (var lzr in item.lazers)
            {
                if (!lzr.activeInHierarchy)
                    lzr.SetActive(true);
            }
        }

        foreach (var item in lazersPath[nbPath].lazers)
        {
            item.SetActive(false);
        }
        GeneratePathSprite();
    }

    private void GeneratePathSprite()
    {
        pathImage.sprite = sprites[nbPath];
        // currentSprite = ;
    }

    public void RenderXRays()
    {
        xRays.enabled = true;
    }
    public void HideXRays()
    {
        xRays.enabled = false;
    }
}
