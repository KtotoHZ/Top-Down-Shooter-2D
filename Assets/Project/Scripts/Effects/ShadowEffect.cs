using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowEffect : MonoBehaviour
{
    [SerializeField] private GameObject _shadowPref;

    [SerializeField] private Vector2 _offset;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Color _color;

    private Transform _myTransform;
    private Transform _shadowTransform;

    private void Awake() => _myTransform = transform;

    void Start()
    {
        _shadowTransform = Instantiate(_shadowPref, _myTransform.position, _myTransform.rotation).transform;

        _shadowTransform.transform.parent = _myTransform;

        SpriteRenderer spriteRenderer = _shadowTransform.gameObject.GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = _sprite;
        spriteRenderer.color = _color;
    }

    void Update()
    {
        _shadowTransform.transform.position = (Vector2)_myTransform.position + _offset;
        _shadowTransform.transform.rotation = _myTransform.rotation;
    }
}
