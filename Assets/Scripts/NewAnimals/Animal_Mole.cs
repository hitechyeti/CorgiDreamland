using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_Mole : MonoBehaviour
{
    private Animator anim_mole;
    private float leftEdge;
    private bool throwAlready;

    public GameObject prefabFireball;

    private int mole_appear_hash = Animator.StringToHash("Mole_Appear");
    private int mole_hit_hash = Animator.StringToHash("Mole_Hit");
    private int mole_throw_hash = Animator.StringToHash("Mole_Throw");
    private int mole_wait_hash = Animator.StringToHash("Mole_Wait");


    public void Start()
    {
        anim_mole = GetComponent<Animator>();
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        throwAlready = false;
    }

    private void Update()
    {

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }

    }

    void OnBecameVisible()
    {
        anim_mole.SetTrigger(mole_appear_hash);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.tag == "Player")
        {
            if (FindObjectOfType<Player_Controller>().isAlive)
            {
                anim_mole.SetTrigger(mole_hit_hash);
                FindObjectOfType<Sound_Mole>().Mole1();
            }
        }
    }

    public void MoleThrow()
    {
        anim_mole.SetTrigger(mole_throw_hash);
        if (!throwAlready)
        {
            FindObjectOfType<Sound_MoleFireball>().MoleFireball1();
            throwAlready = true;
        }
    }

    public void MoleWait()
    {
        anim_mole.SetTrigger(mole_wait_hash);
    }

    private void ThrowFireball()
    {
        
        GameObject fireball = Instantiate(prefabFireball, transform.position, Quaternion.identity);
        fireball.transform.position += Vector3.left * Random.Range(0.5f, 0.5f);
    }

}
