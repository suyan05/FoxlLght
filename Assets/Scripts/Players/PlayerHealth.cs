using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public delegate void OnHealthChanged(int current, int max);
    public event OnHealthChanged onHealthChanged;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        Debug.Log($"ü�� ȸ����: {amount} �� ���� ü��: {currentHealth}/{maxHealth}");
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log($"���� ����: {amount} �� ���� ü��: {currentHealth}/{maxHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("�÷��̾ ����߽��ϴ�.");
        // ��� ó�� ���� (��: ������, ���� ���� ��)
    }

    public int GetCurrentHealth() => currentHealth;
    public int GetMaxHealth() => maxHealth;
}