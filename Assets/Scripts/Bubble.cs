using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float speed = 1f;

    private void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
