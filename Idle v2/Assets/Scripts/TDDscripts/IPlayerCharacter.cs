namespace TDDscripts {
    public interface IPlayerCharacter : ICharacter {
        void Attack(IEnemyCharacter enemy);
        int GetCurrentCoins();
        void AddCoins(int coins);
        void BuyItemFromShop(int itemId, Shop shop);
        IStorableItem GetLastStoredItem();
        ISword GetEquippedSword();
        void Equip(ISword sword);
        void UnequipSword();
        bool HasSwordEquipped();
        int GetCurrentExp();
        void GainExp(Rewards rewards);
    }
}