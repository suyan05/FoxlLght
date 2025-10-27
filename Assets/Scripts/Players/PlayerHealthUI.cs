using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public Slider healthSlider;
    public PlayerHealth playerHealth;

    void Start()
    {
        if (playerHealth != null)
        {
            healthSlider.maxValue = playerHealth.GetMaxHealth();
            healthSlider.value = playerHealth.GetCurrentHealth();
            playerHealth.onHealthChanged += UpdateHealthBar;
        }
    }

    void UpdateHealthBar(int current, int max)
    {
        healthSlider.maxValue = max;
        healthSlider.value = current;
    }
}