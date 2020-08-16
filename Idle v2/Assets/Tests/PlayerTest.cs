using NUnit.Framework;
using TDDscripts;

namespace Tests {
    public class PlayerTest {
        public class FunctionalTest {
            [Test]
            public void test01_Lvl1PlayerEquipsFireSwordsAndHitsLvl1Enemy() {
                // arrange
                Player player = new Player(new LvlOne());
                Enemy enemy = new Enemy(new LvlOne());
                var startingHealth = enemy.GetCurrentHealth();
                
                //act
                player.Equip(new FireSword());
                player.Attack(enemy);

                // assert
                Assert.LessOrEqual(startingHealth - 40, enemy.GetCurrentHealth());
                Assert.GreaterOrEqual(startingHealth - 20, enemy.GetCurrentHealth());
            }
            [Test]
            public void test01_Lvl3PlayerEquipsFireSwordsAndHitsLvl3Enemy() {
                // arrange
                Player player = new Player(new LvlThree());
                Enemy enemy = new Enemy(new LvlThree());
                var startingHealth = enemy.GetCurrentHealth();
                
                //act
                player.Equip(new FireSword());
                player.Attack(enemy);

                // assert
                Assert.LessOrEqual(startingHealth - 65, enemy.GetCurrentHealth());
                Assert.GreaterOrEqual(startingHealth - 30, enemy.GetCurrentHealth());
            }
        }
        public class PlayerLvlTest {
            public class HealthTest {
                [Test]
                public void test01_Lvl1PlayerStartsWith100HP() {
                    // arrange
                    Player player = new Player(new LvlOne());

                    // assert
                    Assert.AreEqual(100, player.GetCurrentHealth());
                }
                [Test]
                public void test02_Lvl2PlayerStartsWith110HP() {
                    // arrange
                    Player player = new Player(new LvlTwo());

                    // assert
                    Assert.AreEqual(110, player.GetCurrentHealth());
                }
                [Test]
                public void test03_Lvl3PlayerStartsWith125HP() {
                    // arrange
                    Player player = new Player(new LvlThree());

                    // assert
                    Assert.AreEqual(125, player.GetCurrentHealth());
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
                        var health = player.GetCurrentHealth();

                        // act
                        enemy.Attack(player);

                        // assert
                        Assert.AreEqual(health - 10, player.GetCurrentHealth());
                    }
                    [Test]
                    public void test02_Lvl1PlayerLoses15HPWhenHitByLvl2Enemy() {
                        //10 de daño base + 15 por el nivel.
                        // arrange
                        Player player = new Player(new LvlOne());
                        Enemy enemy = new Enemy(new LvlTwo());
                        var health = player.GetCurrentHealth();

                        // act
                        enemy.Attack(player);

                        // assert
                        Assert.AreEqual(health - 15, player.GetCurrentHealth());
                    }
                    [Test]
                    public void test03_Lvl1PlayerLoses25HPWhenHitByLvl3Enemy() {
                        //10 de daño base + 15 por el nivel.
                        // arrange
                        Player player = new Player(new LvlOne());
                        Enemy enemy = new Enemy(new LvlThree());
                        var health = player.GetCurrentHealth();

                        // act
                        enemy.Attack(player);

                        // assert
                        Assert.AreEqual(health - 25, player.GetCurrentHealth());
                    }
                    [Test]
                    public void test04_Lvl2PlayerLoses7HPWhenHitByLvl1Enemy() {
                        // arrange
                        Player player = new Player(new LvlTwo());
                        Enemy enemy = new Enemy(new LvlOne());
                        var health = player.GetCurrentHealth();

                        // act
                        enemy.Attack(player);

                        // assert
                        Assert.AreEqual(health - 7, player.GetCurrentHealth());
                    }
                    [Test]
                    public void test05_Lvl2PlayerLoses12HPWhenHitByLvl2Enemy() {
                        // arrange
                        Player player = new Player(new LvlTwo());
                        Enemy enemy = new Enemy(new LvlTwo());
                        var health = player.GetCurrentHealth();

                        // act
                        enemy.Attack(player);

                        // assert
                        Assert.AreEqual(health - 12, player.GetCurrentHealth());
                    }
                    [Test]
                    public void test06_Lvl2PlayerLoses22HPWhenHitByLvl3Enemy() {
                        // arrange
                        Player player = new Player(new LvlTwo());
                        Enemy enemy = new Enemy(new LvlThree());
                        var health = player.GetCurrentHealth();

                        // act
                        enemy.Attack(player);

                        // assert
                        Assert.AreEqual(health - 22, player.GetCurrentHealth());
                    }
                    [Test]
                    public void test07_Lvl3PlayerLoses5HPWhenHitByLvl1Enemy() {
                        // arrange
                        Player player = new Player(new LvlThree());
                        Enemy enemy = new Enemy(new LvlOne());
                        var health = player.GetCurrentHealth();

                        // act
                        enemy.Attack(player);

                        // assert
                        Assert.AreEqual(health - 5, player.GetCurrentHealth());
                    }
                    [Test]
                    public void test08_Lvl3PlayerLoses10HPWhenHitByLvl2Enemy() {
                        // 10 de daño base + 15 por el nivel - 3 por la defensa de nivel. 
                        // arrange
                        Player player = new Player(new LvlThree());
                        Enemy enemy = new Enemy(new LvlTwo());
                        var health = player.GetCurrentHealth();

                        // act
                        enemy.Attack(player);

                        // assert
                        Assert.AreEqual(health - 10, player.GetCurrentHealth());
                    }
                    [Test]
                    public void test09_Lvl3PlayerLoses20HPWhenHitByLvl3Enemy() {
                        // 10 de daño base + 15 por el nivel - 3 por la defensa de nivel. 
                        // arrange
                        Player player = new Player(new LvlThree());
                        Enemy enemy = new Enemy(new LvlThree());
                        var health = player.GetCurrentHealth();

                        // act
                        enemy.Attack(player);

                        // assert
                        Assert.AreEqual(health - 20, player.GetCurrentHealth());
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
        
        public class ShopTest {
            public class CoinBagTest {
                [Test]
                public void test01_PlayerBuysNormalSwordAndLosesCoin() {
                    // arrange
                    Player player = new Player(new LvlOne());
                    player.AddCoins(500);
                    Shop shop = new Shop();
                    int normalSwordId = 1;
                

                    // act
                    player.BuyItemFromShop(normalSwordId, shop);

                    // assert
                    Assert.AreEqual(300, player.GetCurrentCoins());
                }
                [Test]
                public void test02_PlayerBuysFireSwordAndLosesCoin() {
                    // arrange
                    Player player = new Player(new LvlOne());
                    player.AddCoins(500);
                    Shop shop = new Shop();
                    int fireSwordId = 2;
                

                    // act
                    player.BuyItemFromShop(fireSwordId, shop);

                    // assert
                    Assert.AreEqual(100, player.GetCurrentCoins());
                }
                
            }
            [Test]
            public void test01_PlayerBuysNormalSwordAndGetsOneInItemBag() {
                // arrange
                Player player = new Player(new LvlOne());
                player.AddCoins(500);
                Shop shop = new Shop();
                int normalSwordId = 1;
                

                // act
                player.BuyItemFromShop(normalSwordId, shop);

                // assert
                Assert.IsInstanceOf<NormalSword>(player.GetLastStoredItem());
            }
            [Test]
            public void test02_PlayerBuysFireSwordAndGetsOneInItemBag() {
                // arrange
                Player player = new Player(new LvlOne());
                player.AddCoins(500);
                Shop shop = new Shop();
                int fireSwordId = 2;
                

                // act
                player.BuyItemFromShop(fireSwordId, shop);

                // assert
                Assert.IsInstanceOf<FireSword>(player.GetLastStoredItem());
            }
        }

        public class InventoryTest {
            [Test]
            public void test01_PlayerStartsWithNormalSwordEquipped() {
                // arrange
                Player player = new Player(new LvlOne());

                // assert
                Assert.IsInstanceOf<NormalSword>(player.GetEquippedSword());
            }

            [Test]
            public void test02_PlayerCanEquipFireSword() {
                // arrange
                Player player = new Player(new LvlOne());
                
                //act
                player.Equip(new FireSword());

                // assert
                Assert.IsInstanceOf<FireSword>(player.GetEquippedSword());
            }
            [Test]
            public void test03_PlayerCanEquipNormalSwordAfterFireSword() {
                // arrange
                Player player = new Player(new LvlOne());
                
                //act
                player.Equip(new FireSword());
                player.Equip(new NormalSword());

                // assert
                Assert.IsInstanceOf<NormalSword>(player.GetEquippedSword());
            }
            [Test]
            public void test04_PlayerCanUnequipNormalSword() {
                // arrange
                Player player = new Player(new LvlOne());
                
                //act
                player.UnequipSword();

                // assert
                Assert.IsFalse(player.HasSwordEquipped());
            }
            [Test]
            public void test05_PlayerUnequipedSwordGoesToItemBagFirstAvailableSlot() {
                // arrange
                Player player = new Player(new LvlOne());
                
                //act
                player.UnequipSword();

                // assert
                Assert.IsInstanceOf<NormalSword>(player.GetLastStoredItem());
            }
            [Test]
            public void test06_PlayerUnequipsAndStoresFirstSwordWhenEquippingSecondSwordOnTop() {
                // arrange
                Player player = new Player(new LvlOne());
                
                //act
                player.Equip(new FireSword());

                // assert
                Assert.IsInstanceOf<NormalSword>(player.GetLastStoredItem());
            }
            
            [Test]
            public void test06_PlayerUnequipsAndStoresFirstSwordWhenEquippingSecondSwordOnTopShowingSameObjectInstance() {
                // arrange
                Player player = new Player(new LvlOne());
                FireSword fireSword = new FireSword();
                
                //act
                player.Equip(fireSword);
                player.Equip(new NormalSword());

                // assert
                Assert.AreSame(fireSword, player.GetLastStoredItem());
            }
        }
    }
}
