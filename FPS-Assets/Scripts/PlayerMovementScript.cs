using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script helps to move the player in all directions and to jump with gravity.
public class PlayerMovementScript : MonoBehaviour
{

    public CharacterController controller;
    public Transform groundCheck;
    public float groundDistance=0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    Vector3 velocity;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
   

 

    // Update is called once per frame
    void Update()
    { 
       isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
       if(isGrounded && velocity.y<0){
           velocity.y=-2f;
       }
       float x= Input.GetAxis("Horizontal");
       float z= Input.GetAxis("Vertical");

       Vector3 move = transform.right * x + transform.forward * z;
       controller.Move(move/10);
       velocity.y+= gravity * 1.8f * Time.deltaTime;
       controller.Move(velocity * Time.deltaTime);
       

       if(Input.GetButtonDown("Jump")&& isGrounded )
       {
           velocity.y=Mathf.Sqrt(jumpHeight * -2  * gravity);
       }

    }
}
