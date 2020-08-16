namespace TDDscripts {
    public class Stats {
        private const int STARTING_HEALTH = 100;
        private const int STARTING_DEFENSE = 0;
        private const int STARTING_DAMAGE = 0;
        private int Health { get; set; }
        private int Defense { get; set; }
        public int Damage { get; private set; }

        public Stats() {
            this.RecievedKillingBlow = false;
            this.Health = Stats.STARTING_HEALTH;
            this.Defense = Stats.STARTING_DEFENSE;
            this.Damage = Stats.STARTING_DAMAGE;
        }
        public int GetCurrentHealth() {
            return this.Health;
        }
        public void GetDamagedFor(int damage) {
            if (!this.ImAlive()) {
                this.RecievedKillingBlow = false;
                return; //aca tendria q haber una excepcion en vez del if.
            }
            this.Health -= damage - this.Defense;
            if (!this.ImAlive()) this.RecievedKillingBlow = true;
        }

        private bool ImAlive() {
            return this.Health > 0;
        }

        public bool RecievedKillingBlow { get; private set; }

        public void AddLvlBonuses(ILvl lvl) {
            this.Health += lvl.GetHealthBonus();
            this.Defense += lvl.GetDefenseBonus();
            this.Damage += lvl.GetDamageBonus();
        }

        public void SetCurrentHealthAtPercentage(int percentage) {
            //it uses the current health as the 100% base line.
            this.Health = this.Health * percentage / 100;
        }
    }
}
