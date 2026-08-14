using UnityEngine;
using Zenject;

public class CameraDamageShake : MonoBehaviour
{
    [SerializeField] private string[] _nameClips;
    [Inject] private PlayerController _playerController;

    private Animator _anim;

    private void Awake() => _anim = GetComponent<Animator>();

    private void OnEnable() => _playerController.OnTakeDamage += PlayDamageAnimation;

    private void OnDisable() => _playerController.OnTakeDamage -= PlayDamageAnimation;

    private void PlayDamageAnimation()
    {
        int rnd = Random.Range(0, _nameClips.Length);

        _anim.Play(_nameClips[rnd], 0, 0);
    }
}