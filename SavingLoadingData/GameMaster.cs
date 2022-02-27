using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
  public string NewName;
  public GameObject ChaoA1;
  public ChaoBrain2 ChaoA1Stats;
  GameData saveData = new GameData();
  void Start()
  {
    ChaoA1Stats = ChaoA1.GetComponent<ChaoBrain2>();
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
      saveData.A1Name = ChaoA1Stats.ChaoName;
      saveData.A1Age = ChaoA1Stats.Age;
      saveData.A1Happiness = ChaoA1Stats.happiness;
      saveData.A1Personality = ChaoA1Stats.personality;
      saveData.A1Attention = ChaoA1Stats.Attention;
      saveData.A1Hunger = ChaoA1Stats.Hunger;
      saveData.A1Sleep = ChaoA1Stats.Sleep;
      SaveSystem2.instance.SaveGame(saveData);
      Debug.Log("Saved data.");
    }
    if(Input.GetKeyDown(KeyCode.L))
    {
      ChaoA1Stats.ChaoName = saveData.A1Name;
      ChaoA1Stats.Age = saveData.A1Age;
      ChaoA1Stats.happiness = saveData.A1Happiness;
      ChaoA1Stats.personality = saveData.A1Personality;
      ChaoA1Stats.Attention = saveData.A1Attention;
      ChaoA1Stats.Hunger = saveData.A1Hunger;
      ChaoA1Stats.Sleep = saveData.A1Sleep;
      saveData = SaveSystem2.instance.LoadGame();
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