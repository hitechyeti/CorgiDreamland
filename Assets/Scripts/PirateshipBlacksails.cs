using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateshipBlacksails : MonoBehaviour
{
    public float speed = 3f;
    private float leftEdge;

    //Sounds
    private int ranSound;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        speed = Random.Range(2f, 3f);

        //Sounds
        InvokeRepeating(nameof(PirateSounds), 5, 5);
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }

    private void PirateSounds()
    {
        ranSound = Random.Range(1, 9);

        if (ranSound == 1)
        {
            FindObjectOfType<Sound_PassivePirates>().PirateGroupApplause1();
        }
        else if (ranSound == 2)
        {
            FindObjectOfType<Sound_PassivePirates>().PirateGroupLaugh1();
        }
        else if (ranSound == 3)
        {
            FindObjectOfType<Sound_PassivePirates>().PirateGroupLaugh2();
        }
        else if (ranSound == 4)
        {
            FindObjectOfType<Sound_PassivePirates>().PirateRandom1();
        }
        else if (ranSound == 5)
        {
            FindObjectOfType<Sound_PassivePirates>().PirateRandom2();
        }
        else if (ranSound == 6)
        {
            FindObjectOfType<Sound_PassivePirates>().PirateRandom3();
        }
        else if (ranSound == 7)
        {
            FindObjectOfType<Sound_PassivePirates>().PirateRandom4();
        }
        else if (ranSound == 8)
        {
            FindObjectOfType<Sound_PassivePirates>().PirateCallForAttack1();
        }
        else if (ranSound == 9)
        {
            FindObjectOfType<Sound_PassivePirates>().PirateCallForCannons1();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shark")
        {
            //Destroy(gameObject);
        }
    }

}
