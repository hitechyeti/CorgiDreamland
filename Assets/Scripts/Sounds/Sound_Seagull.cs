using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Seagull : MonoBehaviour
{

    //Sounds
    private AudioSource _audioSource;

    [SerializeField] AudioClip _seagull1;
    [SerializeField] AudioClip _seagull2;
    [SerializeField] AudioClip _seagull3;
    [SerializeField] AudioClip _seagullStanding;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Seagull1()
    {
        _audioSource.clip = _seagull1;
        _audioSource.Play();
    }

    public void Seagull2()
    {
        _audioSource.clip = _seagull2;
        _audioSource.Play();
    }

    public void Seagull3()
    {
        _audioSource.clip = _seagull3;
        _audioSource.Play();
    }

    public void SeagullStanding()
    {
        _audioSource.clip = _seagullStanding;
        _audioSource.Play();
    }

}
