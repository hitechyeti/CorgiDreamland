using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShield : MonoBehaviour
{
    Animator shield_anim;

    public bool dashing;

    // Start is called before the first frame update
    void Start()
    {
        shield_anim = gameObject.GetComponent<Animator>();
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
                    shield_anim.SetTrigger("Break");
                    FindObjectOfType<Sound_ShieldBreak>().ShieldBreak1();
                }
            }
            else
            {
                if (FindObjectOfType<Player_Controller>().isAlive == true)
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

    public void DestroyShieldObject()
    {
        Destroy(gameObject);
    }
}
