using UnityEngine;

public class Animal : MonoBehaviour, IDamagable
{
    [SerializeField] private float TimeBetweenStateChange;                                  // Time that has to pass since the last State Change to change states again

    [Header("Stats")]
    [SerializeField] private int Health;
    [SerializeField] private int MinOrbDrop;
    [SerializeField] private int MaxOrbDrop;

    private Animator anim;

    private int health;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        health = Health;
    }

    // Changes the State and plays the corresponding Animation
    private void ChangeState()
    {
    }

    public void Damage(int value)
    {
        health -= value;
    }
}