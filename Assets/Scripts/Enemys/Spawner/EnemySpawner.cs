using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;         // �� ������ �迭
    public Transform[] spawnPoints;           // ���� ��ġ �迭
    public float spawnInterval = 5f;          // ���� ����
    public int maxEnemies = 10;               // �ִ� �� ��
    public Canvas overlayCanvas;              // ü�¹� ĵ����
    public GameObject healthBarPrefab;        // ü�¹� ������

    private float lastSpawnTime;
    private int currentEnemyCount;

    void Update()
    {
        if (Time.time >= lastSpawnTime + spawnInterval && currentEnemyCount < maxEnemies)
        {
            SpawnEnemy();
            lastSpawnTime = Time.time;
        }
    }

    void SpawnEnemy()
    {
        // ���� ���� ��ġ ����
        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        currentEnemyCount++;

        // ü�¹� ����
        EnemyHealth health = enemy.GetComponent<EnemyHealth>();
        if (health != null && overlayCanvas != null && healthBarPrefab != null)
        {
            GameObject bar = Instantiate(healthBarPrefab, overlayCanvas.transform);
            EnemyHealthUI ui = bar.GetComponent<EnemyHealthUI>();
            ui.enemy = health;
        }

        // ��� �� �� �� ����
        EnemyHealthTracker tracker = enemy.AddComponent<EnemyHealthTracker>();
        tracker.spawner = this;
    }

    public void OnEnemyDeath()
    {
        currentEnemyCount--;
    }
}