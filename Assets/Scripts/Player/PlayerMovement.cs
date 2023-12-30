using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float Speed;

    public bool CanMove = true;

    private Vector3 movementVector = Vector3.zero;
    private float horizontalInput = 0;
    private bool isFacingRight = true;

    public static Action<InputAction.CallbackContext> OnMove = delegate(InputAction.CallbackContext context) { };

    private void Awake()
    {
        InputManager.OnMove += Move;
    }

    private void OnDestroy()
    {
        InputManager.OnMove -= Move;
    }

    private void Update()
    {
        if (!CanMove)
        {
            movementVector = Vector3.zero;
            return;
        }

        if (movementVector != Vector3.zero)
            transform.position += movementVector * (Speed * Time.deltaTime);

        if (isFacingRight && horizontalInput < 0f)
            FlipFacing();
        else if (!isFacingRight && horizontalInput > 0f)
            FlipFacing();
    }

    private void Move(InputAction.CallbackContext context)
    {
        if (!CanMove)
            return;

        horizontalInput = context.ReadValue<float>();
        movementVector = new Vector3(horizontalInput, 0f, 0f);

        OnMove?.Invoke(context);
    }

    private void FlipFacing()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        isFacingRight = !isFacingRight;
    }
}