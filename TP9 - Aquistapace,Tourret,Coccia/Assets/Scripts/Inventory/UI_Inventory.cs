using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField]
    UI_InventorySlot[] _slots;
    public Transform grid;

    private void OnEnable()
    {
        Inventory.pickUpItem += UpdateUI;
    }
    private void OnDisable()
    {
        Inventory.pickUpItem -= UpdateUI;
    }
    private void Start()
    {
        _slots = grid.GetComponentsInChildren<UI_InventorySlot>();
    }
    
    public void UpdateUI(List<Item> inventory)
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            if (i < inventory.Count)
            {
                _slots[i].AddItem(inventory[i]);
            }
            else
            {
                _slots[i].ClearSlot();
            }
        }
    }
}
