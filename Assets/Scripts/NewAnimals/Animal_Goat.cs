using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_Goat : MonoBehaviour
{
    private int randAnim;
    private float leftEdge;

    private bool onScreen;
    private int randSound;

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

    public void GoatSound1()
    {
        FindObjectOfType<Sound_Goat>().Goat1();
    }

    public void GoatSound2()
    {
        FindObjectOfType<Sound_Goat>().Goat2();
    }

    public void RandomGoatSound()
    {
        if (onScreen)
        {
            randSound = Random.Range(1, 3);
            if (randSound == 1)
            {
                GoatSound1();
            }
            else if (randSound == 2)
            {
                GoatSound2();
            }
        }
    }

}
