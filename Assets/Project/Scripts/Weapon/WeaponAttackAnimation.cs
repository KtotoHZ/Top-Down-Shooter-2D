using UnityEngine;

public class WeaponAttackAnimation : MonoBehaviour
{
    [SerializeField] private string _nameAttackClip = "Attack";

    private Animator _anim;
    private IWeapon _weapon;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _weapon = GetComponent<Weapon>();
    }

    private void OnEnable() => _weapon.OnAttack += PlayAttackAnimation;
    private void OnDisable() => _weapon.OnAttack -= PlayAttackAnimation;

    private void PlayAttackAnimation() => _anim.Play(_nameAttackClip, 0, 0);
}
