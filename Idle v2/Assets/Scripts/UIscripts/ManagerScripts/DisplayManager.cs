using System.Collections;
using System.Collections.Generic;
using MonoBehaviours;
using TDDscripts;
using TMPro;
using UIscripts;
using UIscripts.ManagerScripts;
using UnityEngine;

public class DisplayManager : MonoBehaviour {
    private IEnemyCharacter enemy;
    public CharacterStatsUI playerStats;
    public CharacterStatsUI enemyStats;
    public TextMeshProUGUI coin;
    public void UpdateDisplay() {
        coin.text = GameManager.instance.Player.GetCurrentCoins().ToString();
        playerStats.DisplayStats(GameManager.instance.Player);
        enemyStats.DisplayStats(enemy);
    }

    public void SetEnemy(IEnemyCharacter enemy) {
        this.enemy = enemy;
        enemyStats.SetMaxHealthDisplay(enemy);
        UpdateDisplay();
    }
}
