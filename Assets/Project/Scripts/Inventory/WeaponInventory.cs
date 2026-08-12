using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WeaponInventory : MonoBehaviour
{
    [SerializeField] private List<GameObject> _startItem;
    [SerializeField] private Transform _parentWeapon;
    [SerializeField] private int _countMax;
    [Inject] private IInputPlayer _input;
    [Inject] private IInventory<IWeapon> _inventory;

    private int _nowIndex;

    public Action<int> OnChooseItem;
    public Action<GameObject> OnChooseItemGameobject;
    public Action<IWeapon> OnChooseItemComponent;

    private void Start()
    {
        foreach (GameObject gm in _startItem) AddItem(gm);

        ChooseItem(0);
    }
    private void OnEnable()
    {
        _input.OnNextItemClick += NextItem;
        _input.OnPreviewItemClick += PreviewItem;
        _input.OnItemChoose += ChooseItem;
    }
    private void OnDisable()
    {
        _input.OnNextItemClick -= NextItem;
        _input.OnPreviewItemClick += PreviewItem;
        _input.OnItemChoose += ChooseItem;
    }

    private void NextItem()
    {
        _nowIndex++;
        if (_nowIndex >= _inventory.Count()) _nowIndex = 0;

        ChooseItem(_nowIndex);
    }
    private void PreviewItem()
    {
        _nowIndex--;
        if (_nowIndex < 0) _nowIndex = _inventory.Count();

        ChooseItem(_nowIndex);
    }
    private void ChooseItem(int i)
    {
        if (i < 0 || i >= _inventory.Count()) return;

        _nowIndex = i;

        _inventory.ChooseItem(i);

        OnChooseItem?.Invoke(_nowIndex);
        OnChooseItemGameobject?.Invoke(_inventory.ReturnItemObject(_nowIndex));
        OnChooseItemComponent?.Invoke(_inventory.ReturnItemComponent(_nowIndex));
    }

    public void AddItem(GameObject item)
    {
        if (_inventory.Count() < _countMax) 
        {
            _inventory.AddItem(item);

            item.transform.position = _parentWeapon.position;
            item.transform.rotation = _parentWeapon.rotation;
            item.transform.parent = _parentWeapon;
            item.SetActive(false);
        }
    }
}
