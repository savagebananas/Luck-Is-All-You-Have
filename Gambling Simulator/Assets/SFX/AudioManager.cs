using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "City")
        {
            PlayMusic("City Music");
        }
        if (SceneManager.GetActiveScene().name == "Casino Interior")
        {
            PlayMusic("Jazz1");
            PlayMusic("CasinoAmbience");
        }
    }

    public void PlayMusic(string name) 
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Song Not Found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("SFX Not Found");
        }
        else
        {
            if (name == "CashWin") sfxSource.time = 0.2f;
            if (name == "CashBig") sfxSource.time = 0.2f;

            sfxSource.PlayOneShot(s.clip);
        }
    }
}
