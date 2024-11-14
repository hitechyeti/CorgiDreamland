using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pufferfish : MonoBehaviour
{
    public float speed = 2f;
    private float leftEdge;

    public GameObject prefabBubble;
    public float minHeightBubble = -0.1f;
    public float maxHeightBubble = 0.1f;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        speed = Random.Range(1.5f, 2f);
        speed += FindObjectOfType<Player_Controller>().speedIncrease - 7;
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }

    private void SpawnBubble()
    {
        GameObject bubble = Instantiate(prefabBubble, transform.position, Quaternion.identity);
        bubble.transform.position += (Vector3.up * Random.Range(minHeightBubble, maxHeightBubble)) + (Vector3.left * 1.1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shark")
        {
            Destroy(gameObject);
        }
    }

}
