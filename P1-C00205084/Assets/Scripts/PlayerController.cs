﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    Vector3 playerPos;
    Vector3 velocity; 
    float friction = 0.99f;

    string CURRENT_STATE;
    public Animator animator;

    public static int lives;

    public bool dead; 

    // Start is called before the first frame update
    void Start()
    {
        playerPos = new Vector3(0.0f, -3.85f, 0.0f);
        Vector3 velocity = new Vector3(0.0f, 0.0f, 0.0f);
        CURRENT_STATE = "idle";
        lives = 3;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        InputController();
        transform.position = playerPos;
        playerPos.y += velocity.y * friction;
        playerPos.x += velocity.x * friction;

        if(lives == 0)
        {
            KillPlayer();
        }


        switch (CURRENT_STATE)
        {
            case "idle":
                animator.Play("idle");
                break;
            case "walkLeft":
                animator.Play("walkLeft");
                break;
            case "walkRight":
                animator.Play("walkRight");
                break;
            case "walkUp":
                animator.Play("walkUp");
                break;
            case "walkDown":
                animator.Play("walkDown");
                break;

        }

    }

    void InputController()
    {
        if(Input.GetKeyDown("w"))
        {
            MoveUp();
            CURRENT_STATE = "walkUp";
        }

        if(Input.GetKeyUp("w"))
        {
            StopMovement();
            CURRENT_STATE = "idle";
        }

        if (Input.GetKey("a"))
        {
            MoveLeft();
            CURRENT_STATE = "walkLeft";
        }

        if (Input.GetKeyUp("a"))
        {
            StopMovement();
            CURRENT_STATE = "idle";
        }

        if (Input.GetKey("s"))
        {
            MoveDown();
            CURRENT_STATE = "walkDown";
        }

        if (Input.GetKeyUp("s"))
        {
            StopMovement();
            CURRENT_STATE = "idle";
        }


        if (Input.GetKey("d"))
        {
            MoveRight();
            CURRENT_STATE = "walkRight";
        }

        if (Input.GetKeyUp("d"))
        {
            StopMovement();
            CURRENT_STATE = "idle";
        }

    }

    void MoveUp()
    {
        velocity.x = 0.0f;
        velocity.y = 0.01f;
    }

    void MoveDown()
    {
        velocity.x = 0.0f;
        velocity.y = -0.01f;
    }

    void MoveLeft()
    {
        velocity.x = -0.01f;
        velocity.y = 0.0f;
    }

    void MoveRight()
    {
        velocity.x = 0.01f;
        velocity.y = 0.0f;
    }


    void StopMovement()
    {
        velocity.x = 0.0f;
        velocity.y = 0.0f;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Stop moving if tile encountered
        if(collision.gameObject.tag == "Tile")
        {
            velocity = new Vector2(0.0f, 0.0f);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            lives = lives - 1;
        }
    }

    public int GetLives()
    {
        return lives;
    }

    void KillPlayer()
    {
        // Call game specific function during integration here
        dead = true;
    }

    public void SetLives(int t_lives)
    {
        lives = t_lives;
    }
}
