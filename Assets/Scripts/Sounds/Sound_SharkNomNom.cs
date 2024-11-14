using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_SharkNomNom : MonoBehaviour
{

    //Sounds
    private AudioSource _audioSource;
    private int ranSharkSound;

    [SerializeField] AudioClip _sharkNomNom1;
    [SerializeField] AudioClip _sharkNomNom2;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void SharkNomNom1()
    {
        _audioSource.clip = _sharkNomNom1;
        _audioSource.Play();
    }

    public void SharkNomNom2()
    {
        _audioSource.clip = _sharkNomNom2;
        _audioSource.Play();
    }

    public void SharkRandomNom()
    {
        ranSharkSound = Random.Range(1, 2);

        if (ranSharkSound == 1)
        {
            SharkNomNom1();
        }
        else if (ranSharkSound == 2)
        {
            SharkNomNom2();
        }
    }

}
