using NUnit.Framework;
using TDDscripts;

namespace Tests {
    public class ItemsTest {
        public class SwordTest {
            public class NormalSwordTest {
                [Test]
                public void test01_EnemyLoses10HPWhenHitByBasicAttackWith10BaseDamage() {
                    // arrange
                    Enemy enemy = new Enemy(new LvlOne());
                    ITypeOfAttack normalAttack = new BasicAttack();

                    int health = enemy.GetCurrentHealth();

                    //act
                    enemy.GetAttackedBy(normalAttack, 10);

                    //assert
                    Assert.AreEqual(health - 10, enemy.GetCurrentHealth());

                }

                [Test]
                public void test02_EnemyLoses20HPWhenHitByCriticalAttackWith10BaseDamage() {
                    // arrange
                    Enemy enemy = new Enemy(new LvlOne());
                    ITypeOfAttack criticalAttack = new CriticalAttack();

                    int health = enemy.GetCurrentHealth();

                    //act
                    enemy.GetAttackedBy(criticalAttack, 10);

                    //assert
                    Assert.AreEqual(health - 20, enemy.GetCurrentHealth());

                }

                [Test]
                public void test03_EnemyLosesAtLeast10HPWhenHitWithNormalSword() {
                    // arrange
                    Enemy enemy = new Enemy(new LvlOne());
                    ISword normalSword = new NormalSword();
                    ITypeOfAttack criticalAttack = new CriticalAttack();

                    int health = enemy.GetCurrentHealth();

                    //act
                    enemy.GetAttackedBy(normalSword, 0);

                    //assert
                    Assert.LessOrEqual(enemy.GetCurrentHealth(), health - 10);

                }

                [Test]
                public void test04_EnemyLosesAtMost20HPWhenHitWithNormalSword() {
                    // arrange
                    Enemy enemy = new Enemy(new LvlOne());
                    ISword normalSword = new NormalSword();
                    ITypeOfAttack criticalAttack = new CriticalAttack();

                    int health = enemy.GetCurrentHealth();

                    //act
                    enemy.GetAttackedBy(normalSword, 0);

                    //assert
                    Assert.GreaterOrEqual(enemy.GetCurrentHealth(), health - 20);

                }
            }

            public class FireSwordTest {
                [Test]
                public void test01_EnemyLosesAtLeast20HPWhenHitWithFireSword() {
                    // arrange
                    Enemy enemy = new Enemy(new LvlOne());
                    ISword fireSword = new FireSword();
                    ITypeOfAttack criticalAttack = new CriticalAttack();

                    int health = enemy.GetCurrentHealth();

                    //act
                    enemy.GetAttackedBy(fireSword, 0);

                    //assert
                    Assert.LessOrEqual(enemy.GetCurrentHealth(), health - 20);

                }

                [Test]
                public void test02_EnemyLosesAtMost40HPWhenHitWithFireSword() {
                    // arrange
                    Enemy enemy = new Enemy(new LvlOne());
                    ISword fireSword = new FireSword();
                    ITypeOfAttack criticalAttack = new CriticalAttack();

                    int health = enemy.GetCurrentHealth();

                    //act
                    enemy.GetAttackedBy(fireSword, 0);

                    //assert
                    Assert.GreaterOrEqual(enemy.GetCurrentHealth(), health - 40);

                }
            }
        }
    }
}
