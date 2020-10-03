using System;
using TDDscripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIscripts {
    [System.Serializable]
    public class TextDisplayed {
        public TextMeshProUGUI health;
        public TextMeshProUGUI damage;
        public TextMeshProUGUI defense;
    }

    public class CurrentValues {
        public int health;
        public int damage;
        public int defense;
    }
    [System.Serializable]
    public class CharacterStatsUI : MonoBehaviour {
        public TextDisplayed textDisplayed = new TextDisplayed();
        private CurrentValues currentValues = new CurrentValues();
        public HealthBar healthBar;

        public void DisplayStats(ICharacter character) {
            UpdateValues(character);
            UpdateTextDisplayed(character);
        }
        //TODO tengo que cambiar esta forma de actualizar los stats, maybe algun struct

        private void UpdateTextDisplayed(ICharacter character) {
            textDisplayed.health.text = currentValues.health.ToString();
            textDisplayed.damage.text = currentValues.damage.ToString();
            textDisplayed.defense.text = currentValues.defense.ToString();
        }

        private void UpdateValues(ICharacter character) {
            currentValues.health = character.GetCurrentHealthPoints();
            healthBar.setHealth(currentValues.health);
            currentValues.damage = character.GetDamagePoints();
            currentValues.defense = character.GetDefensePoints();
        }

        public void SetMaxHealthDisplay(ICharacter character) {
            this.healthBar.SetMaxHealth(character.GetCurrentHealthPoints());
        }
    }
}
