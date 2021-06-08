using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory/Weapon")]
public class Weapon : Equipment
{
    public weaponType _type;
    public int _level;
    public int _damage = 0;
    
    public override string ContentData()
    {
        return (_type + "                   " + "Level: " + _level.ToString() + "\n"
            + "Damage: " + _damage + "\n" + "Durability: " + _durability + "        "
            + "Weight" + _weight + "\n" +_description);
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
