using UnityEngine;

public class PetManager : MonoBehaviour
{
    public GameObject[] pets;
    public Transform player;
    public float followDistance = 3f;
    private int currentPetIndex = -1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchPet();
        }

        if (currentPetIndex >= 0)
        {
            Vector3 followPos = player.position + Vector3.up * 2f - player.forward * followDistance;
            pets[currentPetIndex].transform.position = Vector3.Lerp(pets[currentPetIndex].transform.position, followPos, Time.deltaTime * 5f);
            pets[currentPetIndex].transform.LookAt(player);
        }
    }

    public void UnlockPet(int index)
    {
        if (index >= 0 && index < pets.Length)
        {
            pets[index].SetActive(true);
            if (currentPetIndex == -1)
                currentPetIndex = index;
        }
    }

    void SwitchPet()
    {
        if (currentPetIndex == -1) return;

        pets[currentPetIndex].SetActive(false);
        currentPetIndex = (currentPetIndex + 1) % pets.Length;
        pets[currentPetIndex].SetActive(true);
    }

    public int GetCurrentPetIndex()
    {
        return currentPetIndex;
    }
}