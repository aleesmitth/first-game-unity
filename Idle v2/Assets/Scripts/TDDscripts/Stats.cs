namespace TDDscripts {
    public class Stats {
        private const int STARTING_HEALTH = 100;
        private const int STARTING_DEFENSE = 0;
        private const int STARTING_DAMAGE = 0;
        public int Health { get; private set; }
        public int Defense { get; private set; }
        public int Damage { get; private set; }
        public int Experience { get; private set; }
        public ILvl Lvl { get; private set; }

        public Stats(ILvl lvl) {
            this.RecievedKillingBlow = false;
            this.Health = Stats.STARTING_HEALTH;
            this.Defense = Stats.STARTING_DEFENSE;
            this.Damage = Stats.STARTING_DAMAGE;
            this.Experience = 0;
            this.Lvl = lvl;
            AddLvlBonuses();
        }
        
        public void GetDamagedFor(int damage) {
            if (!this.ImAlive()) {
                this.RecievedKillingBlow = false;//por si ataco enemigo muerto, no da recompensas 2 veces
                return; //aca tendria q haber una excepcion en vez del if.
            }
            this.Health -= damage - this.Defense;
            if (!this.ImAlive()) this.RecievedKillingBlow = true;
        }

        private bool ImAlive() {
            return this.Health > 0;
        }

        public bool RecievedKillingBlow { get; private set; }

        private void AddLvlBonuses() {
            this.Health += Lvl.GetHealthBonus();
            this.Defense += Lvl.GetDefenseBonus();
            this.Damage += Lvl.GetDamageBonus();
        }

        public void SetCurrentHealthAtPercentage(int percentage) {
            //it uses the current health as the 100% base line.
            this.Health = this.Health * percentage / 100;
        }

        public void GainExp(Rewards rewards) {
            this.Experience += rewards.GetExperience();
            
            if (Experience < Lvl.ExperienceNeeded()) return;
            this.Experience -= Lvl.ExperienceNeeded();
            this.Lvl = Lvl.LvlUp();
            AddLvlBonuses();
        }
    }
}
