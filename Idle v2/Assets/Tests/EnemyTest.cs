using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class EnemyTest {
        [Test]
        public void test01_EnemyLoses10HPWhenHitByANormalAttack() {
            // arrange
            Enemy enemy = new Enemy();
            int health = enemy.getCurrentHealth();
            ITypeOfAttack normalAttack = new Normal();
            
            //act
            enemy.GetAttackedBy(normalAttack);
            
            //assert
            Assert.AreEqual(health - 10, enemy.getCurrentHealth());

        }
        [Test]
        public void test02_EnemyLoses20HPWhenHitByACriticalAttack() {
            // arrange
            Enemy enemy = new Enemy();
            int health = enemy.getCurrentHealth();
            ITypeOfAttack criticalAttack = new Critical();

            //act
            enemy.GetAttackedBy(criticalAttack);

            //assert
            Assert.AreEqual(health - 20, enemy.getCurrentHealth());

        }
    }
}
