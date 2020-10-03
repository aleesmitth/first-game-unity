namespace TDDscripts {
    public class Enemy : IEnemyCharacter {

        private readonly Stats stats;
        private readonly ISword sword;
        private Rewards rewards;
        public Enemy(ILvl lvl) {
            sword = new EnemyNormalSword();
            stats = new Stats(lvl);
            rewards = new Rewards(lvl);
        }
        public int GetCurrentHealthPoints() {
            return stats.Health;
        }

        public int GetDefensePoints() {
            return stats.Defense;
        }

        public int GetDamagePoints() {
            return sword.GetAttackPoints() + stats.Damage;
        }

        public void GetAttackedBy(ITypeOfAttack typeOfAttack, int damage) {
            typeOfAttack.Attack(this.stats, damage);
        }
        public void GetAttackedBy(ISword sword, int extraDamage) {
            sword.Attack(this, extraDamage);
        }

        public void Attack(IPlayerCharacter player) {
            // no me gusta esto de acceder al daño desde aca, pero creo q es la forma mas facil y comoda de hacerlo
            // si no seguramente habria que separar entre stats defensivos, ofensivos y asi, porq no tiene sentido
            // que stats resuelva el ataque, ni que la espada acceda al daño de los stats.
            player.GetAttackedBy(this.sword, this.stats.Damage);
        }

        public void GiveRewards(CoinBag coinBag, IPlayerCharacter player) {
            coinBag.AddCoins(rewards);
            player.GainExp(rewards);
        }

        public void SetCurrentHealthAtPercentage(int percentage) {
            stats.SetCurrentHealthAtPercentage(percentage);
        }

        public bool ReceivedKillingBlow() {
            return stats.RecievedKillingBlow;
        }
    }
}
