using System;
using System.Collections;
using System.Collections.Generic;
using UIscripts.ManagerScripts;
using UnityEngine;
using UnityEngine.UI;

public class GoToMainMenu : MonoBehaviour {
    public Button button;

    private void Start() {
        button.onClick.AddListener(MainMenu);
    }

    private void MainMenu() {
        GameManager.instance.MainMenu();
    }
}
