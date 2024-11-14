using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island_Sets_Move : MonoBehaviour
{
    public float speed;
    private float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 150f;
        
    }

    private void Update()
    {
        speed = FindObjectOfType<Player_Controller>().speedIncrease;

        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
