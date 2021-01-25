using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestScript
    {
        
        [UnityTest]
        public IEnumerator EnemyMovement()
        {
            GameObject enemy = new GameObject();
            enemy.AddComponent<Rigidbody2D>();
            enemy.AddComponent<EnemyController2>();
         

            Vector3 initialPos = enemy.transform.position;

            yield return new WaitForSeconds(0.5f);

            Assert.AreNotEqual(enemy.transform.position, initialPos);


        }

        [UnityTest]
        public IEnumerator EnemyCollision()
        {
            GameObject enemy = new GameObject();
            enemy.AddComponent<Rigidbody2D>();
            enemy.AddComponent<EnemyController2>();
            enemy.AddComponent<Animator>();

            GameObject tile = new GameObject();
            tile.AddComponent<Rigidbody2D>();
            tile.AddComponent<PlayerController2>();
            tile.tag = "Tile";

            int initialDirection = enemy.GetComponent<EnemyController2>().getDirection();

            enemy.transform.position = tile.transform.position;
            yield return new WaitForSeconds(0.1f);

            Assert.AreNotEqual(enemy.GetComponent<EnemyController2>().getDirection(), initialDirection);


        }


    }
}