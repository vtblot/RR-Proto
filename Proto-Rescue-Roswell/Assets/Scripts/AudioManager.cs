using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    string scene;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    // Use this for initialization
    void Start () {
        /*if(GameManager.instance.currentScene == "LaserRoom")
        {
            Play("LaserSound");
        }*/
        scene = SceneManager.GetActiveScene().name;
        if (scene == "StartMenu")
        {
            Play("Theme");
        }


    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Son:" + name + "pas trouvé !");
            return;
        }
            
        s.source.Play();
    }
}
