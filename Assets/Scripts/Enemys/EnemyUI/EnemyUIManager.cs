using UnityEngine;

public class EnemyUIManager : MonoBehaviour
{
    public GameObject healthBarPrefab;
    public Canvas overlayCanvas;

    public void CreateHealthBar(EnemyHealth enemy)
    {
        GameObject bar = Instantiate(healthBarPrefab, overlayCanvas.transform);
        EnemyHealthUI ui = bar.GetComponent<EnemyHealthUI>();
        ui.enemy = enemy;
    }
}