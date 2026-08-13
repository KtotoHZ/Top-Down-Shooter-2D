using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletClassic : MonoBehaviour, ISetDamage
{
    [SerializeField] private float _moveSpeed;
    private int _damage;

    public void SetDamage(int damage) => _damage = damage;
    void Update() => transform.Translate(Vector2.up * _moveSpeed * Time.deltaTime);
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ITakeDamage takeDamage))
        {
            takeDamage.TakeDamage(_damage);

            if (TryGetComponent(out IPoolPart poolPart)) poolPart.Dispose();
            else Destroy(gameObject);
        }
    }
}
