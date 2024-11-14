using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_DogEating : MonoBehaviour
{

    //Sounds
    private AudioSource _audioSource;

    [SerializeField] AudioClip _dogEating1;
    [SerializeField] AudioClip _dogEating2;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void DogEating1()
    {
        _audioSource.clip = _dogEating1;
        _audioSource.Play();
    }

    public void DogEating2()
    {
        _audioSource.clip = _dogEating2;
        _audioSource.Play();
    }

}
