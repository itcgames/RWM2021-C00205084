using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Vector3 playerPos;
    Vector3 velocity;
    float friction = 0.99f;

    // number of lives the player has 
    public int playerLives;


    string CURRENT_STATE;
    public Animator animator;



    Vector3 previousPosition;

    GameObject gameController;



    // Start is called before the first frame update
    void Start()
    {
        // set player velocity to 0 when game starts
        playerPos = transform.position;
        previousPosition = playerPos;
        Vector3 velocity = new Vector3(0.0f, 0.0f, 0.0f);
        gameController = GameObject.FindGameObjectWithTag("GameController");
        // Player is idle before movement 
        CURRENT_STATE = "idle";


        animator = GetComponent<Animator>();
        CURRENT_STATE = "idle";

    }

    void FixedUpdate()
    {
        previousPosition = playerPos;
        playerPos += velocity * friction;
        transform.position = playerPos;
    }

    // Update is called once per frame
    void Update()
    {
        InputController();


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
        if (Input.GetKey("w"))
        {
            MoveUp();
        }

        if (Input.GetKeyUp("w"))
        {
            Stop();
        }

        if (Input.GetKey("a"))
        {
            MoveLeft();
        }

        if (Input.GetKeyUp("a"))
        {
            Stop();
        }

        if (Input.GetKey("s"))
        {
            MoveDown();
        }

        if (Input.GetKeyUp("s"))
        {
            Stop();
        }


        if (Input.GetKey("d"))
        {
            MoveRight();
        }

        if (Input.GetKeyUp("d"))
        {
            Stop();
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

    // public to allow map access
    public void StopMovement()
    {
        Debug.Log("Stop Called");
        velocity.x = 0.0f;
        velocity.y = 0.0f;
        playerPos = previousPosition;
        transform.position = playerPos;
        CURRENT_STATE = "idle";
    }

    public void Stop()
    {
        velocity.x = 0.0f;
        velocity.y = 0.0f;
        CURRENT_STATE = "idle";
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Character")
        {
            Debug.Log("CollisionEnemy");
            velocity = new Vector2(0.0f, 0.0f);

            playerLives = playerLives - 1;
        }

        // Life function - this is much different to the one from group project but this one is generic and could work with other projects
        if (other.gameObject.tag == "Life")
        {
            playerLives = playerLives + 1;
            Debug.Log("Collision");
        }
    }



    public int GetLives()
    {
        return playerLives;
    }
}