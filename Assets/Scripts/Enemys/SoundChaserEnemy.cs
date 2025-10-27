using UnityEngine;

public class SoundChaserEnemy : EnemyBase
{
    public float soundChaseSpeed = 12f;
    private Vector3 soundPosition;
    private bool chasingSound = false;

    public void HearSound(Vector3 position)
    {
        soundPosition = position;
        chasingSound = true;
        agent.speed = soundChaseSpeed;
        agent.SetDestination(soundPosition);
    }

    protected override void UseAbility()
    {
        if (chasingSound && Vector3.Distance(transform.position, soundPosition) < 1f)
        {
            chasingSound = false;
            agent.speed = 3.5f;
        }
    }

    protected override void Attack()
    {
        PlayerHealth health = player.GetComponent<PlayerHealth>();
        if (health != null) health.TakeDamage(attackDamage);
    }
}