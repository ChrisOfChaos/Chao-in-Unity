using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObjects1 : MonoBehaviour
{
    //OBJECTS WITHIN THE NPC'S SIGHT
    public GameObject player;
    public GameObject holdbox;
    public GameObject foodInArea;
    // public Transform foodTransform;
    // public GameObject toyInArea;
    // public Transform toyTransform;
    // public GameObject placeholder;
    public Transform Chao;
    public GameObject nearbyChao;
    public float ChaoDistance;
    public float ChaoPlayerDistance;
    public float itemDist;
    public Transform placeholderTransform;
    public InventoryPool inventorypool;
    public GameObject GardenManagerBox;
    public GardenPool storedpool;
    public GameObject theBrain;
    public ChaoBehaviorV2 StoredBehavior;
    public GameObject ChaoMoveController;
    public bool RunWaterDetection;
    public bool playerNearby;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("checkforNearbyItem", 1, 10);
        StoredBehavior = ChaoMoveController.GetComponent<ChaoBehaviorV2>();
        // inventorypool = inventorypool.GetComponent<InventoryPool>();
        // foodInArea = placeholder;
        // foodTransform = placeholderTransform;
        //DistanceCompare();//Checks if food is nearby at start of script
        /*Might do food differently in this build*/
    }
    void Update()
    {
        checkifPlayerNearby();
        // if(StoredBehavior.wander == true){
        //     RunWaterDetection = true;
        // }
        if(StoredBehavior.Hunger >= StoredBehavior.maxHunger*0.5){
            checkforNearbyItem();
        }
    }
    /*Commented out until it's time to work on the Chao's ability to collect food*/
    // void DistanceCompare(){
    //     foreach(GameObject food in inventorypool.fooditems){
    //         ChaoDistance = Vector3.Distance(Chao.transform.position,food.transform.position);
    //         if(ChaoDistance <= 20){
    //             foodInArea = food;
    //             foodTransform = foodInArea.GetComponent<Transform>();
    //         } else {
                
    //         }
    //     }
    // }
    void checkifPlayerNearby(){
        ChaoPlayerDistance = Vector3.Distance(Chao.transform.position,player.transform.position);
        if(ChaoPlayerDistance <= 20){
            playerNearby = true;
            // Debug.Log("Player detected");
        } else{
            playerNearby = false;
        }
    }
    public void checkforNearbyItem(){
        GardenManagerBox.GetComponent<GardenPool>().hello = true;//Test to make sure GardenPool is being modified correctly.
        // foodInArea = GardenManagerBox.GetComponent<GardenPool>().food1;
        foreach(GameObject item in GardenManagerBox.GetComponent<GardenPool>().fooditems){
            if(item.activeInHierarchy){
                itemDist = Vector3.Distance(Chao.transform.position, item.transform.position);
                if(itemDist <= 100){
                    Debug.LogWarning("Detected food item");
                    foodInArea = item;
                }
            }
        }

    }
    //This might have to run in the update, won't work if called in Start because it has to be checked while the Chao is targeting the swim waypoint.
    
}