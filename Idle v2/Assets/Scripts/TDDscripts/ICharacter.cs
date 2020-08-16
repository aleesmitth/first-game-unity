namespace TDDscripts {
    public interface ICharacter {// refactor this name, doesn't fit.
        void GetAttackedBy(ITypeOfAttack typeOfAttack, int damage);
        void GetAttackedBy(ISword sword, int extraDamage);
        
        //method mostly for testing killing blows
        void SetCurrentHealthAtPercentage(int percentage);
        bool ReceivedKillingBlow();
    }
}