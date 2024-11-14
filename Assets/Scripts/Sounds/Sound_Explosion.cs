using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Explosion : MonoBehaviour
{

    //Sounds
    private AudioSource _audioSource;

    [SerializeField] AudioClip _explosion1;
    [SerializeField] AudioClip _explosion2;
    [SerializeField] AudioClip _explosion3;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Explosion1()
    {
        _audioSource.clip = _explosion1;
        _audioSource.Play();
    }

    public void Explosion2()
    {
        _audioSource.clip = _explosion2;
        _audioSource.Play();
    }

    public void Explosion3()
    {
        _audioSource.clip = _explosion3;
        _audioSource.Play();
    }

}
