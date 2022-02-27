using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterV1 : MonoBehaviour
{
  public string NewName;
  public GameObject ChaoA1;
  public ChaoBehaviorV2 ChaoA1Behavior;
  public ChaoDataProfile ChaoA1Stats;
  GameDataV1 saveData = new GameDataV1();
  void Start()
  {
    ChaoA1Behavior = ChaoA1.GetComponent<ChaoBehaviorV2>();
    ChaoA1Stats = ChaoA1.GetComponent<ChaoDataProfile>();
  }
  // Update is called once per frame
  void Update()
  {
    if(Input.GetKeyDown(KeyCode.UpArrow))
    {
      saveData.AddScore(1);
      PrintScore();
    }
    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      saveData.AddScore(-1);
      PrintScore();
    }
    if(Input.GetKeyDown(KeyCode.Space))
    {
      saveData.A1Name = ChaoA1Stats.Name;
      saveData.A1Personality = ChaoA1Stats.Personality;
      saveData.A1Hunger = ChaoA1Behavior.Hunger;
      saveData.A1Sleep = ChaoA1Behavior.Sleep;
      SaveSystemV1.instance.SaveGame(saveData);
      Debug.Log("Saved data.");
    }
    if(Input.GetKeyDown(KeyCode.L))
    {
      ChaoA1Stats.Name = saveData.A1Name;
      ChaoA1Stats.Personality = saveData.A1Personality;
      ChaoA1Behavior.Hunger = saveData.A1Hunger;
      ChaoA1Behavior.Sleep = saveData.A1Sleep;
      saveData = SaveSystemV1.instance.LoadGame();
      Debug.Log("Loaded data");
     PrintScore();
    }
    if(Input.GetKeyDown(KeyCode.X))
    {
      saveData.ResetData();
      PrintScore();
    }
    if(Input.GetKeyDown(KeyCode.Alpha1))
    {
      Debug.Log(
        "Chao1 Data: Name: "+saveData.A1Name +
        ",Age: " + saveData.A1Age + 
        ",Happiness: " + saveData.A1Happiness + 
        ",Personality: " + saveData.A1Personality + 
        ",Attention: " + saveData.A1Attention +
        ",Hunger: " + saveData.A1Hunger +
        ",Sleep: " + saveData.A1Sleep);
      print(Application.persistentDataPath);
    }
  }

  void PrintScore()
  {
    Debug.Log("The current score is " + saveData.score);
  }
}