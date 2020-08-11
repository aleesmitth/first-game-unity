namespace TDDscripts {
    public class Stats {
        private const int STARTING_ENEMY_HEALTH = 100;
        private int Health { get; set; }

        public Stats() {
            this.Health = Stats.STARTING_ENEMY_HEALTH;
        }

        public int GetCurrentHealth() {
            return this.Health;
        }

        public void GetDamagedFor(int damage) {
            this.Health -= damage;
        }
    }
}
