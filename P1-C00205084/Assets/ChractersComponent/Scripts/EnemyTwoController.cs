using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwoController : MonoBehaviour
{
    Transform target;


    float speed = 0.01f;

    bool followActive = true;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

  

    void Movement()
    {
        if (followActive == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (followActive == true)
        {
            // Stop moving if tile encountered
            if (collision.gameObject.tag == "Tile")
            {
                followActive = false;
                Debug.Log("Collision");

            }
        }
        

    }

  

}


