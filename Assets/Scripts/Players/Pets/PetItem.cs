using UnityEngine;

public class PetItem : MonoBehaviour
{
    public int petIndex;

    private void OnTriggerEnter(Collider other)
    {
        PetManager manager = other.GetComponent<PetManager>();
        if (manager != null)
        {
            manager.UnlockPet(petIndex);
            Destroy(gameObject);
        }
    }
}