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
        // źȯ ���� �� ȸ�� ���� + �θ� �и�
        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        bullet.transform.SetParent(null); // �÷��̾���� ���� ����
    }
}