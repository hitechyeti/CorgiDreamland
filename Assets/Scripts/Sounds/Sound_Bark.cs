using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Bark : MonoBehaviour
{

    //Sounds
    private AudioSource _audioSource;

    [SerializeField] AudioClip _bark1;
    [SerializeField] AudioClip _bark2;
    [SerializeField] AudioClip _bark3;
    [SerializeField] AudioClip _barkGrowl1;
    [SerializeField] AudioClip _twoBarks1;
    [SerializeField] AudioClip _twoBarks2;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Bark1()
    {
        _audioSource.clip = _bark1;
        _audioSource.Play();
    }

    public void Bark2()
    {
        _audioSource.clip = _bark2;
        _audioSource.Play();
    }

    public void Bark3()
    {
        _audioSource.clip = _bark3;
        _audioSource.Play();
    }

    public void BarkGrowl1()
    {
        _audioSource.clip = _barkGrowl1;
        _audioSource.Play();
    }

    public void TwoBarks1()
    {
        _audioSource.clip = _twoBarks1;
        _audioSource.Play();
    }

    public void TwoBarks2()
    {
        _audioSource.clip = _twoBarks2;
        _audioSource.Play();
    }

}
