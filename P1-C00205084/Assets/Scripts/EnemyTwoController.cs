using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwoController : MonoBehaviour
{
    // Target tile - this is where the player is - the enemy will move towards this location
    Transform target;

    // Enemy has two movement states: follow and wander 
    string CURRENT_STATE;


    float speed = 0.01f;

    // Direction for wander 
    public int enemyDirection;


    Vector3 velocity;

    float step;

    Vector3 enemyPos;

 

    // Start is called before the first frame update
    void Start()
    {
        enemyDirection = Random.Range(1, 4);
        CURRENT_STATE = "wander";
    }

    // Just showing how movement was integrated
   /* void SearchTiles()
    {
        MapIndex startIndex = map.WorldPositionToMapIndex(transform.position);

        // Enemy searches tiles in every direction 
        MapIndex[] directions = new MapIndex[4];
        directions[0] = new MapIndex(0, 1);
        directions[1] = new MapIndex(1, 0);
        directions[2] = new MapIndex(0, -1);
        directions[3] = new MapIndex(-1, 0);

        for (int i = 1; i <= range; i++)
        {
            for (int j = 0; j < directions.Length; j++)
            {
                MapIndex nextIndex = new MapIndex(startIndex.m_x + directions[j].m_x * i,
                   startIndex.m_y + directions[j].m_y * i);

                if (map.GetTile(nextIndex) == null)
                {
                    // don't search
                    EnemyDirectionChange();
                    CURRENT_STATE = "wander";
                    break;
                }

                // if something is in the tile
                else if (!map.GetTile(nextIndex).GetIsTraversable())
                {
                    // Find out what is in the tile 
                    List<GameObject> gameObjects = map.GetEntity(nextIndex);

                    foreach (GameObject gameObject in gameObjects)
                    {
                        // If it's the player
                        if (gameObject.tag == "Player")
                        {
                            target = map.GetTile(nextIndex).transform;
                            CURRENT_STATE = "follow";

                            // if direction = 0 -> move up
                            // if direction = 1 -> move right 
                            // if direction = 2 -> move left
                            // if direction = 3 -> move down

                            if (j == 0)
                            {
                                SetDirection(4);
                            }
                            else if (j == 1)
                            {
                                SetDirection(1);
                            }
                            else if (j == 2)
                            {
                                SetDirection(2);
                            }
                            else if (j == 3)
                            {
                                SetDirection(3);
                            }

                        }

                    }
                }
            }
        }
    } */

    void Update()
    {
       // SearchTiles();

        enemyPos += velocity;
        transform.position = enemyPos;

        if(CURRENT_STATE == "wander")
        {
            EnemyMovement();
        }

        if(CURRENT_STATE == "follow")
        {
            MoveTowards();
        }

    }

    void MoveTowards()
    {
        step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Stop moving if tile encountered
        if (collision.gameObject.tag == "Tile")
        {
            EnemyDirectionChange();


            Debug.Log("Collision");

        }
    }

    void EnemyDirectionChange()
    {
        // If wander is true, go in a random direction

        enemyDirection = Random.Range(1, 4);
        if (enemyDirection == 1)
        {
            velocity.y = 0.0f;
            velocity.x = speed;
        }

        else if (enemyDirection == 2)
        {
            velocity.y = 0.0f;
            velocity.x = -speed;
        }

        else if (enemyDirection == 3)
        {
            velocity.x = 0.0f;
            velocity.y = speed;
        }

        else if (enemyDirection == 4)
        {
            velocity.x = 0.0f;
            velocity.y = -speed;
        }

    }

    void SetDirection(int dir)
    {
        if (enemyDirection == 1)
        {
            velocity.y = 0.0f;
            velocity.x = speed;
        }

        else if (enemyDirection == 2)
        {
            velocity.y = 0.0f;
            velocity.x = -speed;
        }

        else if (enemyDirection == 3)
        {
            velocity.x = 0.0f;
            velocity.y = speed;
        }

        else if (enemyDirection == 4)
        {
            velocity.x = 0.0f;
            velocity.y = -speed;
        }
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

    void setState(string state)
    {
        CURRENT_STATE = state;
    }
}
