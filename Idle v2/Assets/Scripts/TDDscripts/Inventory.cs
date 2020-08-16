using System;

namespace TDDscripts {
    public class Inventory {
        private ISword equippedSword;

        public Inventory() {
            this.equippedSword = new NormalSword();
        }

        public ISword GetEquippedSword() {
            return this.equippedSword;
        }

        public void Equip(ISword sword) {
            this.equippedSword = sword;
        }

        public ISword UnequipSword() {
            //horrible
            var unequippedSword = this.equippedSword;
            this.equippedSword = null;
            return unequippedSword;
        }
    }
}