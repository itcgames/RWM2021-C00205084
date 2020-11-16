using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Vector3 velocity;
    int enemyDirection;
    Vector3 enemyPos;


  

    // Start is called before the first frame update
    void Start()
    {
        enemyDirection = Random.Range(1, 4);
        velocity = new Vector2(0.0f, 0.0f);
        enemyPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        enemyPos += velocity;
        transform.position = enemyPos;
        getDirection();

        if(enemyDirection == 1)
        {
            velocity.y = 0.0f;
            velocity.x = 0.001f;
        }

        else if(enemyDirection == 2)
        {
            velocity.y = 0.0f;
            velocity.x = -0.001f;
        }

       else if(enemyDirection == 3)
        {
            velocity.x = 0.0f;
            velocity.y = 0.001f;
        }

       else if(enemyDirection == 4)
        {
            velocity.x = 0.0f;
            velocity.y = -0.001f;
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

    }

    int getDirection()
    {
        return enemyDirection;
    }

}
