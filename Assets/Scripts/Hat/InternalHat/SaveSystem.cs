using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    private static string MyPath()
    {
        return Path.Combine(Application.persistentDataPath, "words_in_hat.hat");
    }
    
    public static void Save(InternalHat hat)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = MyPath();
        if (hat.GetLength() == 0) Delete();
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        HatData data = new HatData(hat);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static HatData Load()
    {
        string path = MyPath();
        if (!File.Exists(path)) return new HatData();
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);
        HatData data = (HatData)formatter.Deserialize(stream);
        stream.Close();
        if (data.words == null)
        {
            data = new HatData();
        }
        return data;
    }
    public static void Delete()
    {
        File.Delete(MyPath());
    }

}
