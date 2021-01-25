using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    Vector3 velocity;
    public int enemyDirection;
    Vector3 enemyPos;

    int lives;


    string CURRENT_STATE;

    // Start is called before the first frame update
    void Start()
    {
        enemyDirection = Random.Range(1, 4);
        velocity = new Vector2(0.0f, 0.0f);
        enemyPos = transform.position;
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        enemyPos += velocity;
        transform.position = enemyPos;
        getDirection();

        EnemyMovement();


    }

    void EnemyMovement()
    {
        if (enemyDirection == 1)
        {
            velocity.y = 0.0f;
            velocity.x = 0.001f;
            CURRENT_STATE = "walkRight";
        }

        else if (enemyDirection == 2)
        {
            velocity.y = 0.0f;
            velocity.x = -0.001f;
            CURRENT_STATE = "walkLeft";
        }

        else if (enemyDirection == 3)
        {
            velocity.x = 0.0f;
            velocity.y = 0.001f;
            CURRENT_STATE = "walkUp";
        }

        else if (enemyDirection == 4)
        {
            velocity.x = 0.0f;
            velocity.y = -0.001f;
            CURRENT_STATE = "walkDown";
        }
    }

    void changeDirection()
    {
        enemyDirection = Random.Range(1, 4);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Stop moving if tile encountered
        if (collision.gameObject.tag == "Tile")
        {
            changeDirection();
            Debug.Log("Collision");
        }

        // Stop moving if tile encountered
        if (collision.gameObject.tag == "Enemy")
        {
            lives = lives - 1;
            Debug.Log("Collision");
        }

    }

    public int getDirection()
    {
        return enemyDirection;
    }

}