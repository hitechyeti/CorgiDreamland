using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustCamByDevice : MonoBehaviour
{

    
    public Camera m_OrthographicCamera;

    // Start is called before the first frame update
    void Start()
    {
        string identifier = SystemInfo.deviceModel;

        if (identifier.StartsWith("iPhone"))
        {
            m_OrthographicCamera.orthographicSize = 5.0f;
        }
        else if (identifier.StartsWith("iPad"))
        {
            m_OrthographicCamera.orthographicSize = 8.0f;
        }
        else
        {
            m_OrthographicCamera.orthographicSize = 5.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
