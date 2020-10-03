namespace TDDscripts {
    public class LvlTwo : ILvl {
        private const int EXP_TO_LVL_UP = 150;
        private const int HEALTH_BONUS = 10;
        private const int DEFENSE_BONUS = 3;
        private const int DAMAGE_BONUS = 5;
        private const int COIN_BONUS = 30;
        private const int EXP_BONUS = 5;

        public int GetHealthBonus() {
            return LvlTwo.HEALTH_BONUS;
        }

        public int GetDefenseBonus() {
            return LvlTwo.DEFENSE_BONUS;
        }

        public int GetDamageBonus() {
            return LvlTwo.DAMAGE_BONUS;
        }

        public int GetCoinBonus() {
            return LvlTwo.COIN_BONUS;
        }

        public int GetExpBonus() {
            return LvlTwo.EXP_BONUS;
        }

        public int ExperienceNeeded() {
            return LvlTwo.EXP_TO_LVL_UP;
        }

        public ILvl LvlUp() {
            return new LvlThree();
        }
    }
}