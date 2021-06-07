﻿using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory/Weapon")]
public class Weapon : Item
{
    public weaponType _type;
    public int _level;
    public int _damage = 0;
    public string _description;

    public override void Use()
    {
        Debug.Log("Weapon " + _itemName);
    }
    public override void LoadFile(string name)
    {
        base.LoadFile(name);
    }
    public override void SaveFile(string name)
    {
        base.SaveFile(name);
    }
}

public enum weaponType { Sword, Axe, Spear, Hammer, Bow, Crossbow }
