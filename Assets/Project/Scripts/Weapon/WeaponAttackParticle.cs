using UnityEngine;
using Zenject;

public class WeaponAttackParticle : MonoBehaviour
{
    [SerializeField] private GameObject _prefParticle;
    [SerializeField] private Transform _pointParticle;

    [Inject] private IObjectPoolManager _poolManager;

    private IWeapon _weapon;

    private void Awake() => _weapon = GetComponent<IWeapon>();

    private void OnEnable() => _weapon.OnAttack += SpawnParticle;
    private void OnDisable() => _weapon.OnAttack -= SpawnParticle;

    public void SpawnParticle() => 
        _poolManager.SpawnObject(_prefParticle, _pointParticle.position, _pointParticle.rotation);
}
