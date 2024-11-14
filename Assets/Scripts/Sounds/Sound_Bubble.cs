using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Bubble : MonoBehaviour
{

    //Sounds
    private AudioSource _audioSource;

    [SerializeField] AudioClip _bubblePop;
    [SerializeField] AudioClip _bubbleGet;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void BubblePop()
    {
        _audioSource.clip = _bubblePop;
        _audioSource.Play();
    }

    public void BubbleGet()
    {
        _audioSource.clip = _bubbleGet;
        _audioSource.Play();
    }

}
