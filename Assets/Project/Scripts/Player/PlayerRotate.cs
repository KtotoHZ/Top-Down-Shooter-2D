using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] private float speed = 720f;

    [Inject] private IInputPlayer _input;

    void Update()
    {
        Vector2 dir = _input.RotateVector() - new Vector2(transform.position.x, transform.position.y);

        if (dir.magnitude > 0.1f)
        {
            // —разу вычисл€ем целевой угол с учетом смещени€
            float targetAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            float currentAngle = transform.eulerAngles.z;
            float newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, newAngle);
        }
    }
}
