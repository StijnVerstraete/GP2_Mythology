﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuBehaviour : MonoBehaviour
{
    public GameObject MusicButton;
    public Sprite MusicOnSprite;
    public Sprite MusicOffSprite;

    private bool _musicIsplaying = true;
    [SerializeField]
    private AudioSource _audio;

    private void Start()
    {
        if (PlayerPrefs.GetInt("IsMusicPlaying") == 1)
        {
            MusicButton.GetComponent<Image>().sprite = MusicOnSprite;
            _audio.Play();
        }
        else
        {
            MusicButton.GetComponent<Image>().sprite = MusicOffSprite;
            _audio.Stop();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MuteUnmuteSound()
    {
        //you can play or stop playing music
        _musicIsplaying = !_musicIsplaying;

        if (_musicIsplaying)
        {
            PlayerPrefs.SetInt("IsMusicPlaying", 1);
            MusicButton.GetComponent<Image>().sprite = MusicOnSprite;
            _audio.Play();
        }
        else
        {
            PlayerPrefs.SetInt("IsMusicPlaying", 0);
            MusicButton.GetComponent<Image>().sprite = MusicOffSprite;
            _audio.Stop();
        }
    }

    public void ChangeCurrentPanel(GameObject currentPanel)
    {
        currentPanel.SetActive(false);
    }

    public void ChangeToNewPanel(GameObject newPanel)
    {
        newPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
