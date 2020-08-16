namespace TDDscripts {
    public class CoinBag {
        private int coins;

        public CoinBag() {
            this.coins = 0;
        }
        public void AddCoins(Rewards rewards) {
            this.coins += rewards.GetCoins();
        }

        public int GetCurrentCoins() {
            return this.coins;
        }
    }
}