using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    public float speed = 3f;

    public int ranExplosion;

    public GameObject prefabExplosion;

    private void Start()
    {
        speed = Random.Range(3f, 3f);
        speed += FindObjectOfType<Player_Controller>().speedIncrease - 7;
    }

    private void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RightWall")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Pufferfish")
        {
            Destroy(gameObject);
            ranExplosion = Random.Range(1, 3);
            if (ranExplosion == 1)
            {
                FindObjectOfType<Sound_Explosion>().Explosion1();
            }
            else if (ranExplosion == 2)
            {
                FindObjectOfType<Sound_Explosion>().Explosion2();
            }
            else if (ranExplosion == 3)
            {
                FindObjectOfType<Sound_Explosion>().Explosion3();
            }
            Explosion();
        }
    }

    private void Explosion()
    {
        GameObject explosion = Instantiate(prefabExplosion, transform.position, Quaternion.identity);
        explosion.transform.position = transform.position;
    }

}
