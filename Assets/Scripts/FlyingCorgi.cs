using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingCorgi : MonoBehaviour
{

    [SerializeField] GameObject cloudEffect;

    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5f;

    public int speed = 5;

    Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        transform.position = new Vector3(0f, -3f, 0f);
        speed = 5;
    }

    void FixedUpdate()
    {

        if (transform.position.x >= 7.5f)
        {
            FindObjectOfType<Upgrade_Corgi>().DestroyTrails();
            transform.position = new Vector3(-7.5f, -3f, 0f);
            FindObjectOfType<Upgrade_Corgi>().Trails();
        }

        if (transform.position.y <= -4)
        {
            direction = Vector3.up * strength;
            anim.SetTrigger("Jump");
            FindObjectOfType<CostumeController>().costume_anim.SetTrigger("Jump");
            FindObjectOfType<Hats>().hat_anim.SetTrigger("Jump");
            Instantiate(cloudEffect, transform);
        }

        transform.position += Vector3.right * speed * Time.deltaTime;
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

    }

}
