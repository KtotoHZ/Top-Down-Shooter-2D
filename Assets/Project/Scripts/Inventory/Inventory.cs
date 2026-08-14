using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory<T> : IInventory<T>
{
    private List<GameObject> _inventoryGm = new();
    private List<T> _inventoryComponent = new();

    public int Count() => _inventoryGm.Count;
    public void AddItem(GameObject item)
    {
        if (item.TryGetComponent(out T component))
        {
            _inventoryGm.Add(item);
            _inventoryComponent.Add(component);
        }
    }
    public void RemoveItem(int index)
    {
        if (index > 0 && index < _inventoryGm.Count && _inventoryGm[index] != null)
        {
            _inventoryGm.RemoveAt(index);
            _inventoryComponent.RemoveAt(index);
        }
    }
    public void ChooseItem(int index)
    {
        if (index > 0 && index < _inventoryGm.Count && _inventoryGm[index] != null)
        {
            for (int i = 0; i < _inventoryGm.Count; i++)
                if (i != index) _inventoryGm[i].SetActive(false);

            _inventoryGm[index].SetActive(true);
        }
    }
    public GameObject ReturnItemObject(int index)
    {
        return _inventoryGm[index];
    }
    public T ReturnItemComponent(int index)
    {
        return _inventoryComponent[index];
    }
}
