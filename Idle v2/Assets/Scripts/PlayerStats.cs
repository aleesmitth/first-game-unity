using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
    public NewManagerScript Manager;
    public float timePlayed;
    public double totalCurrency1Collected;
    public double totalCurrency2Collected;
    public int totalEnemiesDefeated;
    public int totalUpgradesBought;

    public void UpdateStats(double C1PS, double C2PS)
    {
        totalCurrency1Collected += C1PS;
        totalCurrency2Collected += C2PS;
    }

    public void UpdateStats(double C1Reward, double C2Reward, int EnemiesDefeated = 1)
    {
        totalCurrency1Collected += C1Reward;
        totalCurrency1Collected += C2Reward;
        totalEnemiesDefeated += EnemiesDefeated;
    }

    public void UpdateStats(int UpgradesBought)
    {
        totalUpgradesBought += UpgradesBought;
    }


}
