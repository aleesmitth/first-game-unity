using System.Transactions;

namespace TDDscripts {
    public class BasicAttack : ITypeOfAttack {
        private const int DAMAGE_MULTIPLIER_NORMAL = 1;
        // this new assing syntax relieves me from having to assign the value in a constructor

        public void Attack(Stats stats, int damage) {
            stats.GetDamagedFor(damage * BasicAttack.DAMAGE_MULTIPLIER_NORMAL);
        }

    }
}
