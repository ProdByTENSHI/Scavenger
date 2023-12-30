using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Data")] [SerializeField]
    private int DamagePerHit;

    [SerializeField] private float DelayBetweenAttacks;

    [Header("Attack Cast Info")] [SerializeField]
    private Transform AttackTransform;

    [SerializeField] private float AttackRadius;
    [SerializeField] private LayerMask EnemyLayer;

    public Action OnAttack = delegate { };

    private float delayCounter = 0f;
    private bool canAttack = true;

    private void Update()
    {
        if (delayCounter > 0f)
            delayCounter -= Time.deltaTime;

        if (delayCounter <= 0f && !canAttack)
            canAttack = true;
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Started || !canAttack)
            return;

        Collider2D[] foundColls = Physics2D.OverlapCircleAll(AttackTransform.position, AttackRadius, EnemyLayer);
        foreach (Collider2D c in foundColls)
        {
            Enemy enemy = c.GetComponent<Enemy>();
            enemy.Damage(DamagePerHit);
        }

        OnAttack?.Invoke();
        delayCounter = DelayBetweenAttacks;
        canAttack = false;
    }

    private void OnDrawGizmos()
    {
        if (AttackTransform == null)
            AttackTransform = transform;

        Gizmos.DrawWireSphere(AttackTransform.position, AttackRadius);
    }
}