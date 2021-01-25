using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController2 : MonoBehaviour
{

    Vector3 playerPos;
    Vector3 velocity;
    float friction = 0.99f;

    string CURRENT_STATE;


    public static int lives;


    // Start is called before the first frame update
    void Start()
    {
        playerPos = new Vector3(0.0f, -3.85f, 0.0f);
        Vector3 velocity = new Vector3(0.0f, 0.0f, 0.0f);
        CURRENT_STATE = "idle";
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        InputController();
        transform.position = playerPos;
        playerPos.y += velocity.y * friction;
        playerPos.x += velocity.x * friction;


   

    }

    void InputController()
    {
        if (Input.GetKeyDown("w"))
        {
            MoveUp();
            CURRENT_STATE = "walkUp";
        }

        if (Input.GetKeyUp("w"))
        {
            StopMovement();
        }

        if (Input.GetKey("a"))
        {
            MoveLeft();
            CURRENT_STATE = "walkLeft";
        }

        if (Input.GetKeyUp("a"))
        {
            StopMovement();
        }

        if (Input.GetKey("s"))
        {
            MoveDown();
            CURRENT_STATE = "walkDown";
        }

        if (Input.GetKeyUp("s"))
        {
            StopMovement();
        }


        if (Input.GetKey("d"))
        {
            MoveRight();
            CURRENT_STATE = "walkRight";
        }

        if (Input.GetKeyUp("d"))
        {
            StopMovement();
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
        if (collision.gameObject.tag == "Tile")
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
}