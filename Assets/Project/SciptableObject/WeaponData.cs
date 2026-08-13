using UnityEngine;

[CreateAssetMenu(menuName = "SO/Weapon",fileName = "Weapon")]
public class WeaponData : ScriptableObject
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delayAttack;
    [SerializeField] private float _recharge;

    [SerializeField] private Sprite _spriteIcon;

    public int Damage => _damage;
    public float DelayAttack => _delayAttack;
    public float Recharge => _recharge;

    public Sprite SpriteIcon => _spriteIcon;
}
