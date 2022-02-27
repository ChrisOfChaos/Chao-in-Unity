using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoDataProfile : MonoBehaviour
{
    public ChaoBehaviorV2 behaviordata;
    public string Name;
    public string Personality;
    public float StoredHunger;
    public float StoredSleep;
    //STATS
    public int SwimStat;
    public int FlyStat;
    public int RunStat;
    public int PowerStat;
    public float Attention;
    public float happiness;
    public GameObject ChaoHead;
    public GameObject ChaoLWing;
    public GameObject ChaoRWing;
    public GameObject ChaoTail;
    SkinnedMeshRenderer Head;
    SkinnedMeshRenderer LWing;
    SkinnedMeshRenderer RWing;
    SkinnedMeshRenderer Tail;
    Renderer ChaoHeadMat;
    public float evolveTimer;
    public float evolveSpeed;//Sets speed at which Chao evolves at.
    public float evolveLevel;
    public bool evolveActive;
    public bool Hero;
    public bool Dark;
    public bool Swim;
    public bool Fly;
    public bool Run;
    public bool Power;
    public int AlignHero;
    /*This script will store all relevant data of a Chao for saving and loading. This includes stats, happiness, emotion/need values at the time of the save, etc. The data
    will be provided by the EggHatch script under normal circumstances, but for now the data will be prefilled out.*/
    // Start is called before the first frame update
    void Start()
    {
        behaviordata = GetComponent<ChaoBehaviorV2>();
        Head = ChaoHead.GetComponent<SkinnedMeshRenderer>();
        ChaoHeadMat = ChaoHead.GetComponent<Renderer>();//Not sure why I copied this over but will leave for now.
        LWing = ChaoLWing.GetComponent<SkinnedMeshRenderer>();
        RWing = ChaoRWing.GetComponent<SkinnedMeshRenderer>();
        Tail = ChaoTail.GetComponent<SkinnedMeshRenderer>();
    }
    void Update()
    {
        StoredHunger = behaviordata.Hunger;
        StoredSleep = behaviordata.Sleep;
    }
    public void IncreaseSwim(){
        Debug.LogWarning("Stat has increased");
        SwimStat+=5;
        Head.SetBlendShapeWeight(1, SwimStat);
    }
    public void IncreaseFly(){
        Debug.LogWarning("Stat has increased");
        FlyStat+=5;
        Head.SetBlendShapeWeight(2, FlyStat);
    }
    public void IncreaseRun(){
        Debug.LogWarning("Stat has increased");
        RunStat+=5;
        Head.SetBlendShapeWeight(3, +5);
    }
    public void IncreasePower(){
        Debug.LogWarning("Stat has increased");
        PowerStat+=5;
        Head.SetBlendShapeWeight(4, +5);
    }
}
