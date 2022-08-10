using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController player;
    
    CapsuleCollider feet;
    public float speed = 10f;
    public float gravity = -9.8f;
    public float jumpheight = 3f;
    public float maxJumps = 2; 
    public float jumpsRemaing = 0;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    public bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0f) 
        {
            jumpsRemaing = maxJumps;
            velocity.y = -2f; 
        }

        float xmove = Input.GetAxis("Horizontal");
        float zmove = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xmove + transform.forward * zmove;
        player.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && (jumpsRemaing > 0) )
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2 * gravity);
            jumpsRemaing--;
        }
        velocity.y += gravity * Time.deltaTime;
        player.Move(velocity * Time.deltaTime);  
    }

    
}
