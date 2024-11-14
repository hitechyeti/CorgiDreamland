using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunaSnapping : MonoBehaviour
{
    public float speed = 4.5f;

    public int timeBetweenJump = 300;
    private int lastTimeJump = 0;
    public int jumpCount = 0;

    public float velocity = 1.5f;
    public float rotationSpeed = 10f;

    private float leftEdge;
    private Rigidbody2D rb;

    private bool _isForward = true;
    private Quaternion targetRotStart = Quaternion.identity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        speed = Random.Range(3.5f, 4.5f);
        lastTimeJump = Random.Range(-100, 0);
        speed += FindObjectOfType<Player_Controller>().speedIncrease - 7;
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
        if (lastTimeJump == 50 && jumpCount == 0)
        {
            TunaJumpStart();
            jumpCount = 1;
        }
        else if (lastTimeJump == 70 && jumpCount == 1)
        {
            TunaJumpMiddle();
            jumpCount = 2;
        }
        else if (lastTimeJump == 90 && jumpCount == 2)
        {
            TunaJumpFinish();
            lastTimeJump = 0;
            jumpCount = 3;
            //timeBetweenJump = Random.Range(200, 250);
        }

        lastTimeJump += 1;
    }

    private void TunaJumpStart()
    {
        speed *= 3;
        rb.velocity += Vector2.up * velocity;
        _isForward = !_isForward;
        targetRotStart *= Quaternion.AngleAxis(_isForward ? -45 : 45, Vector3.back);
        _isForward = !_isForward;
    }

    private void TunaJumpMiddle()
    {
        rb.velocity += Vector2.down * (velocity * 2);
        _isForward = !_isForward;
        targetRotStart *= Quaternion.AngleAxis(_isForward ? -90 : 90, Vector3.forward);
        _isForward = !_isForward;
    }

    private void TunaJumpFinish()
    {
        speed /= 3;
        rb.velocity = Vector2.zero;
        _isForward = !_isForward;
        targetRotStart *= Quaternion.AngleAxis(_isForward ? -45 : 45, Vector3.back);
        _isForward = !_isForward;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shark")
        {
            FindObjectOfType<Sound_SharkNomNom>().SharkRandomNom();
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Water")
        {
            FindObjectOfType<Sound_FishSplash>().FishSplash1();
        }
    }

}
