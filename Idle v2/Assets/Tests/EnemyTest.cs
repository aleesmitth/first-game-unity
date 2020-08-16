using System.Runtime.Remoting.Metadata.W3cXsd2001;
using NUnit.Framework;
using TDDscripts;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class EnemyTest {
        public class EnemyLvlTest {
            public class GoldDropped {
            [Test]
            public void test01_PlayerGets10GoldOnKillingLvl1Enemy() {
                // arrange
                Player player = new Player(new LvlOne());
                Enemy enemy = new Enemy(new LvlOne());

                // act
                enemy.SetCurrentHealthAtPercentage(1);
                //player kills enemy
                player.Attack(enemy);

                // assert
                Assert.AreEqual(10, player.GetCurrentCoins());
            }
            [Test]
            public void test02_PlayerGets40GoldOnKillingLvl2Enemy() {
                // arrange
                Player player = new Player(new LvlOne());
                Enemy enemy = new Enemy(new LvlTwo());

                // act
                enemy.SetCurrentHealthAtPercentage(1);
                //player kills enemy
                player.Attack(enemy);

                // assert
                Assert.AreEqual(40, player.GetCurrentCoins());
            }
            [Test]
            public void test03_PlayerGets65GoldOnKillingLvl3Enemy() {
                // arrange
                Player player = new Player(new LvlOne());
                Enemy enemy = new Enemy(new LvlThree());

                // act
                enemy.SetCurrentHealthAtPercentage(1);
                //player kills enemy
                player.Attack(enemy);

                // assert
                Assert.AreEqual(65, player.GetCurrentCoins());
            }
        }
        }
    }
}
