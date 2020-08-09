using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Normal : ITypeOfAttack {
    // this new assing syntax relieves me from having to assign the value in a constructor
    public override int Damage { get; protected set; } = NORMAL_DAMAGE;

    public override void Attack(Stats stats) {
        stats.GetAttackedBy(this);
    }

}
