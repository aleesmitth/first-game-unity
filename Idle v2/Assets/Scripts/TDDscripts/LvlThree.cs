namespace TDDscripts {
    public class LvlThree : ILvl {
        private const int HEALTH_BONUS = 25;
        private const int DEFENSE_BONUS = 5;
        private const int DAMAGE_BONUS = 15;
        public int GetHealthBonus() {
            return LvlThree.HEALTH_BONUS;
        }

        public int GetDefenseBonus() {
            return LvlThree.DEFENSE_BONUS;
        }

        public int GetDamageBonus() {
            return LvlThree.DAMAGE_BONUS;
        }
    }
}