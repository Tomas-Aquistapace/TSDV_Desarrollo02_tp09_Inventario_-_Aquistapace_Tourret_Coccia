using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    public UI_InventorySlot[] _slots;

    private void Start()
    {
        _slots = gameObject.GetComponentsInChildren<UI_InventorySlot>();
    }
    
    public void UpdateUI(Inventory inventory)
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            if (i < inventory._inventory.Count)
            {
                _slots[i].AddItem(inventory._inventory[i]);
            }
            else
            {
                _slots[i].ClearSlot();
            }
        }
    }
}
