using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Crash : MonoBehaviour
{

    //Sounds
    private AudioSource _audioSource;

    [SerializeField] AudioClip _crash1;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _crash1;
    }

    public void Crash1()
    {
        _audioSource.Play();
    }

}
