using UnityEngine;

public class SpinPushEnemy : EnemyBase
{
    public float spinSpeed = 360f;
    public float pushForce = 10f;

    protected override void UseAbility()
    {
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }

    protected override void Attack() { }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 pushDir = (other.transform.position - transform.position).normalized;
                rb.AddForce(pushDir * pushForce, ForceMode.Impulse);
            }
        }
    }
}