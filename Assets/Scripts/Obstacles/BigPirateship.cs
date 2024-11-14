using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigPirateship : MonoBehaviour
{
    public GameObject prefabCannonball;
    public GameObject prefabCrosshair;

    private int cannonPattern;
    private int cannonHeight;
    private int cannonShots;
    private int cannonLastShot;
    private int cannonMaxShots;

    private int randomSound;

    public float speed;
    public bool arriving;
    public bool leaving;

    private void Start()
    {
        cannonPattern = -1;
        speed = 5;
        arriving = true;
        leaving = false;
        cannonShots = 0;
        cannonMaxShots = Random.Range(2, 5);
        cannonLastShot = 0;
    }

    private void Update()
    {
        if (arriving)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        
        if (leaving)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "StopBigPirateship")
        {
            arriving = false;
            Invoke(nameof(StartCannons), 3.0f);
        }
        else if (collision.gameObject.tag == "DestroyBigPirateship")
        {
            if (leaving)
            {
                Destroy(gameObject);
                FindObjectOfType<Spawn_Hydrants>().bigPirateshipExists = false;
            }
        }
    }

    public void BigPirateshipLeave()
    {
        if (leaving == false)
        {
            leaving = true;
            StopCannons();
        }
    }

    private void FireCannon()
    {
        FindObjectOfType<Sound_CannonPirates>().PirateCannonBoom();
        FindObjectOfType<CannonCrosshair>().DestroyCrosshair();
        //Low
        if (cannonHeight == 1)
        {
            GameObject cannonball = Instantiate(prefabCannonball, transform.position, Quaternion.identity);
            cannonball.transform.position += Vector3.up * Random.Range(-1f, -1f);
        }
        //Medium
        else if (cannonHeight == 2)
        {
            GameObject cannonball = Instantiate(prefabCannonball, transform.position, Quaternion.identity);
            cannonball.transform.position += Vector3.up * Random.Range(1f, 1f);
        }
        //High
        else if (cannonHeight == 3)
        {
            GameObject cannonball = Instantiate(prefabCannonball, transform.position, Quaternion.identity);
            cannonball.transform.position += Vector3.up * Random.Range(3f, 3f);
        }

        if (cannonShots == cannonMaxShots)
        {
            BigPirateshipLeave();
        }
        else
        {
            cannonShots++;
        }
        
        if (leaving == false)
        {
            Invoke(nameof(StartCannons), 3.0f);
        }
    }

    public void StartCannons()
    {
        if (cannonPattern >= 0)
        {
            randomSound = Random.Range(1, 3);

            if (randomSound == 1)
            {
                FindObjectOfType<Sound_ActivePirates>().PirateFire1();
            }
            else if (randomSound == 2)
            {
                FindObjectOfType<Sound_ActivePirates>().PirateFire2();
            }

            //randomize cannon shot height
            cannonHeight = Random.Range(1, 4);

            //cannon shot not repeat
            if (cannonHeight == cannonLastShot)
            {
                cannonHeight++;
            }

            if (cannonHeight > 3)
            {
                cannonHeight = 1;
            }

            //Low
            if (cannonHeight == 1)
            {
                cannonLastShot = 1;
                GameObject cannonCrosshair = Instantiate(prefabCrosshair, transform.position, Quaternion.identity);
                cannonCrosshair.transform.position += Vector3.up * Random.Range(-1f, -1f);
                cannonCrosshair.transform.position += Vector3.right * Random.Range(6f, 6f);
            }
            //Medium
            else if (cannonHeight == 2)
            {
                cannonLastShot = 2;
                GameObject cannonCrosshair = Instantiate(prefabCrosshair, transform.position, Quaternion.identity);
                cannonCrosshair.transform.position += Vector3.up * Random.Range(1f, 1f);
                cannonCrosshair.transform.position += Vector3.right * Random.Range(6f, 6f);
            }
            //High
            else if (cannonHeight == 3)
            {
                cannonLastShot = 3;
                GameObject cannonCrosshair = Instantiate(prefabCrosshair, transform.position, Quaternion.identity);
                cannonCrosshair.transform.position += Vector3.up * Random.Range(3f, 3f);
                cannonCrosshair.transform.position += Vector3.right * Random.Range(6f, 6f);
            }
            Invoke(nameof(FireCannon), 2.0f);
        }
        else
        {
            cannonPattern++;

            randomSound = Random.Range(1, 3);

            if (randomSound == 1)
            {
                FindObjectOfType<Sound_ActivePirates>().PirateCannons1();
            }
            else if (randomSound == 2)
            {
                FindObjectOfType<Sound_ActivePirates>().PirateCannons2();
            }
            Invoke(nameof(StartCannons), 3.0f);
        }
    }

    public void StopCannons()
    {
        randomSound = Random.Range(1, 2);

        if (randomSound == 1)
        {
            FindObjectOfType<Sound_ActivePirates>().PirateArrr();
        }
        CancelInvoke(nameof(FireCannon));
        CancelInvoke(nameof(StartCannons));
        FindObjectOfType<CannonCrosshair>().DestroyCrosshair();
    }

}
