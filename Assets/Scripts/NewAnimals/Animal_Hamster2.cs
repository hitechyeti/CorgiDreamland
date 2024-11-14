using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_Hamster2 : MonoBehaviour
{
    public Animator anim_hamster;
    private int randAnim;
    private int direc;
    private int speed;
    private float leftEdge;

    private int hamster_run_hash = Animator.StringToHash("Hamster_Run");

    public void Start()
    {
        anim_hamster = GetComponent<Animator>();
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        direc = 1;
        speed = 0;
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }

    public void HamsterIdle()
    {
        speed = 0;
        anim_hamster.SetBool(hamster_run_hash, false);
    }

    public void HamsterRandomAnimation()
    {
        randAnim = Random.Range(1, 4);

        if (randAnim == 1)
        {
            speed = 0;
            anim_hamster.SetBool(hamster_run_hash, false);
        }
        else if (randAnim == 2 || randAnim == 3)
        {
            if (direc == 0)
            {
                transform.localScale = new Vector2(-0.0362f, transform.localScale.y);
                direc = 1;
                speed = 8;
            }
            else
            {
                transform.localScale = new Vector2(0.0362f, transform.localScale.y);
                direc = 0;
                speed = -8;
            }
            anim_hamster.SetBool(hamster_run_hash, true);
            Invoke(nameof(HamsterIdle), 0.75f);
        }

    }
}
