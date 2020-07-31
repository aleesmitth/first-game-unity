using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health {
    private double currentValue;

    public Health(int startingHealth) {
        currentValue = startingHealth;
    }

    public void receiveDamage(double damage) {
        currentValue -= damage;
    }

    public double getCurrentHealth() {
        return currentValue;
    }
}
