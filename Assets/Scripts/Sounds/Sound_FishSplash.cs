using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_FishSplash : MonoBehaviour
{

    //Sounds
    private AudioSource _audioSource;

    [SerializeField] AudioClip _fishSplash1;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void FishSplash1()
    {
        _audioSource.clip = _fishSplash1;
        _audioSource.Play();
    }

}
