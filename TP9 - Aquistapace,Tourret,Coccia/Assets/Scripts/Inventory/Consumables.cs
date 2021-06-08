using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Inventory/Consumable")]
public class Consumable : Item
{
    public consumableType _type;
    public int _health = 0;
    public int _mana = 0;

    public override void Use()
    {
        Debug.Log("Consumable " + _itemName);
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
        return (_type + "\n" + "Health: " + _health.ToString() + "                "
            + "Mana: " + _mana.ToString() + "\n" + "Durability: " + _durability + "                "
            + "Weight: " + _weight + "\n" + _description);
    }
}

public enum consumableType { Potion, Food }