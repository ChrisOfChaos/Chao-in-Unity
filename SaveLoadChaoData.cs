using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadChaoData : MonoBehaviour
{
    public GameObject StoredChao1;
    public ChaoBrain2 StoredBrain1;
    public bool LoadSaveData;
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("Loading Chao data...");
        // StoredBrain1 = StoredChao1.GetComponent<ChaoBrain2>();
        // StoredBrain1.happiness = PlayerPrefs.GetFloat("Chao1Happiness", 0);
        // StoredBrain1.Hunger = PlayerPrefs.GetFloat("Chao1Hunger", StoredBrain1.maxHunger);
        // StoredBrain1.Sleep = PlayerPrefs.GetFloat("Chao1Sleep", StoredBrain1.maxSleep);
        // StoredBrain1.ChaoName = PlayerPrefs.GetString("Chao1Name", "Nameme");
        // StoredBrain1.personality = PlayerPrefs.GetString("Chao1Personality", "Lazy");
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.C)){
        //     Debug.Log("Saving Chao data...");
        //     PlayerPrefs.SetFloat("Chao1Happiness", StoredBrain1.happiness);
        //     PlayerPrefs.SetFloat("Chao1Hunger", StoredBrain1.Hunger);
        //     PlayerPrefs.SetFloat("Chao1Sleep", StoredBrain1.Sleep);
        //     PlayerPrefs.SetString("Chao1Name", StoredBrain1.ChaoName);
        //     PlayerPrefs.SetString("Chao1Personality", StoredBrain1.personality);
        // }
        // if(Input.GetKeyDown(KeyCode.V)){
        //     Debug.Log("Chao data has been deleted");
        //     PlayerPrefs.DeleteAll();
        // }
    }
}
