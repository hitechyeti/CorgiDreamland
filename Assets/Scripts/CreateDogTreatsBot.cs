using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDogTreatsBot : MonoBehaviour
{

    public GameObject Prefab0;
    public GameObject Prefab1;
    public GameObject Prefab2;
    public GameObject Prefab3;

    public int treatType = 0;

    public int treatTop = 0;
    public int treatMinus = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {

    }

    public void SpawnNoTreat()
    {
        Instantiate(Prefab1, transform);//treat without random
    }

    public void SpawnTreat()
    {
        treatType = Random.Range(1, FindObjectOfType<Spawn_Hydrants>().comboNum);

        if (treatType < 3)
        {
            Instantiate(Prefab1, transform);
        }
        else if (treatType < 7)
        {
            Instantiate(Prefab2, transform);
        }
        else if (treatType >= 7)
        {
            Instantiate(Prefab3, transform);
        }

    }

}