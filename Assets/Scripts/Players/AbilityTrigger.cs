using UnityEngine;

public class AbilityTrigger : MonoBehaviour
{
    public PetManager petManager;
    public PlayerAbility ability;

    void Update()
    {
        int petIndex = petManager.GetCurrentPetIndex();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (petIndex == 0) ability.UseAbility("DoubleJump");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (petIndex == 0) ability.UseAbility("Dash");
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            if (petIndex == 1) ability.UseAbility("Heal");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (petIndex == 1) ability.UseAbility("Light");
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (petIndex == 2) ability.UseAbility("Invisible");
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (petIndex == 2) ability.UseAbility("ShadowPass");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (petIndex == 3) ability.UseAbility("Ice");
        }
    }
}