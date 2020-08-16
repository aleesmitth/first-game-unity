namespace TDDscripts {
    public class Rewards {
        private int coins;

        public Rewards() {
            coins = 10;
        }
        public void AddLvlBonuses(ILvl lvl) {
            this.coins += lvl.GetCoinBonus();
        }

        public int GetCoins() {
            return coins;
        }
    }
}