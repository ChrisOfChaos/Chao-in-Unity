using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Swim : MonoBehaviour
{
    public GameObject ChaoInPool1;
    // public ChaoBrain2 Chao1;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Chao")){
            ChaoInPool1 = other.gameObject;
            ChaoInPool1.GetComponent<ChaoBrain2>().Swim = true;
        }
    }
}
