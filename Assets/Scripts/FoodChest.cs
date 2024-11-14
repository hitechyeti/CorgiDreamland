using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodChest : MonoBehaviour
{
    private int ranFood;

    public GameObject Prefab1;
    public GameObject Prefab2;
    public GameObject Prefab3;
    public GameObject Prefab4;

    // Start is called before the first frame update
    void Start()
    {
        ranFood = Random.Range(1, 5);

        if (ranFood == 1)
        {
            Instantiate(Prefab1, transform);
        }
        else if (ranFood == 2)
        {
            Instantiate(Prefab2, transform);
        }
        else if (ranFood == 3)
        {
            Instantiate(Prefab3, transform);
        }
        else if (ranFood == 4)
        {
            Instantiate(Prefab4, transform);
        }
    }

}
