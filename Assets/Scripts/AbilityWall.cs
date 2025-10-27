using UnityEngine;

public class AbilityWall : MonoBehaviour
{
    public string requiredAbility = "ShadowPass";

    private void OnTriggerEnter(Collider other)
    {
        PlayerAbility ability = other.GetComponent<PlayerAbility>();
        if (ability != null && ability.HasAbility(requiredAbility))
        {
            // �׸��� ��� ���� �� �� ��Ȱ��ȭ �Ǵ� ��� ���
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("�׸��� ��� �ɷ��� ������ ������ �� �����ϴ�.");
        }
    }
}