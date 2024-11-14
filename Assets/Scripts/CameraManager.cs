using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;

    private void Start()
    {
        
    }
    public void SetPlayerCameraFollow()
    {
        cinemachineVirtualCamera = FindAnyObjectByType<CinemachineVirtualCamera>();
        cinemachineVirtualCamera.Follow = FindAnyObjectByType<Player_Controller>().transform;
    }
}
