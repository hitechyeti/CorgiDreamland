using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_ShieldBreak : MonoBehaviour
{
    //Sounds
    private AudioSource _audioSource;

    [SerializeField] AudioClip _shield1;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _shield1;
    }

    public void ShieldBreak1()
    {
        _audioSource.Play();
    }
}
