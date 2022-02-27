using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoBrain : MonoBehaviour
{
    public bool idle;
    public bool wander;
    public bool hungry;
    public bool sleepy;
    public float Hunger;
    public float maxHunger;
    public float hungerfallRate;
    public float Sleep;
    public float maxSleep;
    public float sleepfallRate;
    public float happiness;
    public GameObject ChaoMoveController;
    public ChaoMoveControls StoredComponent;
    public DetectObjects GetTargetFrom;
    public Transform NearbyFood;
    public GameObject NearbyFoodObject;
    // Start is called before the first frame update
    void Start()
    {
        //SETTING DEFAULT CHAO NEEDS VALUES
        Hunger = maxHunger;
        Sleep = maxSleep;
        StoredComponent = ChaoMoveController.GetComponent<ChaoMoveControls>();
        idle = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Right now these are triggering immediately if the conditions are met. Want to update so that they are checked after an idle animation
        //...would probably be easiest to add && idle is false to if statements, at least for now.
        //Controls Chao's needs decay
        Hunger -= Time.deltaTime * hungerfallRate;
        Sleep -= Time.deltaTime * sleepfallRate;
        //Checking if Chao is hungry, sleeply, etc probably shouldn't happen directly in update, as it will constantly be checked. Should change to be checked during an idle moment.
        if(idle == false){
            wander = true;
            StoredComponent.wandering = true;
        }
        if(idle == false && hungry == true){
            //Maybe store this in a function? Would be easier to organize things.
            NearbyFood = GetTargetFrom.GetComponent<DetectObjects>().foodTransform;
            NearbyFoodObject = GetTargetFrom.GetComponent<DetectObjects>().foodInArea;
            StoredComponent.LookForFood = true;
            StoredComponent.target = NearbyFood;
        }
        if(idle == false && Hunger <= maxHunger / 2){
            hungry = true;
        }
        if(idle == false && Sleep <= maxSleep / 10){
            sleepy = true;
        }
        if(idle == true){
            StoredComponent.idling = true;
        }
        if(idle == false && sleepy == true){
            wander = false;
            hungry = false;
            StoredComponent.wandering = false;
            StoredComponent.LookForFood = false;
            StoredComponent.Asleep = true;
        }
    }
}
