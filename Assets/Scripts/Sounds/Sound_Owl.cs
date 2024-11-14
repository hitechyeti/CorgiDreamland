using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Owl : MonoBehaviour
{
    //Sounds
    private AudioSource _audioSource;

    [SerializeField] AudioClip _owlHoot1;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void OwlHoot1()
    {
        _audioSource.clip = _owlHoot1;
        _audioSource.Play();
    }
}
