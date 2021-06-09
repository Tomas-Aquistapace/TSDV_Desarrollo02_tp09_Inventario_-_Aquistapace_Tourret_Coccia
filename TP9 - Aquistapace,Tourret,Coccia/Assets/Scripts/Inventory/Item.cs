using UnityEngine;
[System.Serializable]
public class Item : ScriptableObject
{
    public string _itemName = "default";
    public int _id;
    public Sprite _2Dmodel;
    public MeshRenderer _3Dmodel;
    public float _weight;
    public float _durability;
    [Multiline()]
    public string _description;

    public virtual void Use()
    {
        Debug.Log("Used " + _itemName);
    }

    public virtual string ContentData()
    {
        return ("Empty");
    }
}
