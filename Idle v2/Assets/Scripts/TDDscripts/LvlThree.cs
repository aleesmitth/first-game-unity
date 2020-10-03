namespace TDDscripts {
    public class LvlThree : ILvl {
        private const int EXP_TO_LVL_UP = 200;
        private const int HEALTH_BONUS = 25;
        private const int DEFENSE_BONUS = 5;
        private const int DAMAGE_BONUS = 15;
        private const int COIN_BONUS = 55;
        private const int EXP_BONUS = 10;
        public int GetHealthBonus() {
            return LvlThree.HEALTH_BONUS;
        }

        public int GetDefenseBonus() {
            return LvlThree.DEFENSE_BONUS;
        }

        public int GetDamageBonus() {
            return LvlThree.DAMAGE_BONUS;
        }

        public int GetCoinBonus() {
            return LvlThree.COIN_BONUS;
        }

        public int GetExpBonus() {
            return LvlThree.EXP_BONUS;
        }

        public int ExperienceNeeded() {
            return LvlThree.EXP_TO_LVL_UP;
        }

        public ILvl LvlUp() {
            return this;
        }
    }
}