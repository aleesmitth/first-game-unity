using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency
{
        public string currencyName = "currencyname";
        public double currencyAmount;

        public Currency(string name, double amount)
        {
            currencyName = name;
            currencyAmount = amount;
        }

        public void ReceiveUpgrade(Upgrade upgrade) {
            currencyAmount += upgrade.UpgradeValue();
        }
}
