using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    Vector3 playerPos;
    Vector3 velocity; 
    float friction = 0.99f; 




    // Start is called before the first frame update
    void Start()
    {
        Vector3 velocity = new Vector3(0.0f, 0.0f, 0.0f);
        
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
        if(Input.GetKeyDown("w"))
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
}
