using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_Hats : MonoBehaviour
{
    Animator hat_anim;
    public int hat_num;

    // Start is called before the first frame update
    void Awake()
    {
        hat_num = FindObjectOfType<GameManager>().hatNum;
        hat_anim = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hat_num = FindObjectOfType<GameManager>().hatNum;

        hat_anim.SetInteger("HatNumber", hat_num);
    }
}
