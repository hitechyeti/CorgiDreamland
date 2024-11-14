using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusicLoop : MonoBehaviour
{

    //Sounds
    private AudioSource _audioSource;
    public float musicSetVolume;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnGameStart()
    {
        if (FindObjectOfType<GameManager>().musicOn == 1)
        {
            musicSetVolume = FindObjectOfType<GameManager>().musicVol;
            musicSetVolume /= 10;
            _audioSource.volume = musicSetVolume;
            _audioSource.Play();
        }
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }

    public void PauseMusic()
    {
        _audioSource.Pause();
    }

    public void UnPauseMusic()
    {
        _audioSource.UnPause();
    }

}
