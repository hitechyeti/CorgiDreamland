using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    public float speed;
    private float rightEdge;

    private void Start()
    {
        rightEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x + 25f;
        speed = FindObjectOfType<Player_Controller>().speedIncrease * 2;
    }

    private void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;

        if (transform.position.x > rightEdge)
        {
            Destroy(gameObject);
        }
    }
}
