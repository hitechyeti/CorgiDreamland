using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateComboStarTop : MonoBehaviour
{
    public GameObject Prefab1;
    public GameObject Prefab2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CreateTopStar()
    {
        Instantiate(Prefab2, transform);
    }

}
