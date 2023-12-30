using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [field: SerializeField] public EnemyData Data { get; private set; }

    public int Hp { get; private set; }

    private void Awake()
    {
        Hp = Data.Hp;
    }

    public void Damage(int amount)
    {
        Hp -= amount;
        if (Hp <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}