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
    }
}
