using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWeaponUI : MonoBehaviour
{
    [SerializeField] private WeaponInventory _weponInventory;

    [SerializeField] private Image[] _slotBackground;
    [SerializeField] private Image[] _icons;
    [SerializeField] private Color _colorActiveSlot;
    [SerializeField] private Color _colorUnactiveSlot;

    private int _nowIndex;

    private void OnEnable()
    {
        _weponInventory.OnChooseItem += OnChoseWeapon;
        _weponInventory.OnAddItemComponent += OnAddWeapon;
    }
    private void OnDisable()
    {
        _weponInventory.OnChooseItem -= OnChoseWeapon;
        _weponInventory.OnAddItemComponent -= OnAddWeapon;
    }

    public void OnChoseWeapon(int index)
    {
        _slotBackground[_nowIndex].color = _colorUnactiveSlot;

        _nowIndex = index;

        _slotBackground[_nowIndex].color = _colorActiveSlot;
    }
    public void OnAddWeapon(IWeapon weapon)
    {
        _icons[_nowIndex].enabled = true;
        _icons[_nowIndex].sprite = weapon.WeaponData.SpriteIcon; 
    }
}
