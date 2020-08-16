namespace TDDscripts {
    public interface IPlayerCharacter : ICharacter {
        
        void Attack(IEnemyCharacter enemy);
        int GetCurrentCoins();
    }
}