using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestScript
    {

       GameObject playerObject;
       GameObject enemyObject;

        string player = "Prefabs/Player";
        string enemy = "Prefabs/Enemy1";


    [SetUp]
    public void Setup()
    {
        GameObject controllerPrefab = Resources.Load<GameObject>(player);

        playerObject = GameObject.Instantiate(controllerPrefab, new Vector2(50.0f, 50.0f), Quaternion.identity);

        GameObject controllerEnemyPrefab = Resources.Load<GameObject>(enemy);

        enemyObject = GameObject.Instantiate(controllerEnemyPrefab, new Vector2(0.0f, 0.0f), Quaternion.identity);
    }

        [UnityTest, Order(1)]
        public IEnumerator EnemyMovement()
        {
            GameObject enemy = new GameObject();
            enemy.AddComponent<Rigidbody2D>();
            enemy.AddComponent<EnemyController>();


            Vector3 initialPos = enemy.transform.position;

            yield return new WaitForSeconds(0.5f);

            Assert.AreNotEqual(enemy.transform.position, initialPos);


        }

        [UnityTest, Order(2)]
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
        [UnityTest, Order(3)]
        public IEnumerator PlayerLives()
        {
            int playerLife = PlayerController.GetLives();

            playerObject.transform.position = enemyObject.transform.position;

            yield return new WaitForSeconds(0.4f);

            Assert.AreEqual(playerLife, PlayerController.GetLives());
        }


    }
}
