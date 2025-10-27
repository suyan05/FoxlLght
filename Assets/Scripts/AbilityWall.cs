using UnityEngine;

public class AbilityWall : MonoBehaviour
{
    public string requiredAbility = "ShadowPass";

    private void OnTriggerEnter(Collider other)
    {
        PlayerAbility ability = other.GetComponent<PlayerAbility>();
        if (ability != null && ability.HasAbility(requiredAbility))
        {
            // 그림자 통과 가능 → 벽 비활성화 또는 통과 허용
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("그림자 통과 능력이 없으면 지나갈 수 없습니다.");
        }
    }
}