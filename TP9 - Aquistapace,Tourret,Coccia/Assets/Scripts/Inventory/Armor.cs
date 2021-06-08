using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Armor", menuName = "Inventory/Armor")]
public class Armor : Item
{
    public static Action<Armor> armorEquipped;
    public armorSlot _slot;
    public int _level;
    public int _defense = 0;

    public override void Use()
    {
        Debug.Log("Armor " + _itemName);
        armorEquipped?.Invoke(this);
    }
    public override void LoadFile(string name)
    {
        base.LoadFile(name);
    }
    public override void SaveFile(string name)
    {
        base.SaveFile(name);
    }

    public override string ContentData()
    {
        return (_slot + "                   " + "Level: " + _level.ToString() + "\n"
            + "Defense: " + _defense + "\n" + "Durability: " +  _durability + "        "
            + "Weight: " + _weight + "\n" + _description);
    }
}

public enum armorSlot { Helmet, Chest, Gloves, Greaves, Boots }