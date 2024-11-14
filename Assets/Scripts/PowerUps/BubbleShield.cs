using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleShield : MonoBehaviour
{

    public Animator bubble_anim;

    // Start is called before the first frame update
    void Start()
    {
        bubble_anim = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hydrant")
        {
            bubble_anim.SetTrigger("Pop");
        }
        else if (collision.gameObject.tag == "Cannonball")
        {
            bubble_anim.SetTrigger("Pop");
        }
    }

    public void PopBubble()
    {
        FindObjectOfType<Player_Controller>().bubbleShield = false;
        Destroy(gameObject);
    }

    public void PopBubbleSFX()
    {
        FindObjectOfType<Sound_Bubble>().BubblePop();
    }

}
