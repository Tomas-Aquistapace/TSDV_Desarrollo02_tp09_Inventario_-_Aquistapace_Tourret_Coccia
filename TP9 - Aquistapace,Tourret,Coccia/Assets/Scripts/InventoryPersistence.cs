using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class InventoryPersistence : MonoBehaviour
{
    [SerializeField] int data = 0;
    [SerializeField] ScriptableObject obj;
    [SerializeField] string fileName = "HOLAAA"; //Nombre estandar de el archivo a crear 
    [SerializeField] string extension = ".dat"; 
    string path ;  //Direccion donde se va a guardar el archivo.

    // Start is called before the first frame update
    void Start()
    {
        path = Application.dataPath + "/";
        //CreateFile(fileName + extension);
        SaveFile(fileName + extension);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Crea un archivo binario usando el path + el nombre del archivo a crear.
    void CreateFile(string name)
    {
        if (!File.Exists(path + name))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path + name, FileMode.Create);
            formatter.Serialize(stream, "");
            stream.Close();
        }

    }
   public void SaveFile(string name)
   {
       if (!File.Exists(path + name))
       {
           CreateFile(name);
       }
       BinaryFormatter formatter = new BinaryFormatter();
       FileStream stream = new FileStream(path + name, FileMode.Open);
       formatter.Serialize(stream, data);
       stream.Close();
   }

}
