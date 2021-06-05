using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class InventoryPersistence : MonoBehaviour
{
    [SerializeField] int data = 0;
    [SerializeField] string fileName = "Fichero";
    string path = Application.dataPath + "/"; //Direccion donde se va a guardar el archivo.

    // Start is called before the first frame update
    void Start()
    {
        CreateFile(fileName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Crea un archivo binario usando el path + el nombre del archivo a crear.
    public void CreateFile(string name)
    {
        if (!File.Exists(path + name))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path + name, FileMode.Create);
            formatter.Serialize(stream, "");
            stream.Close();
        }

    }
}
