using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChaoDataManager : MonoBehaviour
{
    public GameObject Chao1;
    public ChaoData1 Chao1Data;
    public string Chao1Name;
    public int Chao1Age;
    // Start is called before the first frame update
    void Start()
    {
        Chao1Data = Chao1.GetComponent<ChaoData1>();
        Chao1Name = Chao1Data.Name;
        Chao1Age = Chao1Data.Age;
    }
}
