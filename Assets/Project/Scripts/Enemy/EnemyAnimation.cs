using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private string _nameAttackClip;
    [SerializeField] private string _nameDamageClip;
    
    private IEnemy _enemy;

    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _enemy = GetComponent<IEnemy>();
    }

    private void OnEnable()
    {
        _enemy.OnAttack += PlayAttackAnimation;
        _enemy.OnTakeDamage += PlayDamageAnimation;
    }
    private void OnDisable()
    {
        _enemy.OnAttack -= PlayAttackAnimation;
        _enemy.OnTakeDamage -= PlayDamageAnimation;
    }
    private void PlayAttackAnimation()
    {
        _anim.Play(_nameAttackClip, 0, 0);
    }
    private void PlayDamageAnimation()
    {
        _anim.Play(_nameDamageClip, 0, 0);
    }
}
