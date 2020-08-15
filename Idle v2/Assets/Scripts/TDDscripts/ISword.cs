using System.Collections.Generic;

namespace TDDscripts {
    public interface ISword {
        void Attack(IAttackingCharacter attackingCharacter, int extraDamage);
    }
}