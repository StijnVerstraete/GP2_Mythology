using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteMusic : MonoBehaviour
{
    
    public Sprite MusicOnSprite;
    public Sprite MusicOffSprite;

    private bool _musicIsplaying = true;
    [SerializeField]
    private AudioSource _audio;
    [SerializeField]
    private Image _musicButton;
    

    private void Start()
    {
        if (PlayerPrefs.GetInt("IsMusicPlaying") == 1)
        {
            _musicButton.GetComponent<Image>().sprite = MusicOnSprite;
            _audio.Play();
        }
        else
        {
            _musicButton.GetComponent<Image>().sprite = MusicOffSprite;
            _audio.Stop();
        }
    }
    
    public void MuteUnmuteSound()
    {
        //you can play or stop playing music
        _musicIsplaying = !_musicIsplaying;

        if (_musicIsplaying)
        {
            PlayerPrefs.SetInt("IsMusicPlaying", 1);
            _musicButton.GetComponent<Image>().sprite = MusicOnSprite;
            _audio.Play();
        }
        else
        {
            PlayerPrefs.SetInt("IsMusicPlaying", 0);
            _musicButton.GetComponent<Image>().sprite = MusicOffSprite;
            _audio.Stop();
        }
    }
}
