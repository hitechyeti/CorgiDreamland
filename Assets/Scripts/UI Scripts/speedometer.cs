using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedometer : MonoBehaviour
{
    private Rigidbody2D rb;
    private float rotateNum;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.rotation = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rotateNum = (FindObjectOfType<Player_Controller>().speedIncrease - 7) * -52;
        rb.rotation = rotateNum;
    }
}
