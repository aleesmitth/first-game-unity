using System;
using System.Collections;
using System.Collections.Generic;
using UIscripts.ManagerScripts;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {
    public Button button;
    private void Awake() {
        button.onClick.AddListener(StartGame);
    }

    private void StartGame() {
        GameManager.instance.StartGame();
    }
}
