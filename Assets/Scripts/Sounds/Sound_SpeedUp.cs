using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_SpeedUp : MonoBehaviour
{

    //Sounds
    private AudioSource _audioSource;

    [SerializeField] AudioClip _speedUp1;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _speedUp1;
    }

    public void SpeedUp1()
    {
        _audioSource.Play();
    }

}
