using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float cameraAdjust;
    public Transform target;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;
    public Vector3 minValues, maxValues;
    public static CameraMovement mainCam;

    //changed from FixedUpdate()

    private void Awake()
    {
        ChangeX_Center();
        cameraAdjust = 0;
    }

    private void Update()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 targetPosition = target.position + offset;

        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, minValues.x, maxValues.x),
            Mathf.Clamp(targetPosition.y, minValues.y, maxValues.y),
            Mathf.Clamp(targetPosition.z, minValues.z, maxValues.z));

        Vector3 smoothPostion = Vector3.Lerp(transform.position, boundPosition, smoothFactor * Time.fixedDeltaTime);

        transform.position = smoothPostion;
    }

    public void ChangeMaxY_Low()
    {
        maxValues.y = 0f;
    }

    public void ChangeMaxY_High()
    {
        maxValues.y = 9.5f;
    }

    public void ChangeX_Center()
    {
        minValues.x = 0f;
        maxValues.x = 0f;
    }

    public void ChangeX_Left()
    {
        minValues.x = cameraAdjust;
        maxValues.x = cameraAdjust;

        if (cameraAdjust < 3)
        {
            cameraAdjust += 0.1f;
            Invoke(nameof(ChangeX_Left), 0.05f);
        }
    }

}
