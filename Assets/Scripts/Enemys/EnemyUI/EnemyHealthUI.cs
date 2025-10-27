using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    public EnemyHealth enemy;
    public Slider healthSlider;
    public Vector3 worldOffset = new Vector3(0, 2f, 0);
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        healthSlider.maxValue = enemy.maxHealth;
        healthSlider.value = enemy.maxHealth;
    }

    void Update()
    {
        if (enemy == null) return;

        Vector3 screenPos = cam.WorldToScreenPoint(enemy.transform.position + worldOffset);
        transform.position = screenPos;
        healthSlider.value = enemy.GetCurrentHealth();
    }
}