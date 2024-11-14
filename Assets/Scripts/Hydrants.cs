using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydrants : MonoBehaviour
{

    public float speed;
    private float leftEdge;

    //Dog Treats
    public int dogTreatRan;
    //public int dogTreatNow;

    private void Awake()
    {
        //Create Dog Treats
        /*
        dogTreatRan = Random.Range(1, FindObjectOfType<Spawn_Hydrants>().dogTreatNow);

        if (dogTreatRan != 1)
        {
            FindObjectOfType<Spawn_Hydrants>().dogTreatNow--;
        }
        else
        {
            FindObjectOfType<CreateDogTreats>().SpawnTreat();
            FindObjectOfType<Spawn_Hydrants>().dogTreatNow = 10;
        }
        */
    }

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 3f;
        speed = 5f;
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }

}
