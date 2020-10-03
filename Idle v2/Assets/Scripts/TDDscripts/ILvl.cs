﻿namespace TDDscripts {
    public interface ILvl {
        int GetHealthBonus();
        int GetDefenseBonus();
        int GetDamageBonus();
        int GetCoinBonus();
        int GetExpBonus();
        int ExperienceNeeded();
        ILvl LvlUp();
    }
}