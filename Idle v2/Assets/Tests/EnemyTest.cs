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
                Enemy enemy = new Enemy(new LvlOne());
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
                Enemy enemy = new Enemy(new LvlOne());
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
                Enemy enemy = new Enemy(new LvlOne());
                ISword normalSword = new NormalSword();
                ITypeOfAttack criticalAttack = new CriticalAttack();

                int health = enemy.getCurrentHealth();

                //act
                enemy.GetAttackedBy(normalSword, 0);

                //assert
                Assert.LessOrEqual(enemy.getCurrentHealth(), health - 10);

            }

            [Test]
            public void test04_EnemyLosesAtMost20HPWhenHitWithNormalSword() {
                // arrange
                Enemy enemy = new Enemy(new LvlOne());
                ISword normalSword = new NormalSword();
                ITypeOfAttack criticalAttack = new CriticalAttack();

                int health = enemy.getCurrentHealth();

                //act
                enemy.GetAttackedBy(normalSword, 0);

                //assert
                Assert.GreaterOrEqual(enemy.getCurrentHealth(), health - 20);

            }
        }

        public class FireSwordTest {
            [Test]
            public void test01_EnemyLosesAtLeast20HPWhenHitWithFireSword() {
                // arrange
                Enemy enemy = new Enemy(new LvlOne());
                ISword fireSword = new FireSword();
                ITypeOfAttack criticalAttack = new CriticalAttack();

                int health = enemy.getCurrentHealth();

                //act
                enemy.GetAttackedBy(fireSword, 0);

                //assert
                Assert.LessOrEqual(enemy.getCurrentHealth(), health - 20);

            }

            [Test]
            public void test02_EnemyLosesAtMost40HPWhenHitWithFireSword() {
                // arrange
                Enemy enemy = new Enemy(new LvlOne());
                ISword fireSword = new FireSword();
                ITypeOfAttack criticalAttack = new CriticalAttack();

                int health = enemy.getCurrentHealth();

                //act
                enemy.GetAttackedBy(fireSword, 0);

                //assert
                Assert.GreaterOrEqual(enemy.getCurrentHealth(), health - 40);

            }
        }

        public class PlayerLvlTest {
            public class HealthTest {
                [Test]
                public void test01_Lvl1PlayerStartsWith100HP() {
                    // arrange
                    Player player = new Player(new LvlOne());

                    // assert
                    Assert.AreEqual(100, player.getCurrentHealth());
                }
                [Test]
                public void test02_Lvl2PlayerStartsWith110HP() {
                    // arrange
                    Player player = new Player(new LvlTwo());

                    // assert
                    Assert.AreEqual(110, player.getCurrentHealth());
                }
                [Test]
                public void test03_Lvl3PlayerStartsWith125HP() {
                    // arrange
                    Player player = new Player(new LvlThree());

                    // assert
                    Assert.AreEqual(125, player.getCurrentHealth());
                }
            }
            public class ArmorTest {
                [Test]
                public void test01_Lvl1PlayerLoses10HPWhenHitByLvl1Enemy() {
                    // arrange
                    Player player = new Player(new LvlOne());
                    Enemy enemy = new Enemy(new LvlOne());
                    var health = player.getCurrentHealth();

                    // act
                    enemy.Attack(player);

                    // assert
                    Assert.AreEqual(health - 10, player.getCurrentHealth());
                }

                [Test]
                public void test02_Lvl2PlayerLoses7HPWhenHitByLvl1Enemy() {
                    // arrange
                    Player player = new Player(new LvlTwo());
                    Enemy enemy = new Enemy(new LvlOne());
                    var health = player.getCurrentHealth();

                    // act
                    enemy.Attack(player);

                    // assert
                    Assert.AreEqual(health - 7, player.getCurrentHealth());
                }
                [Test]
                public void test03_Lvl3PlayerLoses5HPWhenHitByLvl1Enemy() {
                    // arrange
                    Player player = new Player(new LvlThree());
                    Enemy enemy = new Enemy(new LvlOne());
                    var health = player.getCurrentHealth();

                    // act
                    enemy.Attack(player);

                    // assert
                    Assert.AreEqual(health - 5, player.getCurrentHealth());
                }
                public class DamageTest {
                    [Test]
                    public void test01_Lvl1PlayerLoses15HPWhenHitByLvl2Enemy() {
                        // 10 de daño base + 5 por el nivel.
                        // arrange
                        Player player = new Player(new LvlOne());
                        Enemy enemy = new Enemy(new LvlTwo());
                        var health = player.getCurrentHealth();

                        // act
                        enemy.Attack(player);

                        // assert
                        Assert.AreEqual(health - 15, player.getCurrentHealth());
                    }
                    [Test]
                    public void test02_Lvl1PlayerLoses25HPWhenHitByLvl3Enemy() {
                        //10 de daño base + 15 por el nivel.
                        // arrange
                        Player player = new Player(new LvlOne());
                        Enemy enemy = new Enemy(new LvlThree());
                        var health = player.getCurrentHealth();

                        // act
                        enemy.Attack(player);

                        // assert
                        Assert.AreEqual(health - 25, player.getCurrentHealth());
                    }
                    [Test]
                    public void test03_Lvl2PlayerLoses25HPWhenHitByLvl3Enemy() {
                        // 10 de daño base + 15 por el nivel - 3 por la defensa de nivel. 
                        // arrange
                        Player player = new Player(new LvlTwo());
                        Enemy enemy = new Enemy(new LvlThree());
                        var health = player.getCurrentHealth();

                        // act
                        enemy.Attack(player);

                        // assert
                        Assert.AreEqual(health - 22, player.getCurrentHealth());
                    }
                }
            }
        }
    }
}
