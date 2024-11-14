using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_BrickBreak : MonoBehaviour
{

    //Sounds
    private AudioSource _audioSource;

    [SerializeField] AudioClip _brickBreak1;
    [SerializeField] AudioClip _brickBreak2;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void BrickBreak1()
    {
        _audioSource.clip = _brickBreak1;
        _audioSource.Play();
    }

    public void BrickBreak2()
    {
        _audioSource.clip = _brickBreak2;
        _audioSource.Play();
    }

}
