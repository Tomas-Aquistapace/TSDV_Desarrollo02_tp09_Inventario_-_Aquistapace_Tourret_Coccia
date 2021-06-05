using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Inventory/Consumable")]
public class Consumable : Item
{
    public consumableType _type;
    public int _health = 0;
    public int _mana = 0;
    public string _description;

    public override void Use()
    {
        Debug.Log("Consumable " + _itemName);
    }
}

public enum consumableType { Potion, Food }