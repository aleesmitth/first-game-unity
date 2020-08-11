using System.Collections.Generic;

namespace TDDscripts {
    public interface ISword {
        //even though im not using this property, it forces derived classes to have it implemented.
        Dictionary<int, ITypeOfAttack> TypesOfAttack { get; }
        void Attack(Enemy enemy);
    }
}