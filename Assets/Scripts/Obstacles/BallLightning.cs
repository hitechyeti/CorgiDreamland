using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLightning : MonoBehaviour
{
    public float speed = 10f;
    private float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 3f;
        speed = 10f;
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
