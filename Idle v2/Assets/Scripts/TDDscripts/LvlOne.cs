namespace TDDscripts {
    public class LvlOne : ILvl {
        private const int EXP_TO_LVL_UP = 100;
        private const int HEALTH_BONUS = 0;
        private const int DEFENSE_BONUS = 0;
        private const int DAMAGE_BONUS = 0;
        private const int COIN_BONUS = 0;
        private const int EXP_BONUS = 0;
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

        public int GetExpBonus() {
            return LvlOne.EXP_BONUS;
        }

        public int ExperienceNeeded() {
            return LvlOne.EXP_TO_LVL_UP;
        }

        public ILvl LvlUp() {
            return new LvlTwo();
        }
    }
}