using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenPool : MonoBehaviour
{
    /*This is going to be where all Chao and empty "slots" are stored in a garden. When finished, the slots will store active Chao (ones that are present and loaded in
    the garden) and unloaded Chao (Chao that haven't had data loaded into them and don't appear in the garden, ie a placeholder for when a new Chao is added)*/
    public GameObject Chao1;
    public GameObject Chao2;
    public GameObject[] fooditems;
    public bool hello;
    // Start is called before the first frame update
    void Start()
    {
        
    }
}
