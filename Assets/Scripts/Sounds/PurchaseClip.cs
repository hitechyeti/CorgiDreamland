using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseClip : MonoBehaviour
{

    //Sounds
    private AudioSource _audioSource;

    [SerializeField] AudioClip _purchase1;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PurchaseSFX()
    {
        _audioSource.clip = _purchase1;
        _audioSource.Play();
    }

}
