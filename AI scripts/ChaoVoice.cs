using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoVoice : MonoBehaviour
{
    public GameObject voiceBox;
    public AudioSource Voice;
    public AudioClip tantrumcrying2;
    public bool tantrum1;
    public bool playSax1;
    public float Timer;
    public float Counter;
    // Mainly using this to store audio files
    void Start(){
        Voice = voiceBox.GetComponent<AudioSource>();
    }
    void Update(){
        if(tantrum1 == true){
            Timer += Time.deltaTime;
            if(Timer >= 1.5){
                Voice.PlayOneShot(tantrumcrying2);
                Timer = 0;
            }
        }
        // if(playSax1 == true){
        //     Voice.PlayOneShot(tantrumcrying2);
        // }
    }
}
