using UnityEngine;

public class Item : ScriptableObject
{
    public string _itemName = "default";
    public Sprite _sprite;
    public int _id;

    public virtual void Use()
    {
        Debug.Log("Used "+ _itemName);
    }
}
