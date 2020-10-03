using System;
using System.Collections;
using System.Collections.Generic;
using UIscripts.ManagerScripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FightButtonUI : MonoBehaviour {
    public Button button;
    // esto es para que el fightManager sepa que prefabs cargar
    public int fightNumber;
    private void Start() {
        button.onClick.AddListener(StartFight);
    }

    private void StartFight() {
        GameManager.instance.StartFight(fightNumber);
    }
}
