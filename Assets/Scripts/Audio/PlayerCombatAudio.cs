using UnityEngine;

public class PlayerCombatAudio : MonoBehaviour
{
    [SerializeField] private AudioClip[] PrimaryClips;
    [SerializeField] private AudioClip[] SecondaryClips;

    private PlayerCombat combat;
    private AudioSource source;

    private void Awake()
    {
        combat = GetComponent<PlayerCombat>();
        source = GetComponent<AudioSource>();

        combat.PrimaryAttack.OnAttack += PrimaryAttack;
        combat.SecondaryAttack.OnAttack += SecondaryAttack;
    }

    private void OnDestroy()
    {
        combat.PrimaryAttack.OnAttack -= PrimaryAttack;
        combat.SecondaryAttack.OnAttack -= SecondaryAttack;
    }

    private void PrimaryAttack()
    {
        int clip = Random.Range(0, PrimaryClips.Length - 1);
        source.PlayOneShot(PrimaryClips[clip]);
    }

    private void SecondaryAttack()
    {
        int clip = Random.Range(0, SecondaryClips.Length - 1);
        source.PlayOneShot(SecondaryClips[clip]);
    }
}