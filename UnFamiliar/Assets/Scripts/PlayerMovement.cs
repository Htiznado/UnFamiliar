using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public CharacterController controller;
    public float jumpStrength;
    public float gravityScale;

    private Vector3 moveDirection;
    void Start()
    {
       controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, 0f);

        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump")) //full strength jump
            {
                moveDirection.y = jumpStrength;
            }
        }

        if (Input.GetButtonUp("Jump") && moveDirection.y > 0) //lil baby jump
        {
            moveDirection.y = (jumpStrength * 0.35f);
        } 

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale); //gravity we can set in inspector

        controller.Move(moveDirection * Time.deltaTime);
    }
}
