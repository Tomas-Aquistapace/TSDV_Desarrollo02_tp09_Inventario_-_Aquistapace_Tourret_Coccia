using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Net;
[CreateAssetMenu(fileName = "SaveInventory", menuName = "Systems/SaveInventory")]
public class InventoryPersistence : ScriptableObject
{
    private void Awake()
    {
        if (!Directory.Exists(Application.persistentDataPath+ "/Saves/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Saves/");
        }
    }
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

   public void SaveFile(List<Item> name)
   {
        string json = JsonUtility.ToJson(name[0]);
        Debug.Log(json);
        if (!File.Exists(Application.persistentDataPath + "/Saves/" + "Inventory.txt"))
        {
            File.Create(Application.persistentDataPath + "/Saves/" + "Inventory.txt");
        }
        else
        {
            File.WriteAllText(Application.persistentDataPath + "/Saves/" + "Inventory.txt", json);
        }
    }
   public  void LoadFile(List<Item> name)
   {
        Weapon AuxArmor;
        Debug.Log("Loading");
        if (File.Exists(Application.persistentDataPath + "/Saves/" + "Inventory.txt"))
        {
            string inventoryString = File.ReadAllText(Application.persistentDataPath + "/Saves/" + "Inventory.txt");
            Debug.Log(inventoryString);
            if (inventoryString != null)
            {
                AuxArmor = JsonUtility.FromJson<Weapon>(inventoryString);
            }
        }
        else
        {
            Debug.Log("Save file not found");
        }
   }
}
