using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField]
    UI_InventorySlot[] _inventorySlots;
    UI_InventorySlot[] _equipmentSlots;
    public Transform grid;
    public Transform layout;

    private void OnEnable()
    {
        Inventory.UpdateInvUI += UpdateInvUI;
        Inventory.UpdateArmorUI += UpdateArmorUI;
    }
    private void OnDisable()
    {
        Inventory.UpdateInvUI -= UpdateInvUI;
        Inventory.UpdateArmorUI -= UpdateArmorUI;
    }
    private void Start()
    {
        _inventorySlots = grid.GetComponentsInChildren<UI_InventorySlot>();
        _equipmentSlots = layout.GetComponentsInChildren<UI_InventorySlot>();
    }
    
    public void UpdateInvUI(List<Item> inventory)
    {
        for (int i = 0; i < _inventorySlots.Length; i++)
        {
            if (i < inventory.Count)
            {
                _inventorySlots[i].AddItem(inventory[i]);
            }
            else
            {
                _inventorySlots[i].ClearSlot();
            }
        }
    }
    public void UpdateArmorUI(Armor[] armor)
    {
        for (int i = 0; i < armor.Length; i++)
        {
            if (armor[i] != null)
            {
                _equipmentSlots[(int)armor[i]._slot].AddItem(armor[i]);
            }
        }
        
    }
}
