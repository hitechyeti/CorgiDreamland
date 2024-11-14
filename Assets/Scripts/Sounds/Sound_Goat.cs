using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Goat : MonoBehaviour
{
    //Sounds
    private AudioSource _audioSource;

    [SerializeField] AudioClip _goat1;
    [SerializeField] AudioClip _goat2;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Goat1()
    {
        _audioSource.clip = _goat1;
        _audioSource.Play();
    }

    public void Goat2()
    {
        _audioSource.clip = _goat2;
        _audioSource.Play();
    }
}
