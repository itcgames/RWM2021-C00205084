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

            GameObject tile = new GameObject();
            tile.AddComponent<Rigidbody2D>();
            tile.AddComponent<PlayerController2>();
            tile.tag = "Tile";

            int initialDirection = enemy.GetComponent<EnemyController2>().getDirection();

            enemy.transform.position = tile.transform.position;
            yield return new WaitForSeconds(0.1f);

            Assert.AreNotEqual(enemy.GetComponent<EnemyController2>().getDirection(), initialDirection);


        }

        [UnityTest]
        public IEnumerator PlayerLives()
        {
            GameObject enemy = new GameObject();
            enemy.tag = "Enemy";
            enemy.AddComponent<Rigidbody2D>();

            GameObject player = new GameObject();
            player.AddComponent<Rigidbody2D>();
            player.AddComponent<PlayerController2>();

            player.transform.position = enemy.transform.position;
            yield return new WaitForSeconds(0.1f);
            Assert.AreEqual(player.GetComponent<PlayerController2>().GetLives(), 3);
        }



      //  [UnityTest]
       // public IEnumerator EnemyTwoMovement()
        //{
          //  GameObject enemyTwo = new GameObject();
            //enemyTwo.AddComponent<Rigidbody2D>();
            //enemyTwo.AddComponent<EnemyTwoController>();
            //EnemyTwoController script =  enemyTwo.GetComponent<EnemyTwoController>();

            //GameObject player = new GameObject();
            //player.AddComponent<Rigidbody2D>();
            //player.AddComponent<PlayerController2>();
            //player.tag = "Player";

          
        
        //    script.setState("follow");

          //  yield return new WaitForSeconds(5.0f);
            //Assert.AreEqual(player.transform.position, enemyTwo.transform.position);
        //}
        
    }
}