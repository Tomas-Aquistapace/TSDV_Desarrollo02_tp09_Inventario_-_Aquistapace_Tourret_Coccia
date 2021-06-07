using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public abstract class InventoryPersistence : ScriptableObject
{
    string extension = ".dat"; 
    void CreateFile(string name )
    {
        if (!File.Exists(GetPath()))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(GetPath(), FileMode.Create);
            formatter.Serialize(stream, "");
            stream.Close();
        }

    }
   public virtual void SaveFile(string name)
   {
        Debug.Log(GetPath());
        if (!File.Exists(GetPath()))
        {
            CreateFile(name + extension);
        }
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(GetPath(), FileMode.Open);
        var json = JsonUtility.ToJson(this);
        formatter.Serialize(stream, json);
        stream.Close();
        
   }
   public virtual void LoadFile(string name)
   {
        Debug.Log(GetPath());
        if (File.Exists(GetPath()))
        {    
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(GetPath(), FileMode.Open);

            JsonUtility.FromJsonOverwrite((string)formatter.Deserialize(stream), this);
            stream.Close();
        }
        else
        {
            CreateFile(name);
        }
   }
    private string GetPath()
    {
        return Application.dataPath +"/"+ name + extension;
    }
}
