using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField]
    UI_InventorySlot[] _inventorySlots;
    [SerializeField]
    UI_InventorySlot[] _equipmentSlots;
    public Transform grid;
    public Transform layout;

    private void OnEnable()
    {
        Inventory.UpdateInvUI += UpdateInvUI;
        Inventory.UpdateEquipmentUI += UpdateEquipmentUI;
    }
    private void OnDisable()
    {
        Inventory.UpdateInvUI -= UpdateInvUI;
        Inventory.UpdateEquipmentUI -= UpdateEquipmentUI;
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
    public void UpdateEquipmentUI(Equipment[] equipment)
    {
        for (int i = 0; i < equipment.Length; i++)
        {
            if (equipment[i] != null)
            {
                _equipmentSlots[(int)equipment[i]._slot].AddItem(equipment[i]);
            }
            else
            {
                _equipmentSlots[i].ClearSlot();
            }
        }
        
    }
}
