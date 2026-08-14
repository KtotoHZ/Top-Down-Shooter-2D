using UnityEngine;

public class CameraEnemyDeadShake : MonoBehaviour
{
    [SerializeField] private string[] _nameClips;

    private Animator _anim;

    private void Awake() => _anim = GetComponent<Animator>();

    private void OnEnable() => Enemy.OnAnyDeath += PlayDeadAnimation;

    private void OnDisable() => Enemy.OnAnyDeath -= PlayDeadAnimation;

    private void PlayDeadAnimation()
    {
        int rnd = Random.Range(0,_nameClips.Length);

        _anim.Play(_nameClips[rnd], 1, 0);
    }
}
