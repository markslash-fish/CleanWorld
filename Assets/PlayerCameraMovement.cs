using System;
using UnityEngine;

public class PlayerCameraMovement : MonoBehaviour
{
    public Transform playerBody;      
    public float mouseSens = 100f;
    public float verticalClamp = 90f;
    public bool camEnabled;
    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        camEnabled = true;
    }

    void Update()
    {
        CameraMove();
       
    }  
    public void CameraMove()
    {
        if (camEnabled)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;


            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -verticalClamp, verticalClamp);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);


            playerBody.Rotate(Vector3.up * mouseX);
        }
       
    }
 
  
}
