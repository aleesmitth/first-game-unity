using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade
{
        public string UpgradeName = "upgradename";
        public int UpgradeLevel;
        public double UpgradePower = 1;
        public double UpgradeCost = 25;
        public double UpgradeCostMultiplier = 1.07;

        public Upgrade(string upgradeName)
        {
            UpgradeName = upgradeName;
        }

        public Upgrade(string upgradeName, int upgradeLevel, double upgradePower, double upgradeCost, double upgradeCostMultiplier)
        {
            UpgradeName = upgradeName;
            UpgradeLevel = upgradeLevel;
            UpgradePower = upgradePower;
            UpgradeCost = upgradeCost;
            UpgradeCostMultiplier = upgradeCostMultiplier;
        }

    public void UpgradeMe(double currencyAmount)
    {
        if(currencyAmount >= UpgradeCost)
        {
            currencyAmount -= UpgradeCost;
            UpgradeLevel++;
            UpgradeCost *= UpgradeCostMultiplier;
        }
    }
}
