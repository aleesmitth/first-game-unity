namespace TDDscripts {
    public class LvlOne : ILvl {
        private const int HEALTH_BONUS = 0;
        private const int DEFENSE_BONUS = 0;
        private const int DAMAGE_BONUS = 0;
        private const int COIN_BONUS = 0;
        public int GetHealthBonus() {
            return LvlOne.HEALTH_BONUS;
        }

        public int GetDefenseBonus() {
            return LvlOne.DEFENSE_BONUS;
        }

        public int GetDamageBonus() {
            return LvlOne.DAMAGE_BONUS;
        }

        public int GetCoinBonus() {
            return LvlOne.COIN_BONUS;
        }
    }
}