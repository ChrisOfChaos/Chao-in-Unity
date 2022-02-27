using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameDataV1
{
    public int score = 0;
    public string A1Name;
    public float A1Age;
    public int A1Happiness;
    public string A1Personality;
    public float A1Attention;
    public float A1Hunger;
    public float A1Sleep;
    public void AddScore(int points)
    {
        score += points;
    }
    public void ResetData()
    {
        A1Name = null;
        A1Age = 0;
        A1Happiness = 0;
        A1Personality = null;
        A1Attention = 0;
        A1Hunger = 0;
        A1Sleep = 0;
        score = 0;
    }
}
