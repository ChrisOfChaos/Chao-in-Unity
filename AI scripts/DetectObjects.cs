using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObjects : MonoBehaviour
{
    //OBJECTS WITHIN THE NPC'S SIGHT
    public GameObject player;
    public GameObject foodInArea;
    public Transform foodTransform;
    public GameObject toyInArea;
    public Transform toyTransform;
    public GameObject placeholder;
    public Transform Chao;
    public float ChaoDistance;
    public float ChaoPlayerDistance;
    public Transform placeholderTransform;
    public InventoryPool inventorypool;
    public GameObject theBrain;
	public ChaoBrain2 StoredBrain;
    public ChaoBehavior StoredBehavior;
    public GameObject ChaoMoveController;
    public bool RunWaterDetection;
    public bool playerNearby;
    // Start is called before the first frame update
    void Start()
    {
        StoredBrain = theBrain.GetComponent<ChaoBrain2>();
        StoredBehavior = ChaoMoveController.GetComponent<ChaoBehavior>();
        inventorypool = inventorypool.GetComponent<InventoryPool>();
        foodInArea = placeholder;
        foodTransform = placeholderTransform;
        DistanceCompare();
    }
    void Update()
    {
        checkifPlayerNearby();
        if(StoredBrain.wander == true){
            RunWaterDetection = true;
        }
        if(RunWaterDetection == true){
            SwimDistanceCompare();
        }
    }
    void DistanceCompare(){
        foreach(GameObject food in inventorypool.fooditems){
            ChaoDistance = Vector3.Distance(Chao.transform.position,food.transform.position);
            // Debug.Log(inventorypool.fooditems);
            // Debug.Log(ChaoDistance);
            if(ChaoDistance <= 20){
                // Debug.Log("Food detected");
                foodInArea = food;
                foodTransform = foodInArea.GetComponent<Transform>();
            } else {
                // Debug.Log("No food nearby");
            }
            //Need to compare distance of each food item from Chao and return the closest one.
        }
    }
    void checkifPlayerNearby(){
        ChaoPlayerDistance = Vector3.Distance(Chao.transform.position,player.transform.position);
        if(ChaoPlayerDistance <= 20){
            playerNearby = true;
            // Debug.Log("Player detected");
        } else{
            playerNearby = false;
        }
    }
    void SwimDistanceCompare()
    {
        if(StoredBehavior.target.CompareTag("SwimArea")){
            ChaoDistance = Vector3.Distance(Chao.transform.position,StoredBehavior.target.transform.position);
            if(ChaoDistance <= 10){
                if(StoredBrain.Swim == false){
                    StoredBrain.Swim = true;
                    StoredBrain.wanderEndTimer = 31;
                } else {
                    StoredBrain.ExitWater = true;
                }
                // Debug.Log("Chao is going for a swim");
            }
        }
        if(StoredBehavior.target.CompareTag("SwimExitWaypoint")){
            ChaoDistance = Vector3.Distance(Chao.transform.position,StoredBehavior.target.transform.position);
                if(ChaoDistance <= 15 && StoredBrain.Swim == true){
                    StoredBehavior.ChaoBody.useGravity = true;
                    StoredBehavior.anim.SetBool("drown", false);
                    StoredBrain.Swim = false;
                    StoredBehavior.StayOnGround = true;
                    StoredBrain.isActive = false;
                    StoredBrain.InWater = false;
                    StoredBrain.ExitWater = false;
                    StoredBrain.exitWaterTimer = 0;
                    StoredBrain.swimTimer = 0;
                    StoredBrain.swimEndTimer = 0;
                    StoredBrain.globalTimer = 0;
                    StoredBrain.wanderEndTimer = 0;
                    RunWaterDetection = false;
                }
        }
    }
    //This might have to run in the update, won't work if called in Start because it has to be checked while the Chao is targeting the swim waypoint.
    
}