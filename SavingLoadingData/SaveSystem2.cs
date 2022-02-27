using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem2 : MonoBehaviour
{
    // Make this class a singleton / single instance
    static public SaveSystem2 instance;
    string filePath;
    private void Awake()
    {
        filePath = Application.persistentDataPath + "/save.data";
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SaveGame(GameData saveData)
    {
        FileStream dataStream = new FileStream(filePath, FileMode.Create);

        BinaryFormatter converter = new BinaryFormatter();
        converter.Serialize(dataStream, saveData);

        dataStream.Close();
    }
    public GameData LoadGame()
    {
        if(File.Exists(filePath))
        {
        // File exists 
        FileStream dataStream = new FileStream(filePath, FileMode.Open);

        BinaryFormatter converter = new BinaryFormatter();
        GameData saveData = converter.Deserialize(dataStream) as GameData;

        dataStream.Close();
        return saveData;
        }
        else
        {
            // File does not exist
            Debug.LogError("Save file not found in " + filePath);
            return null;
        }
    }
}
