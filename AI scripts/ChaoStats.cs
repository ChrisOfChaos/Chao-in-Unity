using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoStats : MonoBehaviour
{
    public float Age;
    public int AlignHero;
    public int AlignDark;
    public int SaxLesson;
    // Start is called before the first frame update
    /*I think it would be best if I accessed stats from the Brain script instead of calculating them here. Also the save system only accesses the Brain script, so it can't
    save data being calculated in this script, not yet anyway.*/
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Age+=Time.deltaTime;
    }
}
