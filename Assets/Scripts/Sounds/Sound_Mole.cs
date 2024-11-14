using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Mole : MonoBehaviour
{
    //Sounds
    private AudioSource _audioSource;

    [SerializeField] AudioClip _mole1;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Mole1()
    {
        _audioSource.clip = _mole1;
        _audioSource.Play();
    }

}
