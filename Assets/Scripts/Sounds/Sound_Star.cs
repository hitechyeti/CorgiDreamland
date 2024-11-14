using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Star : MonoBehaviour
{

    //Sounds
    private AudioSource _audioSource;

    [SerializeField] AudioClip _star1;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _star1;
    }

    public void Star1()
    {
        _audioSource.Play();
    }

}
