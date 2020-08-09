using System.Collections;
using System.Collections.Generic;
using Tests;
using UnityEngine;

public class Stats {
    private const int STARTING_ENEMY_HEALTH = 100;
    private int Health { get; set; }

    public Stats() {
        this.Health = STARTING_ENEMY_HEALTH;
    }

    public int getCurrentHealth() {
        return this.Health;
    }

    public void GetAttackedBy(Normal normal) {
        this.Health -= normal.Damage;
    }
    public void GetAttackedBy(Critical critical) {
        this.Health -= critical.Damage;
    }
}
