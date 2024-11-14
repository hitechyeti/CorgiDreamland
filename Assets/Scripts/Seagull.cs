using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seagull : MonoBehaviour
{
    public float speed = 3.5f;
    private float leftEdge;

    //Sounds
    private int ranSound;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        speed = Random.Range(1f, 2f);
        speed += FindObjectOfType<Player_Controller>().speedIncrease;

        //Sound
        InvokeRepeating(nameof(SeagullSounds), 5, 5);
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }

    private void SeagullSounds()
    {
        ranSound = Random.Range(1, 3);

        if (ranSound == 1)
        {
            FindObjectOfType<Sound_Seagull>().Seagull1();
        }
        else if (ranSound == 2)
        {
            FindObjectOfType<Sound_Seagull>().Seagull2();
        }
        else if (ranSound == 3)
        {
            FindObjectOfType<Sound_Seagull>().Seagull3();
        }
    }

}
