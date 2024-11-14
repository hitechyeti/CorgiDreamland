using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_Penguin : MonoBehaviour
{
    public Animator anim_penguin;
    private int randAnim;
    private int direc;
    private int speed;
    private float leftEdge;

    private int penguin_walk_hash = Animator.StringToHash("Penguin_Walk");

    private bool onScreen;

    public void Start()
    {
        onScreen = false;
        anim_penguin = GetComponent<Animator>();
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        direc = Random.Range(0, 2);
        speed = 0;
    }

    private void OnBecameVisible()
    {
        onScreen = true;
    }

    private void OnBecameInvisible()
    {
        onScreen = false;
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }

    public void PenguinIdle()
    {
        speed = 0;
        anim_penguin.SetBool(penguin_walk_hash, false);
    }

    public void PenguinRandomAnimation()
    {
        randAnim = Random.Range(1, 3);

        if (randAnim == 1)
        {
            speed = 0;
            anim_penguin.SetBool(penguin_walk_hash, false);
        }
        else if (randAnim == 2)
        {
            if (direc == 0)
            {
                transform.localScale = new Vector2(0.3f, transform.localScale.y);
                direc = 1;
                speed = 2;
            }
            else
            {
                transform.localScale = new Vector2(-0.3f, transform.localScale.y);
                direc = 0;
                speed = -2;
            }
            anim_penguin.SetBool(penguin_walk_hash, true);
            if (onScreen)
            {
                FindObjectOfType<Sound_Penguin>().Penguin1();
            }
            Invoke(nameof(PenguinIdle), 1.25f);
        }

    }
}
