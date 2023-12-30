using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [field: SerializeField] public PlayerAttack PrimaryAttack;
    [field: SerializeField] public PlayerAttack SecondaryAttack;
    
    private void Awake()
    {
        InputManager.OnPrimaryAttack += PrimaryAttack.Attack;
        InputManager.OnSecondaryAttack += SecondaryAttack.Attack;
    }

    private void OnDestroy()
    {
        InputManager.OnPrimaryAttack -= PrimaryAttack.Attack;
        InputManager.OnSecondaryAttack -= SecondaryAttack.Attack;
    }
}