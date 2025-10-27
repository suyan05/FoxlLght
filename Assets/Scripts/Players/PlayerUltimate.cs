using UnityEngine;

public class PlayerUltimate : MonoBehaviour
{
    public GameObject blackHolePrefab;
    public Transform spawnPoint;
    public float cooldown = 10f;

    private float lastUsedTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && Time.time >= lastUsedTime + cooldown)
        {
            UseBlackHole();
            lastUsedTime = Time.time;
        }
    }

    void UseBlackHole()
    {
        Instantiate(blackHolePrefab, spawnPoint.position + transform.forward * 5f, Quaternion.identity);
        Debug.Log("±Ã±Ø±â: ºí·¢È¦ ¹ßµ¿!");
    }
}