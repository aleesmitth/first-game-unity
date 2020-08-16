namespace TDDscripts {
    public class CriticalAttack : ITypeOfAttack {
        protected const int DAMAGE_MULTIPLIER_CRITICAL = 2;
        public void Attack(Stats stats, int damage) {
            stats.GetDamagedFor(damage * CriticalAttack.DAMAGE_MULTIPLIER_CRITICAL);
        }
    }
}