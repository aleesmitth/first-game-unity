using NUnit.Framework;
using TDDscripts;

namespace Tests {
    public class PlayerTest {
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
                public class DamageReceivedTest {
                    [Test]
                    public void test01_Lvl1PlayerLoses10HPWhenHitByLvl1Enemy() {
                        // 10 de daño base + 5 por el nivel.
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
                    public void test02_Lvl1PlayerLoses15HPWhenHitByLvl2Enemy() {
                        //10 de daño base + 15 por el nivel.
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
                    public void test03_Lvl1PlayerLoses25HPWhenHitByLvl3Enemy() {
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
                    public void test04_Lvl2PlayerLoses7HPWhenHitByLvl1Enemy() {
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
                    public void test05_Lvl2PlayerLoses12HPWhenHitByLvl2Enemy() {
                        // arrange
                        Player player = new Player(new LvlTwo());
                        Enemy enemy = new Enemy(new LvlTwo());
                        var health = player.getCurrentHealth();

                        // act
                        enemy.Attack(player);

                        // assert
                        Assert.AreEqual(health - 12, player.getCurrentHealth());
                    }
                    [Test]
                    public void test06_Lvl2PlayerLoses22HPWhenHitByLvl3Enemy() {
                        // arrange
                        Player player = new Player(new LvlTwo());
                        Enemy enemy = new Enemy(new LvlThree());
                        var health = player.getCurrentHealth();

                        // act
                        enemy.Attack(player);

                        // assert
                        Assert.AreEqual(health - 22, player.getCurrentHealth());
                    }
                    [Test]
                    public void test07_Lvl3PlayerLoses5HPWhenHitByLvl1Enemy() {
                        // arrange
                        Player player = new Player(new LvlThree());
                        Enemy enemy = new Enemy(new LvlOne());
                        var health = player.getCurrentHealth();

                        // act
                        enemy.Attack(player);

                        // assert
                        Assert.AreEqual(health - 5, player.getCurrentHealth());
                    }
                    [Test]
                    public void test08_Lvl3PlayerLoses10HPWhenHitByLvl2Enemy() {
                        // 10 de daño base + 15 por el nivel - 3 por la defensa de nivel. 
                        // arrange
                        Player player = new Player(new LvlThree());
                        Enemy enemy = new Enemy(new LvlTwo());
                        var health = player.getCurrentHealth();

                        // act
                        enemy.Attack(player);

                        // assert
                        Assert.AreEqual(health - 10, player.getCurrentHealth());
                    }
                    [Test]
                    public void test09_Lvl3PlayerLoses20HPWhenHitByLvl3Enemy() {
                        // 10 de daño base + 15 por el nivel - 3 por la defensa de nivel. 
                        // arrange
                        Player player = new Player(new LvlThree());
                        Enemy enemy = new Enemy(new LvlThree());
                        var health = player.getCurrentHealth();

                        // act
                        enemy.Attack(player);

                        // assert
                        Assert.AreEqual(health - 20, player.getCurrentHealth());
                    }
                }
            }
            public class DamageDoneTest {
                public class EnemyArmorTest {
                    [Test]
                    public void test01_Lvl1PlayerAttacksLvl1EnemyAndEnemyLosesAtLeast10HP() {
                        // arrange
                        Player player = new Player(new LvlOne());
                        Enemy enemy = new Enemy(new LvlOne());
                        var health = enemy.GetCurrentHealth();

                        // act
                        player.Attack(enemy);

                        // assert
                        Assert.LessOrEqual(enemy.GetCurrentHealth(), health - 10);
                    }

                    [Test]
                    public void test02_Lvl1PlayerAttacksLvl1EnemyAndEnemyLosesAtMost20HP() {
                        // arrange
                        Player player = new Player(new LvlOne());
                        Enemy enemy = new Enemy(new LvlOne());
                        var health = enemy.GetCurrentHealth();

                        // act
                        player.Attack(enemy);

                        // assert
                        Assert.GreaterOrEqual(enemy.GetCurrentHealth(), health - 20);
                    }

                    [Test]
                    public void test03_Lvl1PlayerAttacksLvl2EnemyAndEnemyLosesAtLeast7HP() {
                        // arrange
                        Player player = new Player(new LvlOne());
                        Enemy enemy = new Enemy(new LvlTwo());
                        var health = enemy.GetCurrentHealth();

                        // act
                        player.Attack(enemy);

                        // assert
                        Assert.LessOrEqual(enemy.GetCurrentHealth(), health - 7);
                    }

                    [Test]
                    public void test04_Lvl1PlayerAttacksLvl2EnemyAndEnemyLosesAtMost17HP() {
                        // arrange
                        Player player = new Player(new LvlOne());
                        Enemy enemy = new Enemy(new LvlTwo());
                        var health = enemy.GetCurrentHealth();

                        // act
                        player.Attack(enemy);

                        // assert
                        Assert.GreaterOrEqual(enemy.GetCurrentHealth(), health - 17);
                    }

                    [Test]
                    public void test05_Lvl1PlayerAttacksLvl3EnemyAndEnemyLosesAtLeast5HP() {
                        // arrange
                        Player player = new Player(new LvlOne());
                        Enemy enemy = new Enemy(new LvlTwo());
                        var health = enemy.GetCurrentHealth();

                        // act
                        player.Attack(enemy);

                        // assert
                        Assert.LessOrEqual(enemy.GetCurrentHealth(), health - 5);
                    }

                    [Test]
                    public void test06_Lvl1PlayerAttacksLvl3EnemyAndEnemyLosesAtMost15HP() {
                        // arrange
                        Player player = new Player(new LvlOne());
                        Enemy enemy = new Enemy(new LvlThree());
                        var health = enemy.GetCurrentHealth();

                        // act
                        player.Attack(enemy);

                        // assert
                        Assert.GreaterOrEqual(enemy.GetCurrentHealth(), health - 15);
                    }

                    [Test]
                    public void test07_Lvl2PlayerAttacksLvl1EnemyAndEnemyLosesAtLeast15HP() {
                        // arrange
                        Player player = new Player(new LvlTwo());
                        Enemy enemy = new Enemy(new LvlOne());
                        var health = enemy.GetCurrentHealth();

                        // act
                        player.Attack(enemy);

                        // assert
                        Assert.LessOrEqual(enemy.GetCurrentHealth(), health - 15);
                    }

                    [Test]
                    public void test08_Lvl2PlayerAttacksLvl1EnemyAndEnemyLosesAtMost30HP() {
                        // arrange
                        Player player = new Player(new LvlTwo());
                        Enemy enemy = new Enemy(new LvlOne());
                        var health = enemy.GetCurrentHealth();

                        // act
                        player.Attack(enemy);

                        // assert
                        Assert.GreaterOrEqual(enemy.GetCurrentHealth(), health - 30);
                    }

                    [Test]
                    public void test09_Lvl2PlayerAttacksLvl2EnemyAndEnemyLosesAtLeast12HP() {
                        // arrange
                        Player player = new Player(new LvlTwo());
                        Enemy enemy = new Enemy(new LvlTwo());
                        var health = enemy.GetCurrentHealth();

                        // act
                        player.Attack(enemy);

                        // assert
                        Assert.LessOrEqual(enemy.GetCurrentHealth(), health - 12);
                    }

                    [Test]
                    public void test10_Lvl2PlayerAttacksLvl2EnemyAndEnemyLosesAtMost27HP() {
                        // arrange
                        Player player = new Player(new LvlTwo());
                        Enemy enemy = new Enemy(new LvlTwo());
                        var health = enemy.GetCurrentHealth();

                        // act
                        player.Attack(enemy);

                        // assert
                        Assert.GreaterOrEqual(enemy.GetCurrentHealth(), health - 27);
                    }

                    [Test]
                    public void test11_Lvl2PlayerAttacksLvl3EnemyAndEnemyLosesAtLeast10HP() {
                        // arrange
                        Player player = new Player(new LvlTwo());
                        Enemy enemy = new Enemy(new LvlThree());
                        var health = enemy.GetCurrentHealth();

                        // act
                        player.Attack(enemy);

                        // assert
                        Assert.LessOrEqual(enemy.GetCurrentHealth(), health - 10);
                    }

                    [Test]
                    public void test12_Lvl2PlayerAttacksLvl1EnemyAndEnemyLosesAtMost25HP() {
                        // arrange
                        Player player = new Player(new LvlTwo());
                        Enemy enemy = new Enemy(new LvlThree());
                        var health = enemy.GetCurrentHealth();

                        // act
                        player.Attack(enemy);

                        // assert
                        Assert.GreaterOrEqual(enemy.GetCurrentHealth(), health - 25);
                    }

                    [Test]
                    public void test13_Lvl3PlayerAttacksLvl1EnemyAndEnemyLosesAtLeast25HP() {
                        // arrange
                        Player player = new Player(new LvlThree());
                        Enemy enemy = new Enemy(new LvlOne());
                        var health = enemy.GetCurrentHealth();

                        // act
                        player.Attack(enemy);

                        // assert
                        Assert.LessOrEqual(enemy.GetCurrentHealth(), health - 25);
                    }

                    [Test]
                    public void test14_Lvl3PlayerAttacksLvl1EnemyAndEnemyLosesAtMost50HP() {
                        // arrange
                        Player player = new Player(new LvlThree());
                        Enemy enemy = new Enemy(new LvlOne());
                        var health = enemy.GetCurrentHealth();

                        // act
                        player.Attack(enemy);

                        // assert
                        Assert.GreaterOrEqual(enemy.GetCurrentHealth(), health - 50);
                    }

                    [Test]
                    public void test15_Lvl3PlayerAttacksLvl1EnemyAndEnemyLosesAtLeast22HP() {
                        // arrange
                        Player player = new Player(new LvlThree());
                        Enemy enemy = new Enemy(new LvlTwo());
                        var health = enemy.GetCurrentHealth();

                        // act
                        player.Attack(enemy);

                        // assert
                        Assert.LessOrEqual(enemy.GetCurrentHealth(), health - 22);
                    }

                    [Test]
                    public void test16_Lvl3PlayerAttacksLvl2EnemyAndEnemyLosesAtMost47HP() {
                        // arrange
                        Player player = new Player(new LvlThree());
                        Enemy enemy = new Enemy(new LvlTwo());
                        var health = enemy.GetCurrentHealth();

                        // act
                        player.Attack(enemy);

                        // assert
                        Assert.GreaterOrEqual(enemy.GetCurrentHealth(), health - 47);
                    }

                    [Test]
                    public void test17_Lvl3PlayerAttacksLvl3EnemyAndEnemyLosesAtLeast20HP() {
                        // arrange
                        Player player = new Player(new LvlThree());
                        Enemy enemy = new Enemy(new LvlThree());
                        var health = enemy.GetCurrentHealth();

                        // act
                        player.Attack(enemy);

                        // assert
                        Assert.LessOrEqual(enemy.GetCurrentHealth(), health - 20);
                    }

                    [Test]
                    public void test18_Lvl3PlayerAttacksLvl3EnemyAndEnemyLosesAtMost45HP() {
                        // arrange
                        Player player = new Player(new LvlThree());
                        Enemy enemy = new Enemy(new LvlThree());
                        var health = enemy.GetCurrentHealth();

                        // act
                        player.Attack(enemy);

                        // assert
                        Assert.GreaterOrEqual(enemy.GetCurrentHealth(), health - 45);
                    }
                }
            }
        }
        public class BagTest {
            [Test]
            public void test01_BagCanStoreNormalSword() {
                // arrange
                ItemBag itemBag = new ItemBag();
                ISword normalSword = new NormalSword();
                var firstSlotPosition = 1;

                // act
                itemBag.StoreItemInSlot(normalSword, firstSlotPosition);

                // assert
                Assert.AreSame(normalSword, itemBag.GetItemStoredInSlot(firstSlotPosition));
            }
            [Test]
            public void test02_BagCanStoreFireSword() {
                // arrange
                ItemBag itemBag = new ItemBag();
                ISword fireSword = new FireSword();
                var firstSlotPosition = 1;

                // act
                itemBag.StoreItemInSlot(fireSword, firstSlotPosition);

                // assert
                Assert.AreSame(fireSword, itemBag.GetItemStoredInSlot(firstSlotPosition));
            }
            [Test]
            public void test03_BagDoesntStoreFireSwordWithAnotherSwordAlreadyThere() {
                // arrange
                ItemBag itemBag = new ItemBag();
                ISword fireSword = new FireSword();
                ISword normalSword = new NormalSword();
                var firstSlotPosition = 1;

                // act
                itemBag.StoreItemInSlot(normalSword, firstSlotPosition);
                itemBag.StoreItemInSlot(fireSword, firstSlotPosition);

                // assert
                Assert.AreNotSame(fireSword, itemBag.GetItemStoredInSlot(firstSlotPosition));
                Assert.AreSame(normalSword, itemBag.GetItemStoredInSlot(firstSlotPosition));
            }
            [Test]
            public void test04_BagCanStore1SwordPerBagSlot() {
                // arrange
                ItemBag itemBag = new ItemBag();
                ISword normalSword = new NormalSword();
                var firstSlotPosition = 1;
                var maxSlots = itemBag.GetMaxSlotsAmount();

                // act
                for (int i = firstSlotPosition; i <= maxSlots; i++){
                    itemBag.StoreItemInSlot(normalSword, i);
                }

                // assert
                Assert.IsTrue(itemBag.IsFull());
            }
            [Test]
            public void test05_WhenBagDiscardsStoredSwordReturnsTheItem() {
                // arrange
                ItemBag itemBag = new ItemBag();
                ISword fireSword = new FireSword();
                var firstSlotPosition = 1;

                // act
                itemBag.StoreItemInSlot(fireSword, firstSlotPosition);
                IStorableItem discardedFireSword = itemBag.DiscardItemInSlot(firstSlotPosition);

                // assert
                Assert.AreSame(fireSword, discardedFireSword);
            }
            [Test]
            public void test06_WhenBagDiscardsStoredSwordSlotIsEmpty() {
                // arrange
                ItemBag itemBag = new ItemBag();
                ISword fireSword = new FireSword();
                var firstSlotPosition = 1;

                // act
                itemBag.StoreItemInSlot(fireSword, firstSlotPosition);
                itemBag.DiscardItemInSlot(firstSlotPosition);

                // assert
                Assert.IsFalse(itemBag.HasItemIn(firstSlotPosition));
            }
        }
    }
}
