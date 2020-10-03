using System.Collections.Generic;

namespace TDDscripts {
    public class Shop {
        /*id list*/
        private const int NORMAL_SWORD_ID = 1;
        private const int FIRE_SWORD_ID = 2;
        /*price list*/
        private const int NORMAL_SWORD_PRICE = 200;
        private const int FIRE_SWORD_PRICE = 400;
        //maybe using singleton with the shop would be a good idea?
        private readonly Dictionary<int, int> prices;
        private readonly Dictionary<int, IStorableItem> items;

        public Shop() {
            items = new Dictionary<int, IStorableItem> {{NORMAL_SWORD_ID, new NormalSword()}, {FIRE_SWORD_ID, new FireSword()}};
            prices = new Dictionary<int, int> {{NORMAL_SWORD_ID, NORMAL_SWORD_PRICE}, {FIRE_SWORD_ID, FIRE_SWORD_PRICE}};
        }
        public IStorableItem BuyItem(int itemId, CoinBag coinBag) {
            //excepcion en vez de null
            if (!IsValidId(itemId) || !GotEnoughCoins(itemId, coinBag)) return null;
            coinBag.SubstractCoins(prices[itemId]);
            return items[itemId];
        }

        private bool IsValidId(int itemId) {
            return (itemId > 0 && itemId <= items.Count);
        }

        private bool GotEnoughCoins(int itemId, CoinBag coinBag) {
            return (coinBag.Coin >= prices[itemId]);
        }
    }
}