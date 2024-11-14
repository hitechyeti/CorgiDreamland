using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Penguin : MonoBehaviour
{
    //Sounds
    private AudioSource _audioSource;

    [SerializeField] AudioClip _penguin1;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Penguin1()
    {
        _audioSource.clip = _penguin1;
        _audioSource.Play();
    }
}
