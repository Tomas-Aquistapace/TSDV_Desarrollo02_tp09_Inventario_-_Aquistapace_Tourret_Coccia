using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Action<List<Item>> pickUpItem;
    int _inventoryLimit=25;
    [SerializeField]
    List<Item> _inventory;
    Armor[] _currentArmor;
    Weapon _currentWeapon;

    int randomItem;
    public List<Item> _listOfAllItems;


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
    private void OnEnable()
    {
        for (int i = 0; i < _inventory.Count; i++)
        {
            //Debug.Log("load" + casco.name);
            //casco.LoadFile(casco.name);
        }
    }
    private void OnDisable()
    {
        for (int i = 0; i < _inventory.Count; i++)
        {
            //Debug.Log("save " + casco.name);
            _inventory[i].SaveFile(_inventory[i].name);
        }
    }
    // ----------

    bool AddToInventory(Item newItem)
    {
        if (newItem != null && _inventory.Count < _inventoryLimit)
        {
            _inventory.Add(newItem);
            pickUpItem?.Invoke(_inventory);
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
