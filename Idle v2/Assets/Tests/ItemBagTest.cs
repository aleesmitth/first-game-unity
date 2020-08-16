using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TDDscripts;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class ItemBagTest {
        
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
            Assert.IsFalse(itemBag.HasItemInSlot(firstSlotPosition));
        }
    }
}
