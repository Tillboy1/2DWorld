using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    static public string gameName = "MainMenu";
    static public int SaveFileChoosen = 1;
    public static void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Savefile" + gameName + SaveFileChoosen.ToString() + ".SF";
        FileStream stream = new FileStream(path, FileMode.Create);

        OptionsData data = new OptionsData();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static OptionsData LoadOptions()
    {
        string path = Application.persistentDataPath + "/Savefile" + gameName + SaveFileChoosen.ToString() + ".SF";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            OptionsData data = formatter.Deserialize(stream) as OptionsData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("savefilenot found in " + path);
            return null;
        }
    }
}
