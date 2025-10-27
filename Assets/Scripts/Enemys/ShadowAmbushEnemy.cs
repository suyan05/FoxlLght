using UnityEngine;

public class ShadowAmbushEnemy : EnemyBase
{
    public float ambushRange = 5f;
    private bool isVisible = false;

    protected override void UseAbility()
    {
        if (!isVisible && Vector3.Distance(transform.position, player.position) <= ambushRange)
        {
            GetComponent<Renderer>().enabled = true;
            isVisible = true;
        }
    }

    protected override void Attack()
    {
        if (isVisible)
        {
            PlayerHealth health = player.GetComponent<PlayerHealth>();
            if (health != null) health.TakeDamage(attackDamage);
        }
    }

    protected override void Start()
    {
        base.Start();
        GetComponent<Renderer>().enabled = false;
    }
}