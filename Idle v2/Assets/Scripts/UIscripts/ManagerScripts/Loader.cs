using System;
using System.Collections;
using System.Collections.Generic;
using UIscripts.ManagerScripts;
using UnityEngine;

public class Loader : MonoBehaviour {
    public GameObject gameManager;

    private void Awake() {
        if (GameManager.instance != null) return;
        Instantiate(gameManager);
    }
}
