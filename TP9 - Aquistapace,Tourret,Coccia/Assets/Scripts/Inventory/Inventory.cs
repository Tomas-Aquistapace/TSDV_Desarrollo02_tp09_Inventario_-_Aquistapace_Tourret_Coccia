using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Action<List<Item>> UpdateInvUI;
    public static Action<Armor[]> UpdateArmorUI;
    int _inventoryLimit=25;
    [SerializeField]
    List<Item> _inventory;
    [SerializeField]
    Armor[] _currentArmor;
    [SerializeField]
    Weapon _currentWeapon;
    int randomItem;
    public List<Item> _listOfAllItems;

    private void OnEnable()
    {
        Armor.armorEquipped += EquipArmor;
    }
    private void OnDisable()
    {
        Armor.armorEquipped -= EquipArmor;
    }
    private void Start()
    {
        int armorSlots = System.Enum.GetNames(typeof(armorSlot)).Length;
        _currentArmor = new Armor[armorSlots];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            randomItem = UnityEngine.Random.Range(0,_listOfAllItems.Count);
            AddToInventory(_listOfAllItems[randomItem]);
        }
    }
    // ----------
    bool AddToInventory(Item newItem)
    {
        if (newItem != null && _inventory.Count < _inventoryLimit)
        {
            _inventory.Add(newItem);
            UpdateInvUI?.Invoke(_inventory);
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
    }

    // ----------

    public void EquipArmor(Armor newArmor)
    {
        int armorSlot = (int)newArmor._slot;
        Armor auxArmor;

        RemoveFromInventory(newArmor);

        if (_currentArmor[armorSlot] != null)
        {
            auxArmor = _currentArmor[armorSlot];

            AddToInventory(auxArmor);
        }
        
        _currentArmor[armorSlot] = newArmor;
        UpdateArmorUI?.Invoke(_currentArmor);
        UpdateInvUI?.Invoke(_inventory);
    }

    public void RemoveArmor(Armor removedArmor)
    {
        int armorSlot = (int)removedArmor._slot;
        if (AddToInventory(removedArmor))
        {
            _currentArmor[armorSlot] = null;
        }
    }

    // ----------
    public void EquipWeapon(Weapon newWeapon)
    {
        Weapon auxWeapon;
        RemoveFromInventory(newWeapon);
        if (_currentWeapon != null)
        {
            auxWeapon = _currentWeapon;

            AddToInventory(auxWeapon);
        }
        _currentWeapon = newWeapon;
    }

    public void RemoveWeapon(Weapon removedWeapon)
    {
        if (AddToInventory(removedWeapon))
        {
            _currentWeapon = null;
        }
    }
}
