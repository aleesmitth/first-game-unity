using System;
using System.Collections;
using System.Collections.Generic;
using UIscripts.ManagerScripts;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour {
    public Button button;
    private void Start() {
        button.onClick.AddListener(Quit);
    }

    private void Quit() {
        GameManager.Quit();
    }
}
