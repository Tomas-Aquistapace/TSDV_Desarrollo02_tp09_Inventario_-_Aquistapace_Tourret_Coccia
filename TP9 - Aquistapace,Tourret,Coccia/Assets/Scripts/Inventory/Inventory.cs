using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Action<List<Item>> UpdateInvUI;
    public static Action<Equipment[]> UpdateEquipmentUI;
    public static Action<List<Item>> SaveInventory;
    public static Action<List<Item>> LoadInventory;
    int _inventoryLimit=25;
    [SerializeField]
    List<Item> _inventory;
    [SerializeField]
    Equipment[] _currentEquipment;
    int randomItem;
    public List<Item> _listOfAllItems;

    private void OnEnable()
    {
        Equipment.equipped += Equip;
        UI_InventorySlot.removeButton += RemoveFromInventory;
        UI_InventorySlot.UnequipButton += Unequip;

        //for (int i = 0; i < _inventory.Count; i++)
        //{
        //    //Debug.Log("load" + casco.name);
        //    //casco.LoadFile(casco.name);
        //}
    }

    private void OnDisable()
    {
        Equipment.equipped -= Equip;
        UI_InventorySlot.removeButton -= RemoveFromInventory;
        UI_InventorySlot.UnequipButton -= Unequip;

       
        //for (int i = 0; i < _inventory.Count; i++)
        //{
        //    _inventory[i].name = i + "_" + _inventory[i]._itemName;
        //}

    }
    private void Start()
    {
        int equipmentSlots = System.Enum.GetNames(typeof(equipmentSlot)).Length;
        _currentEquipment = new Equipment[equipmentSlots];
        LoadInventory?.Invoke(_inventory);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            randomItem = UnityEngine.Random.Range(0,_listOfAllItems.Count);
            //Item item = ScriptableObject.CreateInstance<Item>();
            AddToInventory(_listOfAllItems[randomItem]);
        }
    }
    // ----------

    bool AddToInventory(Item newItem)
    {
        if (newItem != null && _inventory.Count < _inventoryLimit)
        {
            newItem.name = newItem._itemName;
            _inventory.Add(newItem);
            UpdateInvUI?.Invoke(_inventory);
            SaveInventory?.Invoke(_inventory);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RemoveFromInventory(Item removedItem)
    {
        _inventory.Remove(removedItem);
        UpdateInvUI?.Invoke(_inventory); 
    }

    // ----------

    public void Equip(Equipment newEquipment)
    {
        int equipmentSlot = (int)newEquipment._slot;
        Equipment auxEquipment;

        RemoveFromInventory(newEquipment);

        if (_currentEquipment[equipmentSlot] != null)
        {
            auxEquipment = _currentEquipment[equipmentSlot];

            AddToInventory(auxEquipment);
        }

        _currentEquipment[equipmentSlot] = newEquipment;
        UpdateInvUI?.Invoke(_inventory);
        UpdateEquipmentUI?.Invoke(_currentEquipment);
    }

    public void Unequip(int slot)
    {        
        if (AddToInventory(_currentEquipment[slot]))
        {
            _currentEquipment[slot] = null;
            UpdateEquipmentUI?.Invoke(_currentEquipment);
        }
    }
}
