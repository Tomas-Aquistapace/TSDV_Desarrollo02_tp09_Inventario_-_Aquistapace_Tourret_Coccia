using UnityEngine;


[CreateAssetMenu(fileName = "New Armor", menuName = "Inventory/Armor")]
[System.Serializable]
public class Armor : Equipment
{
    public int _level;
    public int _defense = 0;
    public override string ContentData()
    {
        return (_slot + "                   " + "Level: " + _level.ToString() + "\n"
            + "Defense: " + _defense + "\n" + "Durability: " +  _durability + "        "
            + "Weight: " + _weight + "\n" + _description);
    }
}

