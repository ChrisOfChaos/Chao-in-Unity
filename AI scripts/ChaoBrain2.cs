﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoBrain2 : MonoBehaviour
{
    public bool Asleep;
    public bool EnterWater;
    public bool ExitWater;
    public bool InWater;
    public bool idle;
    public string ChaoName;
    public string personality;
    //This is just for testing the idle animation, will move to a Stats script at some point.
    public bool pet;
    public bool wander;
    public bool Swim;
    public bool LookForFood;
    public bool isActive;
    public bool canIdle;
    public float Age;
    public float ageTimer;
    public float Attention;
    public float Hunger;
    public float maxHunger;
    public float hungerfallRate;
    public float Sleep;
    public float maxSleep;
    public float sleepfallRate;
    public float storedSleepfallRate;
    public float sleepTimer;
    public int happiness;
    public float idleTimer;
    public float idleEndTimer;
    public float idleWait;
    public float wanderTimer;
    public float wanderEndTimer;
    public float swimTimer;
    public float swimEndTimer;
    public float exitWaterTimer;
    public float globalTimer;
    public GameObject ChaoMoveController;
    public ChaoBehavior StoredBehavior;
    public DetectObjects GetTargetFrom;
    public ChaoStats StoredStats;
    public Transform NearbyFood;
    public GameObject NearbyFoodObject;
    // Start is called before the first frame update
    void Start()
    {
        Attention = 50;
        StoredBehavior = ChaoMoveController.GetComponent<ChaoBehavior>();
        StoredStats = ChaoMoveController.GetComponent<ChaoStats>();
        GetTargetFrom = GetTargetFrom.GetComponent<DetectObjects>();
        //SETTING DEFAULT CHAO NEEDS VALUES
        // Hunger = maxHunger;
        // Sleep = maxSleep;
        //Commented out resetting Hunger and Sleep bc saving Chao data eliminates the need for this. Will set Hunger and Sleep to 100 for first playmode, then save the values.
        // idleEndTimer = 10;
        //Commented out resetting the idleEndTimer bc I don't believe it is needed anymore. It's set after the Chao wakes up anyway. Going to try making the Chao's start behavior randomized.
        StoredBehavior.randomnum = Random.Range(1,3);
        switch(StoredBehavior.randomnum){
            case 1:
                wanderEndTimer = 31;
                break;
            case 2:
                wanderEndTimer = 15;
                break;
            case 3:
                wanderEndTimer = 0;
                break;
                //On this third one, wanderEndTimer is 0 by default so it's a way of saying nothing different happens
        }
    }

    // Update is called once per frame
    void Update()
    {
        Age+=Time.deltaTime;
        //NEEDS DECAY
        Hunger -= Time.deltaTime * hungerfallRate;
        Sleep -= Time.deltaTime * sleepfallRate;
        // if(Hunger <= 20 && isActive == false){
        // LookForFood = true;
        // isActive = true;
        // }
        // if(Sleep <= 20 && isActive == false){
        // Asleep = true;
        // isActive = true;
        // }
        // //When increasing hunger and sleep in behavior it can't be done gradually, or else the above statements will stop running as soon as the value is above what is dictated in the if statement. (i.e. as soon as sleep goes above 20 the statement will stop running even if the Chao has only rested for a few seconds)
        // if(wanderEndTimer == 0 && isActive == false){
        // wander = true;
        // isActive = true;
        // }
        // if(wanderEndTimer >= 30 && isActive == false){
        // wander = false;
        // idle = true;
        // isActive = true;
        // //wanderEndTimer would need to be reset at some point, probably at end of Idle
        // }
        if(Input.GetKeyDown(KeyCode.E) && GetTargetFrom.playerNearby == true){
            pet = true;
            // Debug.Log("Chao is being pet");
        }
        if(isActive == false){
            idleWait += Time.deltaTime;
            if(Swim == false){
                
                if(idleWait >= 3){
                    idle = true;
                    isActive = true;
                }
                if(wanderEndTimer <= 30){
                    wander = true;
                    isActive = true;
                }
                if(Hunger <= 20){
                    LookForFood = true;
                    isActive = true;
                    //isActive must be set to false in behavior script
                }
                if(Sleep <= 30 && isActive == false){
                    //Not sure why I had to check if isActive is false here. If I don't Asleep becomes true in the middle of other behaviors. No idea why. Will experiment with this and try to
                    //figure out what's going on but the current solution (adding  && isActive == false) is working so it's not a huge concern to me.
                    Asleep = true;
                    isActive = true;
                }
            } else{
                isActive = true;
            }
        }
        if(idleWait <= 3){
            idle = false;
        }
        if(wanderEndTimer >= 30){
            wander = false;
        }
        if(Hunger >= 20){
            LookForFood = false;
        }
        if(Sleep >= 30){
            Attention -= Time.deltaTime /10;
            Asleep = false;
        }
    }
}