using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float duration = 5f;
    public float pullForce = 50f;
    public float damagePerSecond = 10f;
    public float radius = 5f;

    private float timer;

    void Start()
    {
        timer = duration;
        Destroy(gameObject, duration);
    }

    void Update()
    {
        timer -= Time.deltaTime;

        Collider[] targets = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider col in targets)
        {
            EnemyHealth enemy = col.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                Vector3 dir = (transform.position - col.transform.position).normalized;
                Rigidbody rb = col.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddForce(dir * pullForce * Time.deltaTime, ForceMode.Acceleration);
                }

                enemy.TakeDamage(Mathf.RoundToInt(damagePerSecond * Time.deltaTime));
            }
        }
    }
}