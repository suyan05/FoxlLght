using UnityEngine;
using System.Collections.Generic;

public class PlayerAbility : MonoBehaviour
{
    private HashSet<string> abilities = new HashSet<string>();
    public GameObject lightPrefab;
    public GameObject iceTilePrefab;

    public void AddAbility(string abilityName)
    {
        abilities.Add(abilityName);
    }

    public bool HasAbility(string abilityName)
    {
        return abilities.Contains(abilityName);
    }

    public void UseAbility(string abilityName)
    {
        switch (abilityName)
        {
            case "DoubleJump":
                // 2단 점프는 PlayerMovement에서 처리됨
                break;

            case "Dash":
                DashForward();
                break;

            case "Heal":
                HealPlayer(20);
                break;

            case "Light":
                CreateLight();
                break;

            case "Invisible":
                SetInvisible(true);
                Invoke("ResetInvisibility", 5f);
                break;

            case "ShadowPass":
                AddAbility("ShadowPass"); // 능력 획득
                Debug.Log("그림자 통과 능력 활성화됨");
                break;

            case "Ice":
                CreateIcePath();
                break;
        }
    }

    void DashForward()
    {
        CharacterController cc = GetComponent<CharacterController>();
        Vector3 dashDir = transform.forward * 10f;
        cc.Move(dashDir * Time.deltaTime);
    }

    void HealPlayer(int amount)
    {
        PlayerHealth health = GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.Heal(amount);
        }
    }

    void CreateLight()
    {
        Vector3 pos = transform.position + Vector3.up * 1f;
        Instantiate(lightPrefab, pos, Quaternion.identity);
    }

    void SetInvisible(bool state)
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (var r in renderers)
            r.enabled = !state;
    }

    void ResetInvisibility()
    {
        SetInvisible(false);
    }

    void CreateIcePath()
    {
        Vector3 pos = transform.position + transform.forward * 1f;
        Instantiate(iceTilePrefab, pos, Quaternion.identity);
    }
}