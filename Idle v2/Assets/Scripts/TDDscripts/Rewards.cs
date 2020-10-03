namespace TDDscripts {
    public class Rewards {
        private int coins;
        private int exp;
        private ILvl lvl;

        public Rewards(ILvl lvl) {
            coins = 10;
            exp = 10;
            this.lvl = lvl;
            AddLvlBonuses();
        }

        private void AddLvlBonuses() {
            this.coins += lvl.GetCoinBonus();
            this.exp += lvl.GetExpBonus();
        }

        public int GetCoins() {
            return coins;
        }

        public int GetExperience() {
            return exp;
        }
    }
}