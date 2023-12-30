using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJumping : MonoBehaviour
{
    [SerializeField] private AudioClip JumpFX;
    [SerializeField] private float Height;

    public bool OnGround { get; private set; } = true;

    private Rigidbody2D rb;
    private GroundCheck groundCheck;
    
    private void Awake()
    {
        InputManager.OnJump += Jump;

        rb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponentInChildren<GroundCheck>();
    }

    private void Update()
    {
        OnGround = groundCheck.IsOnGround();
    }

    private void OnDestroy()
    {
        InputManager.OnJump -= Jump;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Started || !groundCheck.IsOnGround())
            return;

        rb.AddForce(Vector3.up * Height, ForceMode2D.Impulse);
        AudioSource.PlayClipAtPoint(JumpFX, transform.position);
    }
}