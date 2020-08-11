namespace TDDscripts {
    public class Enemy {

        private Stats stats;


        public Enemy() {
            stats = new Stats();
        }
        public int getCurrentHealth() {
            return stats.GetCurrentHealth();
        }
        public void GetAttackedBy(ITypeOfAttack typeOfAttack, int baseDamage) {
            typeOfAttack.Attack(this.stats, baseDamage);
        }
        public void GetAttackedBy(ISword sword) {
            sword.Attack(this);
        }
    }
}
