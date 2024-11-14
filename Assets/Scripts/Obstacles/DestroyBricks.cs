using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBricks : MonoBehaviour
{
    BoxCollider2D hitbox;

    Animator brick_anim;

    public bool dashing;

    // Start is called before the first frame update
    void Start()
    {
        brick_anim = gameObject.GetComponent<Animator>();
        hitbox = gameObject.GetComponent<BoxCollider2D>();
        dashing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<Player_Controller>().pause == 0)
        {
            dashing = FindObjectOfType<Player_Controller>().dashing;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (dashing == true)
            {
                if (FindObjectOfType<Player_Controller>().isAlive == true)
                {
                    //gameObject.tag = "Brick";
                    FindObjectOfType<Player_Controller>().isBrickImmune = true;
                    Destroy(hitbox);
                    brick_anim.SetTrigger("Break");
                    FindObjectOfType<Sound_BrickBreak>().BrickBreak1();
                }
            }
            else
            {
                if (FindObjectOfType<Player_Controller>().isAlive == true)
                {
                    if (FindObjectOfType<Player_Controller>().isBrickImmune == false)
                    {
                        if (FindObjectOfType<Player_Controller>().bubbleShield == true)
                        {
                            FindObjectOfType<BubbleShield>().bubble_anim.SetTrigger("Pop");
                        }
                        FindObjectOfType<GameManager>().StartGameOver();
                        FindObjectOfType<Player_Controller>().CorgiCloudGameover();
                    }
                }
            }
        }
    }

    public void DestroyBrick()
    {
        Destroy(gameObject);
        FindObjectOfType<Player_Controller>().isBrickImmune = false;
    }

}
