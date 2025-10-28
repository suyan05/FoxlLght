using UnityEngine;

public class PlayerRangedAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;

    public float fireCooldown = 0.5f;
    private float lastFireTime;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= lastFireTime + fireCooldown)
        {
            Fire();
            lastFireTime = Time.time;
        }
    }

    void Fire()
    {
        // 탄환 생성 시 회전 고정 + 부모 분리
        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        bullet.transform.SetParent(null); // 플레이어와의 연결 제거
    }
}