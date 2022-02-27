using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPool : MonoBehaviour
{
    public GameObject[] fooditems;
    public GameObject sax;
    // Start is called before the first frame update
    void Start()
    {
        fooditems = GameObject.FindGameObjectsWithTag("food");
        foreach(GameObject food in fooditems){
            Debug.Log(fooditems);
        }
    }
}
