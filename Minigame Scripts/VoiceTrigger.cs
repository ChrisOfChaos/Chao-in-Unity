using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceTrigger : MonoBehaviour
{
    public GameObject VoiceBox;
    public bool vbActive;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.C) && vbActive == false){
            VoiceBox.SetActive(true);
            vbActive = true;
        } else if(Input.GetKeyUp(KeyCode.C) && vbActive == true){
            VoiceBox.SetActive(false);
            vbActive = false;
        }
    }
}
