using System;
using System.Collections;
using TDDscripts;
using UIscripts;
using UIscripts.ManagerScripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace MonoBehaviours {
    
    public class EnemyContainer : MonoBehaviour {
        private IEnemyCharacter enemy;
        public Image image;
        public DisplayManager displayManager;
        public Sprite[] enemySprites;

        private enum LvlEnum {
            One,
            Two,
            Three
        }

        private LvlEnum enemyLvl;
        public Button button;

        private void Awake() {
            button.onClick.AddListener(GotHit);
        }

        private void GotHit() {
            GameManager.instance.Player.Attack(enemy);
            displayManager.UpdateDisplay();
            if (enemy.ReceivedKillingBlow()) {
                FightManager.instance.EnemyDied();
                SpawnEnemy();
            }
        }

        public void SpawnEnemy() {
            this.RefreshEnemyStats();
            //por hacer esto aca y no en la corrutina para no tener el
            // displaymanager por todos lados, hace que me muestre
            // los stats del enemigo en pantalla antes de setActive al objeto.
            displayManager.SetEnemy(enemy);
        }

        private void RefreshEnemyStats() {
            this.PickRandomLevel();
            if (enemyLvl == LvlEnum.One) {
                this.enemy = new Enemy(new LvlOne());
            }else if (enemyLvl == LvlEnum.Two) {
                this.enemy = new Enemy(new LvlTwo());
            }
            else {
                this.enemy = new Enemy(new LvlThree());
            }

            this.PickRandomSprite();
        }

        private void PickRandomSprite() {
            image.sprite = enemySprites[Random.Range(0, enemySprites.Length)];
        }

        private void PickRandomLevel() {
            Array levels = Enum.GetValues(typeof(LvlEnum));
            this.enemyLvl = (LvlEnum)levels.GetValue(Random.Range(0,levels.Length));
        }
    }
}
