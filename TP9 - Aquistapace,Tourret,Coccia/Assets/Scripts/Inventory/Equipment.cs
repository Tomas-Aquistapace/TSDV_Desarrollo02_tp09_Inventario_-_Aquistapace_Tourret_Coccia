
using System;
[System.Serializable]
public class Equipment : Item
{
    public equipmentSlot _slot;
    public static Action<Equipment> equipped;
    public override void Use()
    {
        equipped?.Invoke(this);
    }
}
public enum equipmentSlot { Helmet, Chest, Gloves, Greaves, Boots, Weapon}