using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStar : MonoBehaviour
{
    public Animator star_anim;

    private CircleCollider2D hitbox;

    public bool dashing;

    private float speed;
    private float leftEdge;

    [SerializeField] private float groundCheckRadius;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private LayerMask whatIsIce;

    private bool grounded;
    private bool onIce;

    private bool falling;

    private void Start()
    {
        hitbox = gameObject.GetComponent<CircleCollider2D>();
        star_anim = gameObject.GetComponent<Animator>();
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 5f;

        speed = FindObjectOfType<Player_Controller>().speedIncrease / 3;

        dashing = false;
        falling = true;
    }

    
    private void Update()
    {
        if (falling)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }

        if (FindObjectOfType<Player_Controller>().pause == 0)
        {
            dashing = FindObjectOfType<Player_Controller>().dashing;
        }

        CheckGround();
        CheckIce();
    }

    private void CheckGround()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (grounded)
        {
            falling = false;
        }
    }

    private void CheckIce()
    {
        onIce = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsIce);
        if (onIce)
        {
            falling = false;
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
                    Destroy(hitbox);
                    star_anim.SetTrigger("Break");
                    speed = 0;
                    FindObjectOfType<GameManager>().FallingStarScore();
                    FindObjectOfType<Spawn_Hydrants>().IncreaseComboScoreVisual();
                    FindObjectOfType<Sound_Star>().Star1();
                }
            }
            /*
            else
            {
                if (FindObjectOfType<Player_Controller>().isAlive == true)
                {
                    if (FindObjectOfType<Player_Controller>().bubbleShield == true)
                    {
                        Destroy(hitbox);
                        FindObjectOfType<BubbleShield>().bubble_anim.SetTrigger("Pop");
                    }
                    
                }
            }
            */
        }
    }

    public void DestroyStar()
    {
        Destroy(gameObject);
        FindObjectOfType<Player_Controller>().isBrickImmune = false;
    }

}
