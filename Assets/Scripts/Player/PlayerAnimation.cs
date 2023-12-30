using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private PlayerJumping Jumping;
    [SerializeField] private PlayerCombat Combat;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        PlayerMovement.OnMove += Move;

        Combat.PrimaryAttack.OnAttack += PrimaryAttack;
        Combat.SecondaryAttack.OnAttack += SecondaryAttack;
    }

    private void Update()
    {
        Jump();
    }

    private void OnDestroy()
    {
        PlayerMovement.OnMove -= Move;

        Combat.PrimaryAttack.OnAttack -= PrimaryAttack;
        Combat.SecondaryAttack.OnAttack -= SecondaryAttack;
    }

    private void Move(InputAction.CallbackContext context)
    {
        anim.SetFloat("HorizontalInput", Mathf.Abs(context.ReadValue<float>()));
    }

    private void Jump()
    {
        anim.SetBool("InAir", !Jumping.OnGround);
    }

    private void PrimaryAttack()
    {
        anim.SetTrigger("PrimaryAttack");
    }

    private void SecondaryAttack()
    {
        anim.SetTrigger("SecondaryAttack");
    }
}