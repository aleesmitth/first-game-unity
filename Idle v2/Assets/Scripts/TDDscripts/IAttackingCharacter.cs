namespace TDDscripts {
    public interface IAttackingCharacter {// refactor this name, doesn't fit.
        int getCurrentHealth();
        void GetAttackedBy(ITypeOfAttack typeOfAttack, int swordBaseDamage);
        void GetAttackedBy(ISword sword, int extraDamage);
        void Attack(IAttackingCharacter character);
    }
}