using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveChaoData : MonoBehaviour
{
    public ChaoDataManager GameData;
    string filePath;
    // Start is called before the first frame update
    private void Awake()
    {
        filePath = Application.persistentDataPath + "/save.data";
        
    }
    void Start(){
        GameData = GetComponent<ChaoDataManager>();
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
