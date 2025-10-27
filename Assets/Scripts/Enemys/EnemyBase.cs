using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    public float chaseRange = 10f;
    public float attackRange = 2f;
    public float attackCooldown = 1.5f;
    public int attackDamage = 10;

    protected Transform player;
    protected NavMeshAgent agent;
    protected float lastAttackTime;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    protected virtual void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        // 항상 플레이어 바라보기
        Vector3 lookDirection = player.position - transform.position;
        lookDirection.y = 0;
        if (lookDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }

        if (distance <= chaseRange && distance > attackRange)
        {
            agent.SetDestination(player.position);
        }
        else if (distance <= attackRange)
        {
            agent.ResetPath();

            if (Time.time >= lastAttackTime + attackCooldown)
            {
                Attack();
                lastAttackTime = Time.time;
            }
        }
        else
        {
            agent.ResetPath();
        }

        UseAbility();
    }

    protected virtual void LookAtPlayer()
    {
        Vector3 dir = player.position - transform.position;
        dir.y = 0;
        if (dir != Vector3.zero)
        {
            Quaternion rot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 5f);
        }
    }


    protected virtual void Attack()
    {
        PlayerHealth health = player.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(attackDamage);
            Debug.Log($"{gameObject.name}가 공격함 → {attackDamage} 피해");
        }
    }

    protected virtual void UseAbility() { }

}