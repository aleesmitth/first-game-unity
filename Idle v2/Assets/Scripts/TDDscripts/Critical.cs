namespace Tests {
    public class Critical : ITypeOfAttack {
        // this new assing syntax relieves me from having to assign the value in a constructor
        public override int Damage { get; protected set; } = CRITICAL_DAMAGE;

        public override void Attack(Stats stats) {
            stats.GetAttackedBy(this);
        }
    }
}