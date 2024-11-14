using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_Woodpecker : MonoBehaviour
{
    private float leftEdge;

    private bool onScreen;

    public void Start()
    {
        onScreen = false;
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void OnBecameVisible()
    {
        onScreen = true;
    }

    private void OnBecameInvisible()
    {
        onScreen = false;
    }

    private void Update()
    {

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }

    }

    public void WoodpeckerPeck()
    {
        if (onScreen)
        {
            FindObjectOfType<Sound_Woodpecker>().Woodpecker1();
        }
    }

    
}
