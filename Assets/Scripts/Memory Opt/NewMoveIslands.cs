using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMoveIslands : MonoBehaviour
{
    public float speed;

    private bool isMoving = false;
    private float leftEdge;
    private Vector2 startPos;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 150f;
        startPos = transform.position;
    }

    public void StartMoving()
    {
        isMoving = true;
    }

    private void Update()
    {
        if (isMoving)
        {
            speed = FindObjectOfType<Player_Controller>().speedIncrease;

            transform.position += Vector3.left * speed * Time.deltaTime;

            if (transform.position.x < leftEdge)
            {
                transform.position = startPos;
                isMoving = false;
            }
        }
    }
}
