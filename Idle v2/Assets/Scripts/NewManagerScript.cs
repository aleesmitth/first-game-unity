using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewManagerScript : MonoBehaviour
{

    private Currency currency1 = new Currency("Money", 50);
    private Currency currency2 = new Currency("Weapon Parts", 0);
    private Currency currency10 = new Currency("Prestige", 0);

    private Upgrade clickUpgrade = new Upgrade("Click Upgrade", 0, 1, 10, 1.14); //click-wpn pow

    private Upgrade productionUpgrade1 = new Upgrade("Production Upgrade 1"); //Money passive income
    private double productionUpgrade1PerSecond; //to calculate and display income per second of this upgrade
    private Upgrade productionUpgrade2 = new Upgrade("Production Upgrade 2", 0, 5, 300, 1.07);//Money passive income
    private double productionUpgrade2PerSecond; //to calculate and display income per second of this upgrade
    private Upgrade automaticWeaponUpgrade = new Upgrade("Auto Weapon 1", 0, 1, 500, 1.07);//HP passive damage

    private PlayerStats playerStats = new PlayerStats();

    public TextMeshProUGUI currency1DisplayText; //money display
    public TextMeshProUGUI currency1PerSecondDisplayText; //money per second display
    public TextMeshProUGUI currency2DisplayText; //parts display
    public TextMeshProUGUI buttonHPText; //button HP display

    public TextMeshProUGUI Upg1Desc;
    public TextMeshProUGUI Upg1Power;
    public TextMeshProUGUI Upg1Level;
    public TextMeshProUGUI Upg1Cost;
    public TextMeshProUGUI UpgClickDesc;
    public TextMeshProUGUI UpgClickPower;
    public TextMeshProUGUI UpgClickLevel;
    public TextMeshProUGUI UpgClickCost;

    public double buttonLevel = 1; //make button class
    public double buttonMaxHP = 15;
    public double buttonHP = 15;
    public double buttonReward1 = 10;
    public double buttonReward2 = 100;
        
    public System.Action<int> OnMonsterKill;

    void Start()
    {
        UpdateButtonDisplays();
        playerStats.UpdateStats(currency1.currencyAmount, currency2.currencyAmount);
    }



    void Update()
    {
        CalculateCurrencyPerSecond();
        UpdateCurrencies();
        DisplayCurrencies();
        PassiveButtonDamage();
        DisplayButtonHP();
    }

    private void DisplayButtonHP()
    {
        buttonHPText.text = "The Button has " + buttonHP.ToString("F0") + " HP remaining";
    }

    private void PassiveButtonDamage()
    {
        buttonHP -= automaticWeaponUpgrade.UpgradeLevel * automaticWeaponUpgrade.UpgradePower; //idle HP damage
        CheckIfButtonDies();
    }

    private void DisplayCurrencies()
    {
        currency1DisplayText.text = currency1.currencyName + ": " + currency1.currencyAmount.ToString("F0");
        currency2DisplayText.text = currency2.currencyName + ": " + currency2.currencyAmount.ToString("F0");
    }

    private void UpdateCurrencies()
    {
        currency1.currencyAmount += productionUpgrade1PerSecond * Time.deltaTime; //idle money 1
        currency1.currencyAmount += productionUpgrade2PerSecond * Time.deltaTime; //idle money 2
        playerStats.UpdateStats(productionUpgrade1PerSecond * Time.deltaTime, productionUpgrade2PerSecond * Time.deltaTime);
    }

    private void CalculateCurrencyPerSecond()
    {
        productionUpgrade1PerSecond = productionUpgrade1.UpgradeLevel * productionUpgrade1.UpgradePower;
        productionUpgrade2PerSecond = productionUpgrade2.UpgradeLevel * productionUpgrade2.UpgradePower;
        currency1PerSecondDisplayText.text = "+" + (productionUpgrade1PerSecond + productionUpgrade2PerSecond).ToString("F0") + "/sec";
    }

    public void OnClickButton()
    {
        buttonHP -= clickUpgrade.UpgradePower * clickUpgrade.UpgradeLevel + 1;
        CheckIfButtonDies();
    }

    private void CheckIfButtonDies()
    {
        if (buttonHP <= 0)
        {
            ButtonDies();
        }
    }

    public void ButtonDies()
    {
        currency1.currencyAmount += buttonReward1;
        currency2.currencyAmount += buttonReward2;
        playerStats.UpdateStats(buttonReward1, buttonReward1, 1);
        buttonHP = buttonMaxHP * Random.Range(1, 1.5f);
        OnMonsterKill(Random.Range(0, 15)); //FIX THIS
    }

    public void OnSpendWeaponParts()
    {
        //currency2.currencyAmount -= SpendPartsCost;
        //RollForNewWeapon();

    }

    private void UpdateButtonDisplays()
    {
        Upg1Desc.text = "Get more " + currency1.currencyName + " income";
        Upg1Power.text = "Power: " + productionUpgrade1.UpgradePower.ToString("F0");
        Upg1Level.text = "Level: " + productionUpgrade1.UpgradeLevel.ToString("F0");
        Upg1Cost.text = "Cost: " + productionUpgrade1.UpgradeCost.ToString("F0") + " " + currency1.currencyName;
        UpgClickDesc.text = "Sharpen your weapon";
        UpgClickPower.text = "Power: " + clickUpgrade.UpgradePower.ToString("F0");
        UpgClickLevel.text = "Level: " + clickUpgrade.UpgradeLevel.ToString("F0");
        UpgClickCost.text = "Cost: " + clickUpgrade.UpgradeCost.ToString("F0") + " " + currency2.currencyName;
    }

    public void ClickUpgrade1() //buys passive money upg
    {
        int i = productionUpgrade1.UpgradeLevel;
        productionUpgrade1.UpgradeMe(currency1.currencyAmount);
        UpdateButtonDisplays();
        if (productionUpgrade1.UpgradeLevel > i) //if the upgrade was successful, update stats
        {
            playerStats.UpdateStats(1);
        }
    }

    public void ClickClickUpgrade() //buys weapon(click) upg
    {
        clickUpgrade.UpgradeMe(currency2.currencyAmount);
        UpdateButtonDisplays();
    }

}
