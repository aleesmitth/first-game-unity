using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Enemy {

    private Stats stats;


    public Enemy() {
        stats = new Stats();
    }

    public void GetAttackedBy(ITypeOfAttack typeOfAttack) {
        typeOfAttack.Attack(this.stats);
    }

    public int getCurrentHealth() {
        return stats.getCurrentHealth();
    }
}
