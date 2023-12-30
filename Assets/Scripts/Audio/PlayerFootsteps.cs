using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFootsteps : MonoBehaviour
{
    [SerializeField] private float MinTimeBetweenFootstep = 0.4f;
    [SerializeField] private AudioClip[] Clips;
    [SerializeField] private GroundCheck GroundCheck;

    private AudioSource source;
    private float footstepDelay;
    private bool isRunning;

    private void Awake()
    {
        source = GetComponent<AudioSource>();

        PlayerMovement.OnMove += Move;
    }

    private void OnDestroy()
    {
        PlayerMovement.OnMove -= Move;
    }

    private void Update()
    {
        if (footstepDelay > 0f)
        {
            footstepDelay -= Time.deltaTime;
            return;
        }

        if (!isRunning|| !GroundCheck.IsOnGround())
            return;

        int nextSound = Random.Range(0, Clips.Length - 1);
        source.PlayOneShot(Clips[nextSound]);
        footstepDelay = Random.Range(MinTimeBetweenFootstep, MinTimeBetweenFootstep * 1.15f);
    }

    private void Move(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Canceled)
        {
            isRunning = false;
            return;
        }

        isRunning = true;
    }
}