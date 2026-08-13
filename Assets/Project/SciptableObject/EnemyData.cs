using UnityEngine;

[CreateAssetMenu(menuName = "SO/Enemy", fileName = "Enemy")]
public class EnemyData : ScriptableObject
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _damage;
    [SerializeField] private float _delayAttack;

    public int MaxHealth => _maxHealth;
    public int Damage => _damage;
    public float DelayAttack => _delayAttack;
}
