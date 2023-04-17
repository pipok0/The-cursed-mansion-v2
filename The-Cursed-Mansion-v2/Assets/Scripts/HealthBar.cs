using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void setMaxHealth(int health) {
        // Initialisation
        slider.maxValue = health;
        slider.value = health;
    }

    public void setHealth(int health) {
        // Mise à jour
        slider.value = health;
    }
}
