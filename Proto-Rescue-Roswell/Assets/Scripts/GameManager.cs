using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class LazersPath
{
    public GameObject[] lazers;
    public GameObject lastLaserForThisLevel;
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

    private Vector3 lastKnownPosition;

    public GameObject Tip;
    private float tipDisplayTimer = 3f;
    
    [HideInInspector]
    public bool playerLost = false;

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
        StartCoroutine(ShowTip());
        playerStartingPos = playerPosition.position;
        lastKnownPosition = playerPosition.position;
        nbPath = 0;
        if (currentScene == "MazeScene")
            GeneratePathSprite();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SetPlayerPosition(lastKnownPosition);
        }
    }

    public void CheckPath(GameObject md)
    {
        bool isInPath = false;

        foreach (var item in lazersPath[nbPath].lazers)
        {
            if(item == md)
            {
                isInPath = true;
                lastKnownPosition = item.transform.position;
                break;
            }
        }
        
        if(isInPath)
        {
            if(md == lazersPath[nbPath].lastLaserForThisLevel)
            {
                nbPath++;
                SetPlayerPosition(playerStartingPos);
                CheckGameEnd();
            }
        }
        else
        {
            StartCoroutine(ShowTip());
            FindObjectOfType<AudioManager>().Play("MazeDetectorImpact");
            SetPlayerPosition(playerStartingPos);
        }
    }
    
    private void CheckGameEnd()
    {
        if (lazersPath.Length == nbPath)
        {
            Debug.Log("GameFinished");
        }
        else
        {
            GeneratePathSprite();
        }
    }

    IEnumerator ShowTip()
    {
        Tip.SetActive(true);
        yield return new WaitForSeconds(tipDisplayTimer);
        Tip.SetActive(false);
    }

    private void SetPlayerPosition(Vector3 position)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = position;
    }

    private void GeneratePathSprite()
    {
        pathImage.sprite = sprites[nbPath];
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
