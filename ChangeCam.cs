using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCam : MonoBehaviour
{
    public GameObject PlayerCam;
    public GameObject Chao1Cam;
    public GameObject Chao2Cam;
    public bool ChaoCamActive;
    public int toggle;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            toggle++;
            if(toggle == 1){
                PlayerCam.SetActive(false);
                Chao1Cam.SetActive(true);
            }
            if(toggle == 2){
                Chao1Cam.SetActive(false);
                Chao2Cam.SetActive(true);
            }
            if(toggle == 3){
                Chao2Cam.SetActive(false);
                PlayerCam.SetActive(true);
                toggle = 0;
            }
            // if(ChaoCamActive == false){
            //     ChaoCamActive = true;
            //     PlayerCam.SetActive(false);
            //     ChaoCam.SetActive(true);
            // } else {
            //     PlayerCam.SetActive(true);
            //     ChaoCam.SetActive(false);
            //     ChaoCamActive = false;
            // }
        }
    }
}
