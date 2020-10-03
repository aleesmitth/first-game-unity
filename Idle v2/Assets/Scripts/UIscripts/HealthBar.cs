using UnityEngine;
using UnityEngine.UI;

namespace UIscripts {
    public class HealthBar : MonoBehaviour {
        public Slider slider;
        public void SetMaxHealth (int health) {
            slider.maxValue = health;
        }

        public void setHealth(int health) {
            slider.value = health;
        }
    }
}
