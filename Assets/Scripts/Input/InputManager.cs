using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static Action<InputAction.CallbackContext> OnMove = delegate(InputAction.CallbackContext context) {  };
    public static Action<InputAction.CallbackContext> OnJump = delegate(InputAction.CallbackContext context) {  };
    public static Action<InputAction.CallbackContext> OnPrimaryAttack = delegate(InputAction.CallbackContext context) {  };
    public static Action<InputAction.CallbackContext> OnSecondaryAttack = delegate(InputAction.CallbackContext context) {  };

    public void Move(InputAction.CallbackContext context)
    {
        OnMove?.Invoke(context);
    }
    
    public void Jump(InputAction.CallbackContext context)
    {
        OnJump?.Invoke(context);
    }
    
    public void PrimaryAttack(InputAction.CallbackContext context)
    {
        OnPrimaryAttack?.Invoke(context);
    }
    
    public void SecondaryAttack(InputAction.CallbackContext context)
    {
        OnSecondaryAttack?.Invoke(context);
    }
}