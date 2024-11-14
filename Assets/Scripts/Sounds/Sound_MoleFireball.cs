using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_MoleFireball : MonoBehaviour
{
    //Sounds
    private AudioSource _audioSource;

    [SerializeField] AudioClip _moleFireball1;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void MoleFireball1()
    {
        _audioSource.clip = _moleFireball1;
        _audioSource.Play();
    }
}
