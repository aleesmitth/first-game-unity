using System.Collections.Generic;

namespace TDDscripts {
    public class ItemBag {
        private const int MAX_SLOTS = 50;
        
        private Dictionary<int, IStorableItem> items;
        // cache mostly for testing
        private IStorableItem lastStoredItem;
        public ItemBag() {
            this.items = new Dictionary<int, IStorableItem>();
        }
        public IStorableItem GetItemStoredInSlot(int slotPosition) {
            if (items.ContainsKey(slotPosition) && SlotPositionIsValid(slotPosition)) {
                return items[slotPosition];
            }
            //habria q hacer una excepcion, horrible este return null.
            return null;
        }
        public void StoreItemInSlot(IStorableItem item, int slotPosition) {
            if (!items.ContainsKey(slotPosition) && this.SlotPositionIsValid(slotPosition)) {
                this.items.Add(slotPosition, item);
                this.lastStoredItem = item;

            }
        }

        private bool SlotPositionIsValid(int slotPosition) {
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
            if (items.ContainsKey(slotPosition) && this.SlotPositionIsValid(slotPosition)) {
                itemDiscarded = this.GetItemStoredInSlot(slotPosition);
                items.Remove(slotPosition);
            }

            return itemDiscarded;
        }

        public bool HasItemInSlot(int slotPosition) {
            return items.ContainsKey(slotPosition);
        }
        
        //if slots are full, the item gets lost.. fix this
        public void StoreItemInFirstAvailableSlot(IStorableItem item) {
            bool itemStored = false;
            int slotPosition = 1;
            while (!itemStored && SlotPositionIsValid(slotPosition)) {
                if (!this.HasItemInSlot(slotPosition)) {
                    this.items.Add(slotPosition, item);
                    this.lastStoredItem = item;
                    itemStored = true;
                }

                slotPosition++;
            }
        }

        public IStorableItem GetLastStoredItem() {
            return this.lastStoredItem;
        }
    }
}