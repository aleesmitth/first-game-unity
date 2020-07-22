using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
        public string UpgradeName = "upgradename";
        public double UpgradeLevel;
        public double UpgradePower = 1;
        public double UpgradeCost = 25;
        public double UpgradeCostMultiplier = 1.07;

        public Upgrade(string upgradeName)
        {
            UpgradeName = upgradeName;
        }

        public Upgrade(string upgradeName, double upgradeLevel, double upgradePower, double upgradeCost, double upgradeCostMultiplier)
        {
            UpgradeName = upgradeName;
            UpgradeLevel = upgradeLevel;
            UpgradePower = upgradePower;
            UpgradeCost = upgradeCost;
            UpgradeCostMultiplier = upgradeCostMultiplier;
        }
}
