using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public class InventoryPersistence : MonoBehaviour
{
   [SerializeField] Armor soyUnaArmadura;
    string extension = ".dat";
    private void OnEnable()
    {
        Inventory.SaveInventory += SaveFile;
        Inventory.LoadInventory += LoadFile;
    }
    private void OnDisable()
    {
        Inventory.SaveInventory -= SaveFile;
        Inventory.LoadInventory -= LoadFile;

    }
    void CreateFile(string name )
    {
        if (!File.Exists(GetPath()))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(name, FileMode.Create);
            formatter.Serialize(stream, "");
            stream.Close();
        }
    }
    
   public void SaveFile(List<Item> name)
   {
        if (!File.Exists(GetPath()))
        {
            CreateFile(GetPath() + "Inventory" + extension);
        }
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(GetPath() + "Inventory" + extension, FileMode.Open);
        var json = JsonUtility.ToJson(name[0]);
        formatter.Serialize(stream, json);
        stream.Close();
        
   }
   public  void LoadFile(List<Item> name)
   {
        if (File.Exists(GetPath() + "Inventory"))
        {    
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(GetPath() + "Inventory" + extension, FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)formatter.Deserialize(stream), name[0]);
            string algo = "";
            JsonUtility.FromJsonOverwrite((string)formatter.Deserialize(stream), algo);
            Debug.Log(algo);

            stream.Close();
        }
        else
        {
            //CreateFile(name);
        }
   }
    private string GetPath()
    {
        return Application.dataPath +"/SaveInventory/";
    }
}
