using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectDetect : MonoBehaviour
{
    public GameObject theBrain;
	public ChaoBrain2 StoredBrain;
    public ChaoBehavior StoredBehavior;
    public GameObject ChaoMoveController;
    
    // Start is called before the first frame update
    void Start()
    {
        StoredBrain = theBrain.GetComponent<ChaoBrain2>();
        StoredBehavior = ChaoMoveController.GetComponent<ChaoBehavior>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SwimEntryWaypoint")){
            Debug.Log("Collision detected");
            if(StoredBrain.Swim == false){
                StoredBrain.Swim = true;
                StoredBrain.wanderEndTimer = 31;
            } else {
                StoredBrain.ExitWater = true;
            }
        }
        if(other.CompareTag("SwimExitWaypoint") && StoredBrain.Swim == true){
            StoredBehavior.anim.SetBool("drown", false);
            StoredBrain.Swim = false;
            StoredBrain.isActive = false;
            StoredBrain.InWater = false;
            StoredBrain.ExitWater = false;
            StoredBrain.exitWaterTimer = 0;
            StoredBrain.swimTimer = 0;
            StoredBrain.swimEndTimer = 0;
            StoredBrain.globalTimer = 0;
            StoredBrain.wanderEndTimer = 0;
        }
    }
}
