using UnityEngine;

public class ThrowEnemy : EnemyBase
{
    public GameObject projectilePrefab;
    public Transform throwPoint;
    public float projectileSpeed = 15f;

    protected override void Attack()
    {
        GameObject proj = Instantiate(projectilePrefab, throwPoint.position, Quaternion.identity);
        Rigidbody rb = proj.GetComponent<Rigidbody>();
        Vector3 dir = (player.position - throwPoint.position).normalized;
        rb.velocity = dir * projectileSpeed;
    }
}