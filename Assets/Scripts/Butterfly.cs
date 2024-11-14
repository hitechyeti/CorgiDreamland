using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour
{
    public float speed = 3f;
    private float leftEdge;

    public float velocity;
    public float angle;
    public float timer;
    public float frequency;

    public float rotationSpeed = 5f;

    private Rigidbody2D rb;
    private bool _isForward = true;
    private Quaternion targetRotStart = Quaternion.identity;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        speed = Random.Range(2.5f, 3f);
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotStart, rotationSpeed * Time.deltaTime);

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }

    }

    private void FixedUpdate()
    {
        if (timer >= frequency)
        {
            angle = Random.Range(-70, 70);

            RandomFlyingRotate();
            RandomFlyingTransform();

            frequency = Random.Range(15, 40);
            timer = 0;
        }

        timer += 1;
    }

    private void RandomFlyingRotate()
    {
        _isForward = !_isForward;
        targetRotStart = Quaternion.AngleAxis(_isForward ? -angle : angle, Vector3.back);
    }

    private void RandomFlyingTransform()
    {
        if (transform.rotation.z > 0)
        {
            velocity = -0.5f;
            rb.velocity = Vector2.zero;
            rb.velocity = Vector2.up * velocity;
        }
        else
        {
            velocity = 0.5f;
            rb.velocity = Vector2.zero;
            rb.velocity = Vector2.up * velocity;
        }

    }

}
