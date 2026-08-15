using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerParticles : MonoBehaviour
{
    [SerializeField] private GameObject _prefExplosionPs;

    private PlayerController _playerController;

    private void Awake() => _playerController = GetComponent<PlayerController>();

    private void OnEnable() => _playerController.OnDeath += OnDeath;
    private void OnDisable() => _playerController.OnDeath -= OnDeath;


    private void OnDeath()
    {
        Instantiate(_prefExplosionPs, transform.position, _prefExplosionPs.transform.rotation);
    } 

}
