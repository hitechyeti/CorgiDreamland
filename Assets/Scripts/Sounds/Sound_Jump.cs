using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Jump : MonoBehaviour
{

    //Sounds
    private AudioSource _audioSource;

    [SerializeField] AudioClip _jump1;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _jump1;
    }

    public void Jump1()
    {
        _audioSource.Play();
    }

}
