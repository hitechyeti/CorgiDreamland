using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_Owl : MonoBehaviour
{
    public Animator anim_owl;
    private int randAnim;
    private float leftEdge;

    private bool onScreen;

    private int owl_idle_hash = Animator.StringToHash("Owl_Idle");
    private int owl_sleep_hash = Animator.StringToHash("Owl_Sleep");
    private int owl_rotatehead_hash = Animator.StringToHash("Owl_RotateHead");
    private int owl_sad_hash = Animator.StringToHash("Owl_Sad");

    public void Start()
    {
        onScreen = false;
        anim_owl = GetComponent<Animator>();
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }

    }

    private void OnBecameVisible()
    {
        onScreen = true;
    }

    private void OnBecameInvisible()
    {
        onScreen = false;
    }

    public void OwlIdle()
    {
        anim_owl.SetTrigger(owl_idle_hash);
    }

    public void OwlSleep()
    {
        anim_owl.SetTrigger(owl_sleep_hash);
    }

    public void OwlRandomAnimation()
    {
        randAnim = Random.Range(1, 3);

        if (randAnim == 1)
        {
            anim_owl.SetTrigger(owl_rotatehead_hash);
            if (onScreen)
            {
                FindObjectOfType<Sound_Owl>().OwlHoot1();
            }
        }
        else if (randAnim == 2)
        {
            anim_owl.SetTrigger(owl_sad_hash);
        }
        
    }
}
