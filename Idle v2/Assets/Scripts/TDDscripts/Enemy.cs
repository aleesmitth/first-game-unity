﻿namespace TDDscripts {
    public class Enemy : IAttackingCharacter {

        private readonly Stats stats;
        private readonly ISword sword;
        public Enemy(ILvl lvl) {
            sword = new EnemyNormalSword();
            stats = new Stats();
            stats.ApplyLvlBonuses(lvl);
        }
        public int getCurrentHealth() {
            return stats.GetCurrentHealth();
        }
        public void GetAttackedBy(ITypeOfAttack typeOfAttack, int swordBaseDamage) {
            typeOfAttack.Attack(this.stats, swordBaseDamage);
        }
        public void GetAttackedBy(ISword sword, int extraDamage) {
            sword.Attack(this, extraDamage);
        }

        public void Attack(IAttackingCharacter attackingCharacter) {
            // no me gusta esto de acceder al daño desde aca, pero creo q es la forma mas facil y comoda de hacerlo
            // si no seguramente habria que separar entre stats defensivos, ofensivos y asi, porq no tiene sentido
            // que stats resuelva el ataque, ni que la espada acceda al daño de los stats.
            attackingCharacter.GetAttackedBy(this.sword, this.stats.Damage);
        }
    }
}
