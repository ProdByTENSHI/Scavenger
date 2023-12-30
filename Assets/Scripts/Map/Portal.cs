using System.Collections;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private AudioClip EnterClip;
    [SerializeField] private AudioClip ExitClip;
    [SerializeField] private Portal EndPoint;       // The Portal to teleport to when entering

    private Animator anim;
    private GameObject player;
    private PlayerMovement movement;

    private const float TIME_BEFORE_TELEPORT = 1.5f;
    private const float TELEPORT_DELAY = 4f;

    private static float delayCounter = 0f;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        player = GameObject.FindWithTag("Player");
        movement = player.GetComponent<PlayerMovement>();

        if (EndPoint == null)
            Debug.Log($"No Endpoint defined for Portal {name}");
    }

    private void Update()
    {
        if (delayCounter > 0f)
            delayCounter -= Time.deltaTime;
    }

    private IEnumerator Teleport()
    {
        movement.CanMove = false;
        player.transform.position = transform.position;
        anim.SetTrigger("Teleport");
        AudioSource.PlayClipAtPoint(EnterClip, transform.position);

        yield return new WaitForSeconds(TIME_BEFORE_TELEPORT);

        player.transform.position = EndPoint.transform.position;
        AudioSource.PlayClipAtPoint(ExitClip, transform.position);
        movement.CanMove = true;
        delayCounter = TELEPORT_DELAY;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (delayCounter > 0f)
            return;

        if (other.CompareTag("Player"))
            StartCoroutine(Teleport());
    }
}