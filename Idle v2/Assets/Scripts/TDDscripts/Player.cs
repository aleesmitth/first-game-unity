namespace TDDscripts {
    public class Player : IPlayerCharacter {
        private readonly Stats stats;
        private readonly ISword sword;
        private readonly CoinBag coinBag;

        public Player(ILvl lvl) {
            stats = new Stats();
            sword = new NormalSword();
            coinBag = new CoinBag();
            stats.AddLvlBonuses(lvl);
        }

        public int getCurrentHealth() {
            return stats.GetCurrentHealth();
        }

        public void GetAttackedBy(ITypeOfAttack typeOfAttack, int swordBaseDamage) {
            typeOfAttack.Attack(stats, swordBaseDamage);
        }

        public void GetAttackedBy(ISword sword, int extraDamage) {
            sword.Attack(this, extraDamage);
        }

        public void Attack(IEnemyCharacter enemy) {
            // no me gusta esto de acceder al daño desde aca, pero creo q es la forma mas facil y comoda de hacerlo
            // si no seguramente habria que separar entre stats defensivos, ofensivos y asi, porq no tiene sentido
            // que stats resuelva el ataque, ni que la espada acceda al daño de los stats.
            enemy.GetAttackedBy(this.sword, this.stats.Damage);
            if (enemy.ReceivedKillingBlow()) {
                //get reward
                enemy.GiveRewards(this.coinBag);
            }
        }

        public int GetCurrentCoins() {
            return this.coinBag.GetCurrentCoins();
        }

        public void SetCurrentHealthAtPercentage(int percentage) {
            stats.SetCurrentHealthAtPercentage(percentage);
        }

        public bool ReceivedKillingBlow() {
            //player dies
            return true;
        }
    }
}