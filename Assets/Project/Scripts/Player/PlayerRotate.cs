using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] private float speed = 720f;

    [Inject] private IInputPlayer _input;

    private Rigidbody2D _rb;

    private void Awake() => _rb = GetComponent<Rigidbody2D>();

    void FixedUpdate()
    {
        Vector2 dir = _input.RotateVector() - new Vector2(transform.position.x, transform.position.y);

        if (dir.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            _rb.MoveRotation(Mathf.MoveTowardsAngle(_rb.rotation, targetAngle, speed * Time.fixedDeltaTime));
        }
    }
}
