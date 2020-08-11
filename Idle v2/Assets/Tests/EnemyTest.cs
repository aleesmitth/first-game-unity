using System.Runtime.Remoting.Metadata.W3cXsd2001;
using NUnit.Framework;
using TDDscripts;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class EnemyTest {
        public class NormalSwordTest {
            [Test]
            public void test01_EnemyLoses10HPWhenHitByBasicAttackWith10BaseDamage() {
                // arrange
                Enemy enemy = new Enemy();
                ITypeOfAttack normalAttack = new BasicAttack();

                int health = enemy.getCurrentHealth();

                //act
                enemy.GetAttackedBy(normalAttack, 10);

                //assert
                Assert.AreEqual(health - 10, enemy.getCurrentHealth());

            }

            [Test]
            public void test02_EnemyLoses20HPWhenHitByCriticalAttackWith10BaseDamage() {
                // arrange
                Enemy enemy = new Enemy();
                ITypeOfAttack criticalAttack = new CriticalAttack();

                int health = enemy.getCurrentHealth();

                //act
                enemy.GetAttackedBy(criticalAttack, 10);

                //assert
                Assert.AreEqual(health - 20, enemy.getCurrentHealth());

            }

            [Test]
            public void test03_EnemyLosesAtLeast10HPWhenHitWithNormalSword() {
                // arrange
                Enemy enemy = new Enemy();
                ISword normalSword = new NormalSword();
                ITypeOfAttack criticalAttack = new CriticalAttack();

                int health = enemy.getCurrentHealth();

                //act
                enemy.GetAttackedBy(normalSword);

                //assert
                Assert.LessOrEqual(enemy.getCurrentHealth(), health - 10);

            }

            [Test]
            public void test04_EnemyLosesAtMost20HPWhenHitWithNormalSword() {
                // arrange
                Enemy enemy = new Enemy();
                ISword normalSword = new NormalSword();
                ITypeOfAttack criticalAttack = new CriticalAttack();

                int health = enemy.getCurrentHealth();

                //act
                enemy.GetAttackedBy(normalSword);

                //assert
                Assert.GreaterOrEqual(enemy.getCurrentHealth(), health - 20);

            }
        }

        public class FireSwordTest {
            [Test]
            public void test01_EnemyLosesAtLeast20HPWhenHitWithFireSword() {
                // arrange
                Enemy enemy = new Enemy();
                ISword fireSword = new FireSword();
                ITypeOfAttack criticalAttack = new CriticalAttack();

                int health = enemy.getCurrentHealth();

                //act
                enemy.GetAttackedBy(fireSword);

                //assert
                Assert.LessOrEqual(enemy.getCurrentHealth(), health - 20);

            }

            [Test]
            
            
            
            public void test02_EnemyLosesAtMost40HPWhenHitWithFireSword() {
                // arrange
                Enemy enemy = new Enemy();
                ISword fireSword = new FireSword();
                ITypeOfAttack criticalAttack = new CriticalAttack();

                int health = enemy.getCurrentHealth();

                //act
                enemy.GetAttackedBy(fireSword);

                //assert
                Assert.GreaterOrEqual(enemy.getCurrentHealth(), health - 40);

            }
        }
    }
}
