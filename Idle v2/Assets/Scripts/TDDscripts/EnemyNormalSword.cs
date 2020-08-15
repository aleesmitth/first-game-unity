using System;
using System.Collections.Generic;

namespace TDDscripts {
    public class EnemyNormalSword : ISword {
        private const int BASE_DAMAGE = 10;
        private Dictionary<int, ITypeOfAttack> TypesOfAttack { get; }

        public EnemyNormalSword() {
            this.TypesOfAttack = new Dictionary<int, ITypeOfAttack> {{0, new BasicAttack()}};
        }

        public void Attack(IAttackingCharacter attackingCharacter) {
            attackingCharacter.GetAttackedBy(this.TypesOfAttack[0], EnemyNormalSword.BASE_DAMAGE);
        }

        public void Attack(IAttackingCharacter attackingCharacter, int extraDamage) {
            attackingCharacter.GetAttackedBy(this.TypesOfAttack[0], EnemyNormalSword.BASE_DAMAGE + extraDamage);
        }
    }
}