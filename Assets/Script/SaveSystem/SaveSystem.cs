using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem 
{
    
    public static void SaveHouses()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream;
        if(File.Exists(path))
        {
            stream = File.OpenWrite(path);
        }
        else
        {
            stream = new FileStream(path, FileMode.Create);
        }
        DataSaved _hous = new DataSaved(1);
        formatter.Serialize(stream, _hous);
        stream.Close();
        Debug.Log("Succes Save");
    }

    public static DataSaved Load()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = File.OpenRead(path);

            DataSaved data = formatter.Deserialize(stream) as DataSaved;
            stream.Close();
            Debug.Log("SUCCES");
            return data;
        }
        else
        {
            Debug.LogError("Some error");
            return null;
        }
    }
}
