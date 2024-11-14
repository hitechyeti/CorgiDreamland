using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCorgiCrash : MonoBehaviour
{
    public void CorgiCrash()
    {
        FindObjectOfType<GameManager>().EndGameOver();
    }
}
