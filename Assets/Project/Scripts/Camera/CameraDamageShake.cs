using UnityEngine;
using Zenject;

public class CameraDamageShake : MonoBehaviour
{
    [SerializeField] private string _nameClip_1;
    [SerializeField] private string _nameClip_2;
    [Inject] private PlayerController _playerController;

    private Animator _anim;

    private void Awake() => _anim = GetComponent<Animator>();

    private void OnEnable() => _playerController.OnTakeDamage += PlayDamageAnimation;

    private void OnDisable() => _playerController.OnTakeDamage -= PlayDamageAnimation;

    public void PlayDamageAnimation()
    {
        bool rnd = Random.value > 0.5f;
        
        if(rnd) _anim.Play(_nameClip_1, 0, 0);
        else _anim.Play(_nameClip_2, 0, 0);
    }
}