using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowEffect : MonoBehaviour
{
    [SerializeField] private GameObject _shadowPref;
    private GameObject _shadowGm;

    [SerializeField] private Vector2 _offset;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Color _color;
    void Start()
    {
        _shadowGm = Instantiate(_shadowPref, transform.position, transform.rotation);

        _shadowGm.transform.parent = transform;

        SpriteRenderer spriteRenderer = _shadowGm.GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = _sprite;
        spriteRenderer.color = _color;
    }

    void Update()
    {
        _shadowGm.transform.position = (Vector2)transform.position + _offset;
        _shadowGm.transform.rotation = transform.rotation;
    }
}
