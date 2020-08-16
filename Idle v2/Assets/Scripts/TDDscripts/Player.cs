namespace TDDscripts {
    public partial class Player : IPlayerCharacter {
        private readonly Stats stats;
        private readonly CoinBag coinBag;
        private readonly ItemBag itemBag;
        private readonly Inventory inventory;

        public Player(ILvl lvl) {
            stats = new Stats();
            coinBag = new CoinBag();
            itemBag = new ItemBag();
            inventory = new Inventory();
            stats.AddLvlBonuses(lvl);
        }

        public int GetCurrentHealth() {
            return stats.GetCurrentHealth();
        }

        public void GetAttackedBy(ITypeOfAttack typeOfAttack, int damage) {
            typeOfAttack.Attack(stats, damage);
        }

        public void GetAttackedBy(ISword sword, int extraDamage) {
            sword.Attack(this, extraDamage);
        }

        public void Attack(IEnemyCharacter enemy) {
            // no me gusta esto de acceder al daño desde aca, pero creo q es la forma mas facil y comoda de hacerlo
            // si no seguramente habria que separar entre stats defensivos, ofensivos y asi, porq no tiene sentido
            // que stats resuelva el ataque, ni que la espada acceda al daño de los stats.
            enemy.GetAttackedBy(this.inventory.GetEquippedSword(), this.stats.Damage);
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

        public void AddCoins(int coins) {
            coinBag.AddCoins(coins);
        }

        public void BuyItemFromShop(int itemId, Shop shop) {
            IStorableItem boughtItem = shop.BuyItem(itemId, this.coinBag);
            this.itemBag.StoreItemInFirstAvailableSlot(boughtItem);
        }

        public IStorableItem GetLastStoredItem() {
            return itemBag.GetLastStoredItem();
        }

        public ISword GetEquippedSword() {
            return this.inventory.GetEquippedSword();
        }

        public void Equip(ISword sword) {
            if (!this.HasSwordEquipped()) return;
            this.UnequipSword();
            this.inventory.Equip(sword);
        }

        public void UnequipSword() {
            this.itemBag.StoreItemInFirstAvailableSlot(this.inventory.UnequipSword());
        }

        public bool HasSwordEquipped() {
            return this.inventory.GetEquippedSword() != null;
        }
    }
}