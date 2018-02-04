using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectionSystem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (GameManager.instance.currentScene == "MazeScene")
            {
                other.transform.position = GameManager.instance.playerStartingPos;
                GameManager.instance.GeneratePath();
            }
            if (GameManager.instance.currentScene == "LaserRoom")
            {
                if (gameObject.tag == "XrayActivator")
                {
                        GameManager.instance.RenderXRays();
                   
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (GameManager.instance.currentScene == "LaserRoom")
            {
                if (gameObject.tag == "XrayActivator")
                {
                    GameManager.instance.HideXRays();

                }

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (GameManager.instance.currentScene == "LaserRoom")
            {
                if (gameObject.tag == "Laser")
                {
                    collision.gameObject.transform.position = GameManager.instance.playerStartingPos;
                }
            }
        }
    }
}
