using System.Collections;
using UnityEngine;

public class ChargeEnemy : EnemyBase
{
    public float chargeSpeed = 20f;
    public float chargeDistance = 15f;
    private bool isCharging = false;

    protected override void UseAbility()
    {
        if (!isCharging && Vector3.Distance(transform.position, player.position) <= chargeDistance)
        {
            StartCoroutine(Charge());
        }
    }

    IEnumerator Charge()
    {
        isCharging = true;
        agent.enabled = false;
        Vector3 dir = (player.position - transform.position).normalized;
        float timer = 1f;
        while (timer > 0f)
        {
            transform.position += dir * chargeSpeed * Time.deltaTime;
            timer -= Time.deltaTime;
            yield return null;
        }
        agent.enabled = true;
        isCharging = false;
    }

    protected override void Attack() { }
}