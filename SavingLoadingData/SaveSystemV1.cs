using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystemV1 : MonoBehaviour
{
    // Make this class a singleton / single instance
    static public SaveSystemV1 instance;
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
    public void SaveGame(GameDataV1 saveData)
    {
        FileStream dataStream = new FileStream(filePath, FileMode.Create);

        BinaryFormatter converter = new BinaryFormatter();
        converter.Serialize(dataStream, saveData);

        dataStream.Close();
    }
    public GameDataV1 LoadGame()
    {
        if(File.Exists(filePath))
        {
        // File exists 
        FileStream dataStream = new FileStream(filePath, FileMode.Open);

        BinaryFormatter converter = new BinaryFormatter();
        GameDataV1 saveData = converter.Deserialize(dataStream) as GameDataV1;

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
