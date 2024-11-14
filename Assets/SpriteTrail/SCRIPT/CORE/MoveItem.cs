using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItem : MonoBehaviour 
{
    public Vector2 m_Speed;

    public void Awake()
    {
        m_Speed.x = -4;
    }

    public void Update()
    {
        transform.position = (Vector2)transform.position + (m_Speed * Time.deltaTime);
    }
}
