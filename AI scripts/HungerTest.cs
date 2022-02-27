using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerTest : MonoBehaviour
{
    public float npcHunger;
    public float maxHunger;
    public float hungerfallRate;

    //OBJECTS WITHIN THE NPC'S SIGHT
    public GameObject foodInArea;
    public Transform foodTransform;
    // Start is called before the first frame update
    void Start()
    {
        npcHunger = maxHunger;
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object detected");
        if(other.CompareTag("food")){
            Debug.Log("Food detected");
            foodInArea = other.gameObject;
            foodTransform = foodInArea.GetComponent<Transform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        npcHunger -= Time.deltaTime * hungerfallRate;
        if(npcHunger <= 500){
            Debug.Log("NPC is hungry");
            Vector3 direction = foodTransform.position - this.transform.position;
            float angle = Vector3.Angle(direction,this.transform.forward);
        }
        if(npcHunger <= 100){
            Debug.Log("NPC is starving");
        }
        if(npcHunger <= 0){
            Debug.Log("NPC has died");
        }
    }
    
}
