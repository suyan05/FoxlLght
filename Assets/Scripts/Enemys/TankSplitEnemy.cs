using UnityEngine;

public class TankSplitEnemy : EnemyBase
{
    protected override void Attack()
    {
        PlayerHealth health = player.GetComponent<PlayerHealth>();
        if (health != null) health.TakeDamage(attackDamage);
    }
}

public class TankSplitHealth : EnemyHealth
{
    public GameObject splitPrefab;

    protected override void Die()
    {
        Instantiate(splitPrefab, transform.position, Quaternion.identity);
        base.Die();
    }
}