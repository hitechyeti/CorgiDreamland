using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_CannonPirates : MonoBehaviour
{

    //Sounds
    private AudioSource _audioSource;

    [SerializeField] AudioClip _pirateCannonBoom;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PirateCannonBoom()
    {
        _audioSource.clip = _pirateCannonBoom;
        _audioSource.Play();
    }

}
