using UnityEngine;
using Zenject;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private string[] _nameDamageShakeClips;
    [SerializeField] private string[] _nameEnemyDeadShakeClips;
    [SerializeField] private string[] _nameWeaponAttackShakeClips;
    [Inject] private PlayerController _playerController;
    [Inject] private SignalBus _signalBus;

    private Animator _anim;

    private void Awake() => _anim = GetComponent<Animator>();

    private void OnEnable()
    {
        _playerController.OnTakeDamage += PlayDamageShake;
        _signalBus.Subscribe<EnemyDeadSignal>(PlayEnemyDeadShake);
        _signalBus.Subscribe<WeaponAttackSignal>(PlayWeaponAttackShake);
    }

    private void OnDisable()
    {
        _playerController.OnTakeDamage -= PlayDamageShake;
        _signalBus.Unsubscribe<EnemyDeadSignal>(PlayEnemyDeadShake);
        _signalBus.Unsubscribe<WeaponAttackSignal>(PlayWeaponAttackShake);
    }

    private void PlayDamageShake()
    {
        int rnd = Random.Range(0, _nameDamageShakeClips.Length);

        _anim.Play(_nameDamageShakeClips[rnd], 0, 0);
    }

    private void PlayEnemyDeadShake()
    {
        int rnd = Random.Range(0, _nameEnemyDeadShakeClips.Length);

        _anim.Play(_nameEnemyDeadShakeClips[rnd], 1, 0);
    }

    private void PlayWeaponAttackShake()
    {
        int rnd = Random.Range(0, _nameWeaponAttackShakeClips.Length);

        _anim.Play(_nameWeaponAttackShakeClips[rnd], 0, 0);
    }
}