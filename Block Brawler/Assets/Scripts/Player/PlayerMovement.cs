﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Speed the player moves
    [SerializeField] private float moveSpeed = 10f;

    //How high the player jumps
    [SerializeField] private float jumpForce = 8f;

    //Jump Sound Effect
    [SerializeField] private AudioSource jumpSound;

    //Checks if the player is facing left or right
    protected static bool facingLeft = false;

    //Checks if the player is looking up or down
    protected static bool facingUp = false;

    //Direction the player is facing
    protected static PlayerDirection playerDirection = PlayerDirection.Right;

    //Checks if the player is grounded
    protected static bool isGrounded = false;

    //Checks if the player is on a wall
    protected static bool onWall = false;

    //Used in Wallcheck
    protected static float bufferTime = 1f;

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        WallJump();
    }

    //Method that allows the player to move
    void Movement()
    {
        //A/D or Left/Right arrow to move the player left and right
        float x = Input.GetAxis("Horizontal");

        //Moves the player when the player inputs movement
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * x);

        if(Input.GetButton("Right"))
        {
            playerDirection = PlayerDirection.Right;
        }
        else if(Input.GetButton("Left"))
        {
            playerDirection = PlayerDirection.Left;
        }
        else if(Input.GetButton("Up"))
        {
            playerDirection = PlayerDirection.Up;
        }
        else if (Input.GetButton("Down"))
        {
            playerDirection = PlayerDirection.Down;
        }

    }

    void Jump()
    {
        //If the player presses space, and is grounded or on a wall, they will jump
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpSound.Play();
        }
    }

    void WallJump()
    {
        if(Input.GetButtonDown("Jump") && onWall && bufferTime > 0f)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            
            if(playerDirection == PlayerDirection.Left)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right, ForceMode2D.Impulse);
            }
            else if(playerDirection == PlayerDirection.Right)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left, ForceMode2D.Impulse);
            }

            jumpSound.Play();
            bufferTime--;
        }
    }

}

//Direction the player is facing/moving
public enum PlayerDirection
{
    Right,
    Left,
    Up,
    Down
}
