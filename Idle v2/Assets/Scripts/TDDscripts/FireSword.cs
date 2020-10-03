using System;
using System.Collections.Generic;

namespace TDDscripts {
    public class FireSword : ISword {
        private const int BASE_DAMAGE = 20;
        private Dictionary<int, ITypeOfAttack> TypesOfAttack { get; }

        public FireSword() {
            this.TypesOfAttack = new Dictionary<int, ITypeOfAttack> {{0, new BasicAttack()}, {1, new CriticalAttack()}};
        }

        public void Attack(ICharacter character) {
            character.GetAttackedBy(this.GetRandomTypeOfAttack(), FireSword.BASE_DAMAGE);
        }

        public void Attack(ICharacter character, int baseDamage) {
            character.GetAttackedBy(this.GetRandomTypeOfAttack(), FireSword.BASE_DAMAGE + baseDamage);
        }

        public int GetAttackPoints() {
            return FireSword.BASE_DAMAGE;
        }

        private ITypeOfAttack GetRandomTypeOfAttack() {
            Random random = new Random();
            // returns a random type of attack
            return TypesOfAttack[random.Next(TypesOfAttack.Count)];
        }
    }
}
