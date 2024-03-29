using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform objecto;
    public Transform camerachange;
    public Transform lightchange;

    private Camera camero;

    public float distance = 25.0f;
    
    
    
    public float curX = 1.0f;
    public float curY = 1.0f;
    Quaternion rotation;
    private void Start()
    {
        camerachange = transform;
        camero = Camera.main;
        
    }
    private void Update()
    {
        curX += 1.0f * Input.GetAxis("Mouse X");
        curY += 1.0f * Input.GetAxis("Mouse Y");
    }
    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        rotation = Quaternion.Euler(curY, curX, 0);

        camerachange.position = objecto.position + rotation * dir;
        camerachange.LookAt(objecto.position);

        lightchange.position = objecto.position + rotation * dir*.5f;
        lightchange.LookAt(objecto.position);

    }

    public Quaternion GetRotation()
    {
        return rotation;
    }
}
