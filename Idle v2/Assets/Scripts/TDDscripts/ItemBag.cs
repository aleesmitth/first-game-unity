using System.Collections.Generic;

namespace TDDscripts {
    public class ItemBag {
        private Dictionary<int, IStorableItem> items;
        private const int MAX_SLOTS = 50;
        public ItemBag() {
            this.items = new Dictionary<int, IStorableItem>();
        }
        public IStorableItem GetItemStoredInSlot(int slotPosition) {
            if (items.ContainsKey(slotPosition) && SlotNumberIsValid(slotPosition)) {
                return items[slotPosition];
            }
            //habria q hacer una excepcion, horrible este return null.
            return null;
        }
        public void StoreItemInSlot(IStorableItem item, int slotPosition) {
            if (!items.ContainsKey(slotPosition) && this.SlotNumberIsValid(slotPosition)) {
                items.Add(slotPosition, item);
            }
        }

        private bool SlotNumberIsValid(int slotPosition) {
            return (slotPosition <= MAX_SLOTS && slotPosition > 0);
        }
        //use intended for testing
        public int GetMaxSlotsAmount() {
            return MAX_SLOTS;
        }
        // seria mejor que lleve la cuenta en una variable y cada vez que deposita o saca, lleve la cuenta de cuantos
        // items tiene --refactorear--.
        public bool IsFull() {
            return items.Count == MAX_SLOTS;
        }

        public IStorableItem DiscardItemInSlot(int slotPosition) {
            IStorableItem itemDiscarded = null;
            if (items.ContainsKey(slotPosition) && this.SlotNumberIsValid(slotPosition)) {
                itemDiscarded = this.GetItemStoredInSlot(slotPosition);
                items.Remove(slotPosition);
            }

            return itemDiscarded;
        }

        public bool HasItemIn(int slotPosition) {
            return items.ContainsKey(slotPosition);
        }
    }
}