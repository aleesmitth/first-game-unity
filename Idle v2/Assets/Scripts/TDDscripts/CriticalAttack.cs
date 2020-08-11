namespace TDDscripts {
    public class CriticalAttack : ITypeOfAttack {
        protected const int DAMAGE_MULTIPLIER_CRITICAL = 2;
        public void Attack(Stats stats, int baseDamage) {
            stats.GetDamagedFor(baseDamage * CriticalAttack.DAMAGE_MULTIPLIER_CRITICAL);
        }
    }
}