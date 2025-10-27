using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public float attackRange = 2f;
    public int damage = 20;
    public LayerMask enemyLayer;
    public Transform attackOrigin;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 좌클릭
        {
            PerformMeleeAttack();
        }
    }

    void PerformMeleeAttack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackOrigin.position, attackRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            EnemyHealth health = enemy.GetComponent<EnemyHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }

        Debug.Log("근접 공격!");
    }

    void OnDrawGizmosSelected()
    {
        if (attackOrigin != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackOrigin.position, attackRange);
        }
    }
}