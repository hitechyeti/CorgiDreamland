using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Dash : MonoBehaviour
{

    //Sounds
    private AudioSource _audioSource;

    [SerializeField] AudioClip _dash1;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _dash1;
    }

    public void Dash1()
    {
        _audioSource.Play();
    }

}
