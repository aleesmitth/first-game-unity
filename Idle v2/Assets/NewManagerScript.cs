using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class NewManagerScript : MonoBehaviour
{

    private Currency money = new Currency("Money", 5);
    private Currency weaponParts = new Currency("Weapon Parts", 0);
    private Currency prestige = new Currency("Prestige", 0);

    private Upgrade clickUpgrade = new Upgrade("Click Upgrade", 0, 1, 10, 1.07); //click/wpn pow

    private Upgrade productionUpgrade1 = new Upgrade("Production Upgrade 1"); //Money passive income
    private Upgrade productionUpgrade2 = new Upgrade("Production Upgrade 2", 0, 5, 300, 1.07);//Money passive income
    private Upgrade automaticWeaponUpgrade = new Upgrade("Auto Weapon 1", 0, 1, 500, 1.07);//HP passive damage

    public TextMeshProUGUI currency1DisplayText; //money display
    public TextMeshProUGUI currency2DisplayText; //parts display
    public TextMeshProUGUI buttonHPText; //button HP display

    public double buttonLevel = 1; //make button class
    public double buttonMaxHP = 15;
    public double buttonHP = 15;
    public double buttonReward1 = 10;
    public double buttonReward2 = 100;

    public Health health = new Health(10);

    void Update() {
        /*
         * reemplazo esto:
         * money.currencyAmount += productionUpgrade1.upgradeLevel * productionUpgrade1.upgradePower;
         *
         * por esto:    */
        money.ReceiveUpgrade(productionUpgrade1); //idle money 1
        money.ReceiveUpgrade(productionUpgrade2);
        
        //no hay necesidad de acceder a el nombre, es mas entendible el codigo asi y el toString esta demas, el "+" lo hace solo.
        currency1DisplayText.text = "Money" + ": " + Math.Floor(money.currencyAmount);
        currency2DisplayText.text = "Weapon Parts" + ": " + Math.Floor(weaponParts.currencyAmount);

        /*
         * reemplazo esto:
         * buttonHP -= automaticWeaponUpgrade.upgradeLevel * automaticWeaponUpgrade.upgradePower;
         *
         * por esto:    */
        automaticWeaponUpgrade.DoDamageTo(health); //idle HP damage
        
        buttonHPText.text = "The Button has " + Math.Floor(health.getCurrentHealth()) + " HP remaining";
        
    }

    public void OnClickButton()
    {
        //buttonHP -= clickUpgrade.upgradePower * clickUpgrade.upgradeLevel + 1;
        clickUpgrade.DoDamageTo(health); //aca el +1 no esta siendo aplicado, pero si tuvieramos una interfaz, el clickUpgrade podria
                                         //implementar el DoDamageTo() de una forma distinta q los otros objetos Upgrade
        if (buttonHP <= 0)
        {
            ButtonDies();
        }
    }
    /*
     * esto de que la muerte del boton la resuelva el manager se siente mal, el que tiene que saber si murio o no
     * es el mismo boton, y ver como resuelve su muerte, pero ya es mas complicado por que hay que ver si tiene sentido
     * que el boton tenga acceso a una referencia de la plata del jugador, etc,etc..
     */
    private void ButtonDies()
    {
        money.currencyAmount += buttonReward1;
        weaponParts.currencyAmount += buttonReward2;
        buttonHP = buttonMaxHP * Random.Range(1, 1.5f);
    }

    public void OnSpendWeaponParts()
    {
        //currency2.currencyAmount -= SpendPartsCost;
        //RollForNewWeapon();

    }
}
