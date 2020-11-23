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
            enemy.AddComponent<EnemyController>();


            Vector3 initialPos = enemy.transform.position;

            yield return new WaitForSeconds(0.5f);

            Assert.AreNotEqual(enemy.transform.position, initialPos);


        }

        [UnityTest]
        public IEnumerator EnemyCollision()
        {
            GameObject enemy = new GameObject();
            enemy.AddComponent<Rigidbody2D>();
            enemy.AddComponent<EnemyController>();

            GameObject tile = new GameObject();
            tile.AddComponent<Rigidbody2D>();
            tile.AddComponent<PlayerController>();
            tile.tag = "Tile";

            int initialDirection = enemy.GetComponent<EnemyController>().getDirection();

            enemy.transform.position = tile.transform.position;
            yield return new WaitForSeconds(0.1f);

            Assert.AreNotEqual(enemy.GetComponent<EnemyController>().getDirection(), initialDirection);


        }

        [UnityTest]
        public IEnumerator PlayerCollision()
        {
            GameObject player = new GameObject();
            player.AddComponent<Rigidbody2D>();
            player.AddComponent<PlayerController>();

            GameObject enemy = new GameObject();
            enemy.AddComponent<Rigidbody2D>();
            enemy.AddComponent<EnemyController>();
            enemy.tag = "Enemy";

            int lives = player.GetComponent<PlayerController>().GetLives();

            enemy.transform.position = player.transform.position;
            yield return new WaitForSeconds(0.1f);

            Assert.AreNotEqual(player.GetComponent<PlayerController>().GetLives(), lives);

        }


    }
}
