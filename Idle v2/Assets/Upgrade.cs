using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
        public string upgradeName = "upgradename";
        public double upgradeLevel;
        public double upgradePower = 1;
        public double upgradeCost = 25;
        public double upgradeCostMultiplier = 1.07;

        public Upgrade(string upgradeName)
        {
            this.upgradeName = upgradeName;
        }

        public Upgrade(string upgradeName, double upgradeLevel, double upgradePower, double upgradeCost, double upgradeCostMultiplier)
        {
            this.upgradeName = upgradeName;
            this.upgradeLevel = upgradeLevel;
            this.upgradePower = upgradePower;
            this.upgradeCost = upgradeCost;
            this.upgradeCostMultiplier = upgradeCostMultiplier;
        }

        public double UpgradeValue() {
            return upgradeLevel * upgradePower;
        }

        public void DoDamageTo(Health health) {
            health.receiveDamage(upgradeLevel*upgradePower);
        }
}
