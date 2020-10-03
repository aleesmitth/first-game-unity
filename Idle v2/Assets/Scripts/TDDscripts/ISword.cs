using System.Collections.Generic;

namespace TDDscripts {
    public interface ISword : IStorableItem {
        void Attack(ICharacter character, int baseDamage);
        int GetAttackPoints();
    }
}