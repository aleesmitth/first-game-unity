using System;
using System.Collections.Generic;

namespace TDDscripts {
    public class NormalSword : ISword {
        private const int BASE_DAMAGE = 10;
        public Dictionary<int, ITypeOfAttack> TypesOfAttack { get; }
        public NormalSword() {
            //instantiate the dictionary, and adding 2 types of attack
            this.TypesOfAttack = new Dictionary<int, ITypeOfAttack> {{0, new BasicAttack()}, {1, new CriticalAttack()}};
        }


        public void Attack(Enemy enemy) {
            enemy.GetAttackedBy(this.GetRandomTypeOfAttack(), NormalSword.BASE_DAMAGE);
        }

        private ITypeOfAttack GetRandomTypeOfAttack() {
            Random random = new Random();
            // returns a random type of attack
            return TypesOfAttack[random.Next(TypesOfAttack.Count)];
        }
    }
}