using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int _totalSlots;
    public List<Item> _inventory;
    public Armor[] _currentArmor;
    public Weapon _currentWeapon;

    private void Start()
    {
        int armorSlots = System.Enum.GetNames(typeof(armorSlot)).Length;
        _currentArmor = new Armor[armorSlots];
    }

    // ----------

    bool AddToInventory(Item newItem)
    {
        if (newItem != null && _inventory.Count < _totalSlots)
        {
            _inventory.Add(newItem);
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
    }

    public void RemoveArmor(Armor removedArmor)
    {
        int armorSlot = (int)removedArmor._slot;


        if(AddToInventory(removedArmor))
            _currentArmor[armorSlot] = null;


    }

    // ----------

}
