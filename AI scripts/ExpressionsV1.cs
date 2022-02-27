using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpressionsV1 : MonoBehaviour
{
    public Material defaulteyes;
    public Material defaultmouth;
    public GameObject eyes;
    public GameObject mouth;
    public GameObject think;
    public GameObject exclamation;
    public GameObject swirl;
    public GameObject heart;
    public GameObject dot;
    public GameObject meaneyelids;
    public GameObject boredeyelids;
    public Material tiredeyes;
    public Material upseteyes;
    public Material asleepeyes;
    public Material happyeyes;
    public Material mouthsmile;
    public Material mouthfrown;
    public Material mouth0;
    public Material mouthwide0;
    public Material mouthwider0;
    public Material mouthdizzy;
    public GameObject Crybox1;
    public GameObject Crybox2;
    public GameObject Crybox3;
    public GameObject Crybox4;
    Renderer eyerend;
    Renderer mouthrend;
    public bool exActive;
    public bool needsfood;
    public bool thinking;
    public bool tired;
    public bool tantrum;
    public bool asleep;
    public bool happy;
    public bool happy0;
    public bool love;
    // Start is called before the first frame update
    void Start()
    {
        eyerend = eyes.GetComponent<Renderer>();
        mouthrend = mouth.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(thinking == true){
            think.SetActive(true);
        } else {
            think.SetActive(false);
        }
        if(love == true){
            dot.SetActive(false);
            heart.SetActive(true);
        } else{
            dot.SetActive(true);
            heart.SetActive(false);
        }
        if(tired == true){
            eyerend.material = tiredeyes;
            mouthrend.material = mouth0;
        }
        if(asleep == true){
            eyerend.material = asleepeyes;
            mouthrend.material = defaultmouth;
        }
        if(happy == true){
            eyerend.material = happyeyes;
            mouthrend.material = mouthsmile;
        }
        if(happy0 == true){
            eyerend.material = happyeyes;
            mouthrend.material = mouth0;
        }
        if(needsfood == true){
            eyerend.material = tiredeyes;
            mouthrend.material = mouthdizzy;
        }
        if(tantrum == true){
            eyerend.material = upseteyes;
            mouthrend.material = mouthwide0;
            Crybox1.SetActive(true);
            Crybox2.SetActive(true);
            Crybox3.SetActive(true);
            Crybox4.SetActive(true);
        }
        if(exActive == false){
            eyerend.material = defaulteyes;
            mouthrend.material = defaultmouth;
            Crybox1.SetActive(false);
            Crybox2.SetActive(false);
            Crybox3.SetActive(false);
            Crybox4.SetActive(false);
        }
    }
}
