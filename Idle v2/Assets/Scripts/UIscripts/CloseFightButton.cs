using System;
using System.Collections;
using System.Collections.Generic;
using UIscripts.ManagerScripts;
using UnityEngine;
using UnityEngine.UI;

public class CloseFightButton : MonoBehaviour {
    public Button button;
    private void Start() {
        button.onClick.AddListener(RunAwayFromFight);
    }

    private void RunAwayFromFight() {
        GameManager.instance.RunAwayFromFight();
    }
}
