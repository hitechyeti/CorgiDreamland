using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_ActivePirates : MonoBehaviour
{

    //Sounds
    private AudioSource _audioSource;

    [SerializeField] AudioClip _pirateOyStopThat1;

    [SerializeField] AudioClip _pirateCannonBoom;
    [SerializeField] AudioClip _pirateArrr;
    [SerializeField] AudioClip _pirateAttack1;
    [SerializeField] AudioClip _pirateCannons1;
    [SerializeField] AudioClip _pirateCannons2;
    [SerializeField] AudioClip _pirateFire1;
    [SerializeField] AudioClip _pirateFire2;

    [SerializeField] AudioClip _pirateGetThat1;
    [SerializeField] AudioClip _pirateGetThat2;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PirateOyStopThat1()
    {
        _audioSource.clip = _pirateOyStopThat1;
        _audioSource.Play();
    }

    public void PirateCannonBoom()
    {
        _audioSource.clip = _pirateCannonBoom;
        _audioSource.Play();
    }

    public void PirateArrr()
    {
        _audioSource.clip = _pirateArrr;
        _audioSource.Play();
    }

    public void PirateAttack1()
    {
        _audioSource.clip = _pirateAttack1;
        _audioSource.Play();
    }

    public void PirateCannons1()
    {
        _audioSource.clip = _pirateCannons1;
        _audioSource.Play();
    }

    public void PirateCannons2()
    {
        _audioSource.clip = _pirateCannons2;
        _audioSource.Play();
    }

    public void PirateFire1()
    {
        _audioSource.clip = _pirateFire1;
        _audioSource.Play();
    }

    public void PirateFire2()
    {
        _audioSource.clip = _pirateFire2;
        _audioSource.Play();
    }

    public void PirateGetThat1()
    {
        _audioSource.clip = _pirateGetThat1;
        _audioSource.Play();
    }

    public void PirateGetThat2()
    {
        _audioSource.clip = _pirateGetThat2;
        _audioSource.Play();
    }

}
