using UnityEngine;

[CreateAssetMenu(fileName = "New Armor", menuName = "Inventory/Armor")]
public class Armor : Item
{
    public armorSlot _slot;
    public int _level;
    public int _defense = 0;
    public string _description;

    public override void Use()
    {
        Debug.Log("Armor " + _itemName);
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

public enum armorSlot { Helmet, Chest, Gloves, Greaves, Boots }