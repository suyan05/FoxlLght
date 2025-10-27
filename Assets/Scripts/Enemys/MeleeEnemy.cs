public class MeleeEnemy : EnemyBase
{
    protected override void Attack()
    {
        PlayerHealth health = player.GetComponent<PlayerHealth>();
        if (health != null) health.TakeDamage(attackDamage);
    }
}