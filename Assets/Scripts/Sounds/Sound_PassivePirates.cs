using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_PassivePirates : MonoBehaviour
{

    //Sounds
    private AudioSource _audioSource;

    [SerializeField] AudioClip _pirateGroupApplause1;
    [SerializeField] AudioClip _pirateGroupLaugh1;
    [SerializeField] AudioClip _pirateGroupLaugh2;
    [SerializeField] AudioClip _pirateRandom1;
    [SerializeField] AudioClip _pirateRandom2;
    [SerializeField] AudioClip _pirateRandom3;
    [SerializeField] AudioClip _pirateRandom4;
    [SerializeField] AudioClip _pirateCallForAttack1;
    [SerializeField] AudioClip _pirateCallForCannons1;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PirateGroupApplause1()
    {
        _audioSource.clip = _pirateGroupApplause1;
        _audioSource.Play();
    }

    public void PirateGroupLaugh1()
    {
        _audioSource.clip = _pirateGroupLaugh1;
        _audioSource.Play();
    }

    public void PirateGroupLaugh2()
    {
        _audioSource.clip = _pirateGroupLaugh2;
        _audioSource.Play();
    }

    public void PirateRandom1()
    {
        _audioSource.clip = _pirateRandom1;
        _audioSource.Play();
    }

    public void PirateRandom2()
    {
        _audioSource.clip = _pirateRandom2;
        _audioSource.Play();
    }

    public void PirateRandom3()
    {
        _audioSource.clip = _pirateRandom3;
        _audioSource.Play();
    }

    public void PirateRandom4()
    {
        _audioSource.clip = _pirateRandom4;
        _audioSource.Play();
    }

    public void PirateCallForAttack1()
    {
        _audioSource.clip = _pirateCallForAttack1;
        _audioSource.Play();
    }

    public void PirateCallForCannons1()
    {
        _audioSource.clip = _pirateCallForCannons1;
        _audioSource.Play();
    }

}
