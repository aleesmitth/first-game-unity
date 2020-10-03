namespace TDDscripts {
    public class CoinBag {
        public int Coin { get; private set; }

        public CoinBag() {
            this.Coin = 0;
        }
        public void AddCoins(Rewards rewards) {
            this.Coin += rewards.GetCoins();
        }
        
        public void AddCoins(int coins) {
            this.Coin += coins;
        }

        public void SubstractCoins(int coins) {
            this.Coin -= coins;
        }
    }
}