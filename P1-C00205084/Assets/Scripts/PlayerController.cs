using System.Collections;
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


    // Start is called before the first frame update
    void Start()
    {
        playerPos = new Vector3(0.0f, -3.85f, 0.0f);
        Vector3 velocity = new Vector3(0.0f, 0.0f, 0.0f);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        CURRENT_STATE = "idle";
    }

    // Update is called once per frame
    void Update()
    {
        InputController();
        transform.position = playerPos;
        playerPos.y += velocity.y * friction;
        playerPos.x += velocity.x * friction;

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
            case "dead":
                animator.Play("dead");
                break;
        }

    }

    void InputController()
    {
        if(Input.GetKey("w"))
        {
            MoveUp();
        }

        if(Input.GetKeyUp("w"))
        {
            StopMovement();
        }

        if (Input.GetKey("a"))
        {
            MoveLeft();
        }

        if (Input.GetKeyUp("a"))
        {
            StopMovement();
        }

        if (Input.GetKey("s"))
        {
            MoveDown();
        }

        if (Input.GetKeyUp("s"))
        {
            StopMovement();
        }


        if (Input.GetKey("d"))
        {
            MoveRight();
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
        CURRENT_STATE = "walkUp";
    }

    void MoveDown()
    {
        velocity.x = 0.0f;
        velocity.y = -0.01f;
        CURRENT_STATE = "walkDown";
    }

    void MoveLeft()
    {
        velocity.x = -0.01f;
        velocity.y = 0.0f;
        CURRENT_STATE = "walkLeft";
    }

    void MoveRight()
    {
        velocity.x = 0.01f;
        velocity.y = 0.0f;
        CURRENT_STATE = "walkRight";
    }


    void StopMovement()
    {
        velocity.x = 0.0f;
        velocity.y = 0.0f;
        CURRENT_STATE = "idle";
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Stop moving if tile encountered
        if(collision.gameObject.tag == "Tile")
        {
            velocity = new Vector2(0.0f, 0.0f);
        }

    }
}
