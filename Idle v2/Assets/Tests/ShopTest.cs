using System;
using System.Collections;
using NUnit.Framework;
using TDDscripts;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class ShopTest {
        [Test]
        public void test01_BuyingNormalSwordFromShopChargesMeCoin() {
            //arrange
            Shop shop = new Shop();
            CoinBag coinBag = new CoinBag();
            coinBag.AddCoins(500);
            int normalSwordID = 1;
            
            //act
            shop.BuyItem(normalSwordID, coinBag);
            
            //assert
            Assert.AreEqual(300, coinBag.GetCurrentCoins());
        }
        [Test]
        public void test02_BuyingNormalSwordFromShopGivesMeTheSword() {
            //arrange
            Shop shop = new Shop();
            CoinBag coinBag = new CoinBag();
            coinBag.AddCoins(500);
            int normalSwordID = 1;
            
            //act
            IStorableItem normalSword = shop.BuyItem(normalSwordID, coinBag);
            
            //assert
            Assert.IsInstanceOf<NormalSword>(normalSword);
        }
        [Test]
        public void test03_BuyingFireSwordFromShopChargesMeCoin() {
            //arrange
            Shop shop = new Shop();
            CoinBag coinBag = new CoinBag();
            coinBag.AddCoins(500);
            int fireSwordId = 2;
            
            //act
            shop.BuyItem(fireSwordId, coinBag);
            
            //assert
            Assert.AreEqual(100, coinBag.GetCurrentCoins());
        }
        [Test]
        public void test04_BuyingFireSwordFromShopGivesMeTheSword() {
            //arrange
            Shop shop = new Shop();
            CoinBag coinBag = new CoinBag();
            coinBag.AddCoins(500);
            int fireSwordId = 2;
            
            //act
            IStorableItem fireSword = shop.BuyItem(fireSwordId, coinBag);
            
            //assert
            Assert.IsInstanceOf<FireSword>(fireSword);
        }
    }
}
