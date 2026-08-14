using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWeaponAttackShake : MonoBehaviour
{
    [SerializeField] private string[] _nameClips;

    private Animator _anim;

    private void Awake() => _anim = GetComponent<Animator>();

    private void OnEnable() => Weapon.OnAnyAttack += PlayAttackAnimation;

    private void OnDisable() => Weapon.OnAnyAttack -= PlayAttackAnimation;

    private void PlayAttackAnimation()
    {
        int rnd = Random.Range(0, _nameClips.Length);

        _anim.Play(_nameClips[rnd], 0, 0);
    }
}
