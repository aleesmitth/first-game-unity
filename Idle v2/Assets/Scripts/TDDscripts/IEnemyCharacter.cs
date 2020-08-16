namespace TDDscripts {
    public interface IEnemyCharacter : ICharacter {
        
        void Attack(IPlayerCharacter player);
        void GiveRewards(CoinBag coinBag);
    }
}