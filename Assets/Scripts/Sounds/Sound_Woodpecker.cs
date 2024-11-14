using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Woodpecker : MonoBehaviour
{
    //Sounds
    private AudioSource _audioSource;

    [SerializeField] AudioClip _woodpecker1;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Woodpecker1()
    {
        _audioSource.clip = _woodpecker1;
        _audioSource.Play();
    }
}
