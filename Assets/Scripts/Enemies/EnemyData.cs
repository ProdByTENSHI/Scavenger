using UnityEngine;

[CreateAssetMenu(menuName="Custom/Enemy Data", fileName="New Enemy Data...")]
public class EnemyData : ScriptableObject
{
    [Header("Basic Data")]
    public string Name;
    public string Description;

    [Header("Entity Data")] 
    public int Hp;
    public int DamagePerHit;
    public float AttackRange;
}