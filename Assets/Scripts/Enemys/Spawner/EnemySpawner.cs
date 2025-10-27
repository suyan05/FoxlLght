using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;         // 적 프리팹 배열
    public Transform[] spawnPoints;           // 스폰 위치 배열
    public float spawnInterval = 5f;          // 스폰 간격
    public int maxEnemies = 10;               // 최대 적 수
    public Canvas overlayCanvas;              // 체력바 캔버스
    public GameObject healthBarPrefab;        // 체력바 프리팹

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
        // 랜덤 적과 위치 선택
        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        currentEnemyCount++;

        // 체력바 연결
        EnemyHealth health = enemy.GetComponent<EnemyHealth>();
        if (health != null && overlayCanvas != null && healthBarPrefab != null)
        {
            GameObject bar = Instantiate(healthBarPrefab, overlayCanvas.transform);
            EnemyHealthUI ui = bar.GetComponent<EnemyHealthUI>();
            ui.enemy = health;
        }

        // 사망 시 적 수 감소
        EnemyHealthTracker tracker = enemy.AddComponent<EnemyHealthTracker>();
        tracker.spawner = this;
    }

    public void OnEnemyDeath()
    {
        currentEnemyCount--;
    }
}