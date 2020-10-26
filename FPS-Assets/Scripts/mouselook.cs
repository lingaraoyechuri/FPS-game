using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script helps the cam(player) to look in X-axis and Y-axis 
public class mouselook : MonoBehaviour
{ 
    float ms = 100f; 
    float xr = 0f;
    public Transform playerBody;
     
    // Update is called once per frame
    void Update()
    {
       float mouseX = Input.GetAxis("Mouse X") * ms * Time.deltaTime;
       float mousey = Input.GetAxis("Mouse Y") * ms * Time.deltaTime;
       playerBody.Rotate(Vector3.up * mouseX);

       xr -= mousey;
       xr = Mathf.Clamp(xr, -90, 90);
      transform.localRotation = Quaternion.Euler(xr, 0f, 0f);

    }
}
