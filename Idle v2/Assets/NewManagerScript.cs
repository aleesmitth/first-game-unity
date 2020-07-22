using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewManagerScript : MonoBehaviour
{
    public Currency currency1 = new Currency("Money", 5);
    public Currency currency2 = new Currency("Weapon Parts", 0);
    public Currency currency10 = new Currency("Prestige", 0);

    public Upgrade clickUpgrade = new Upgrade("Click Upgrade", 0, 1, 10, 1.07); //click/wpn pow

    public Upgrade productionUpgrade1 = new Upgrade("Production Upgrade 1"); //Money passive income
    public Upgrade productionUpgrade2 = new Upgrade("Production Upgrade 2", 0, 5, 300, 1.07);//Money passive income
    public Upgrade automaticWeaponUpgrade = new Upgrade("Auto Weapon 1", 0, 1, 500, 1.07);//HP passive damage

    public TextMeshProUGUI currency1DisplayText; //money display
    public TextMeshProUGUI currency2DisplayText; //parts display
    public TextMeshProUGUI buttonHPText; //button HP display

    public double buttonLevel = 1; //make button class
    public double buttonMaxHP = 15;
    public double buttonHP = 15;
    public double buttonReward1 = 10;
    public double buttonReward2 = 100;

    void Start()
    {

    }

    void Update()
    {
        currency1.currencyAmount += productionUpgrade1.UpgradeLevel * productionUpgrade1.UpgradePower; //idle money1
        currency1.currencyAmount += productionUpgrade2.UpgradeLevel * productionUpgrade2.UpgradePower; //idle money 2
        currency1DisplayText.text = currency1.currencyName + ": " + currency1.currencyAmount;
        currency2DisplayText.text = currency2.currencyName + ": " + currency2.currencyAmount;
        buttonHP -= automaticWeaponUpgrade.UpgradeLevel * automaticWeaponUpgrade.UpgradePower; //idle HP damage
        buttonHPText.text = "The Button has " + buttonHP + " HP remaining";
    }

    public void OnClickButton()
    {
        buttonHP -= clickUpgrade.UpgradePower * clickUpgrade.UpgradeLevel + 1;
        if (buttonHP <= 0)
        {
            ButtonDies();
        }
    }

    private void ButtonDies()
    {
        currency1.currencyAmount += buttonReward1;
        currency2.currencyAmount += buttonReward2;
        buttonHP = buttonMaxHP * Random.Range(1, 1.5f);
    }

    public void OnSpendWeaponParts()
    {
        //currency2.currencyAmount -= SpendPartsCost;
        //RollForNewWeapon();

    }
}
