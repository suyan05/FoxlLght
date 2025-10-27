using UnityEngine;

public class IceTrailEnemy : EnemyBase
{
    public GameObject iceTilePrefab;
    public float trailInterval = 0.5f;
    private float lastTrailTime;

    protected override void UseAbility()
    {
        if (Time.time >= lastTrailTime + trailInterval)
        {
            Instantiate(iceTilePrefab, transform.position, Quaternion.identity);
            lastTrailTime = Time.time;
        }
    }

    protected override void Attack()
    {
        PlayerHealth health = player.GetComponent<PlayerHealth>();
        if (health != null) health.TakeDamage(attackDamage);
    }
}