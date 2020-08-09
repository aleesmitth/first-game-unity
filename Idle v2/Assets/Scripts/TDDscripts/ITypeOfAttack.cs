using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ITypeOfAttack {
    /*in children always set the value of the Damage auto property using one of these const*/
    protected const int NORMAL_DAMAGE = 10;
    protected const int CRITICAL_DAMAGE = NORMAL_DAMAGE*2;
    
    
    public abstract int Damage { get; protected set; }
    public abstract void Attack(Stats stats);
}
