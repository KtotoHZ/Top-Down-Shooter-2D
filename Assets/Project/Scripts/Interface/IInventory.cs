using UnityEngine;

public interface IInventory<T>
{
    int Count();
    void AddItem(GameObject item);
    void RemoveItem(int index);
    public void ChooseItem(int index);
    GameObject ReturnItemObject(int index);
    T ReturnItemComponent(int index);
}
