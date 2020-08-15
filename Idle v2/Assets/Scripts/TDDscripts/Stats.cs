namespace TDDscripts {
    public class Stats {
        private const int STARTING_ENEMY_HEALTH = 100;
        private const int STARTING_ENEMY_DEFENSE = 0;
        private const int STARTING_ENEMY_DAMAGE = 0;
        private int Health { get; set; }
        private int Defense { get; set; }
        public int Damage { get; private set; }

        public Stats() {
            this.Health = Stats.STARTING_ENEMY_HEALTH;
            this.Defense = Stats.STARTING_ENEMY_DEFENSE;
            this.Damage = Stats.STARTING_ENEMY_DAMAGE;
        }
        public int GetCurrentHealth() {
            return this.Health;
        }
        public void GetDamagedFor(int damage) {
            this.Health -= damage - this.Defense;
        }
        public void ApplyLvlBonuses(ILvl lvl) {
            this.Health += lvl.GetHealthBonus();
            this.Defense += lvl.GetDefenseBonus();
            this.Damage += lvl.GetDamageBonus();
        }
    }
}
