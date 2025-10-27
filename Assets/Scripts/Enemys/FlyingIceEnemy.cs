using UnityEngine;

public class FlyingIceEnemy : EnemyBase
{
    public GameObject iceProjectile;
    public Transform firePoint;
    public float patrolHeight = 3f;
    public float fireInterval = 2f;
    public float projectileSpeed = 10f;

    private float lastFireTime;
    private Vector3 basePosition;

    protected override void Start()
    {
        base.Start();
        basePosition = transform.position;
    }

    protected override void UseAbility()
    {
        transform.position = basePosition + Vector3.up * Mathf.Sin(Time.time) * patrolHeight;

        if (Time.time >= lastFireTime + fireInterval)
        {
            GameObject ice = Instantiate(iceProjectile, firePoint.position, Quaternion.identity);
            Rigidbody rb = ice.GetComponent<Rigidbody>();
            Vector3 dir = (player.position - firePoint.position).normalized;
            rb.velocity = dir * projectileSpeed;
            lastFireTime = Time.time;
        }
    }

    protected override void Attack() { }
}