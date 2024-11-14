using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    private float leftEdge;

    private Animator anim_fireball;

    private void Start()
    {
        anim_fireball = GetComponent<Animator>();
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        speed = FindObjectOfType<Player_Controller>().speedIncrease * 2;
    }


    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
