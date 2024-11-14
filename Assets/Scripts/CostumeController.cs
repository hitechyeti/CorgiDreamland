using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostumeController : MonoBehaviour
{

    public Animator costume_anim;


    // Start is called before the first frame update
    void Start()
    {
        costume_anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
