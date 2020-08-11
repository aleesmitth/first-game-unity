using System;
using System.Collections.Generic;

namespace TDDscripts {
    public class FireSword : ISword {
        private const int BASE_DAMAGE = 20;
        public Dictionary<int, ITypeOfAttack> TypesOfAttack { get; }

        public FireSword() {
            this.TypesOfAttack = new Dictionary<int, ITypeOfAttack> {{0, new BasicAttack()}, {1, new CriticalAttack()}};
        }
        public void Attack(Enemy enemy) {
            enemy.GetAttackedBy(this.GetRandomTypeOfAttack(), FireSword.BASE_DAMAGE);
        }
        private ITypeOfAttack GetRandomTypeOfAttack() {
            Random random = new Random();
            // returns a random type of attack
            return TypesOfAttack[random.Next(TypesOfAttack.Count)];
        }
    }
}
