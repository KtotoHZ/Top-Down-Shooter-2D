using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private WeaponInventory _weaponInventory;

    [Inject] private IInputPlayer _input;
    private IWeapon _nowWeapon;
    
    private PlayerController _playerController;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
    }

    private void OnEnable()
    {
        _weaponInventory.OnChooseItemComponent += OnWeaponChange;
        _playerController.OnTakeDamage += PlayTakeDamageAnimation;
        _playerController.OnDeath += PlayDeathAnimation;
    }
    private void OnDisable()
    {
        _weaponInventory.OnChooseItemComponent -= OnWeaponChange;
        _playerController.OnTakeDamage -= PlayTakeDamageAnimation;
        _playerController.OnDeath -= PlayDeathAnimation;

        if (_nowWeapon != null)
        {
            _nowWeapon.OnAttack -= PlayAttackAnimation;
            _nowWeapon.OnAlternativeAttack -= PlayAttackAnimation;
        }
    }

    void Update()
    {
        Vector2 moveDirection = _input.GetAxisRaw().normalized;

        Vector2 localDirection = transform.InverseTransformDirection(moveDirection);

        if (_animator != null)
        {
            _animator.SetFloat("Horizontal", localDirection.x);
            _animator.SetFloat("Vertical", localDirection.y);
            _animator.SetBool("IsMoving", moveDirection.magnitude > 0.1f);
        }
    }

    private void PlayTakeDamageAnimation() => _animator.Play("TakeDamage", 1, 0);
    private void PlayAttackAnimation() => _animator.Play("Attack", 1, 0);
    private void PlayDeathAnimation() => _animator.Play("Death", 0, 0);

    private void OnWeaponChange(IWeapon weapon)
    {
        if (_nowWeapon != null)
        {
            _nowWeapon.OnAttack -= PlayAttackAnimation;
            _nowWeapon.OnAlternativeAttack -= PlayAttackAnimation;
        }

        _nowWeapon = weapon;

        if (_nowWeapon != null)
        {
            _nowWeapon.OnAttack += PlayAttackAnimation;
            _nowWeapon.OnAlternativeAttack += PlayAttackAnimation;
        }
    }
}
