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
            
            //act
            shop.BuyItem(ItemId.NormalSword, coinBag);
            
            //assert
            Assert.AreEqual(300, coinBag.Coin);
        }
        [Test]
        public void test02_BuyingNormalSwordFromShopGivesMeTheSword() {
            //arrange
            Shop shop = new Shop();
            CoinBag coinBag = new CoinBag();
            coinBag.AddCoins(500);
            
            //act
            IStorableItem normalSword = shop.BuyItem(ItemId.NormalSword, coinBag);
            
            //assert
            Assert.IsInstanceOf<NormalSword>(normalSword);
        }
        [Test]
        public void test03_BuyingFireSwordFromShopChargesMeCoin() {
            //arrange
            Shop shop = new Shop();
            CoinBag coinBag = new CoinBag();
            coinBag.AddCoins(500);
            
            //act
            shop.BuyItem(ItemId.FireSword, coinBag);
            
            //assert
            Assert.AreEqual(100, coinBag.Coin);
        }
        [Test]
        public void test04_BuyingFireSwordFromShopGivesMeTheSword() {
            //arrange
            Shop shop = new Shop();
            CoinBag coinBag = new CoinBag();
            coinBag.AddCoins(500);
            
            //act
            IStorableItem fireSword = shop.BuyItem(ItemId.FireSword, coinBag);
            
            //assert
            Assert.IsInstanceOf<FireSword>(fireSword);
        }
    }
}
