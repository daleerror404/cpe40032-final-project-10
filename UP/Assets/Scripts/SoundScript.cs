﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundScript : MonoBehaviour
{
    private Music music;
    public Button musicTogglebutton;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;



    // Start is called before the first frame update
    void Start()
    {
        music = GameObject.FindObjectOfType<Music>();
        UpdateIcon();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseMusic()
    {
        music.ToggleSound();
        UpdateIcon();
    }

    void UpdateIcon()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            AudioListener.volume = 1;
            musicTogglebutton.GetComponent<Image>().sprite = musicOnSprite;
        }
        else
        {
            AudioListener.volume = 0;
            musicTogglebutton.GetComponent<Image>().sprite = musicOffSprite;
        }
    }
}

