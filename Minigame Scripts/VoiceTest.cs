using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceTest : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    public bool testbool;
    public bool startco;
    public float timer1;

    void Start(){
        actions.Add("hi there", Hello);
        actions.Add("I", CheckWhistle);
        actions.Add("make this true", SetBoolTrue);
        actions.Add("make this false", SetBoolFalse);
        actions.Add("Test me out", StartFunction);
        actions.Add("rumors", Rumors);
        actions.Add("forward", Forward);
        actions.Add("up", Up);
        actions.Add("down", Down);
        actions.Add("back", Back);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedWord;
        keywordRecognizer.Start();
    }
    void Update(){
        /*A quick test to see if we could use voice commands to trigger timed functions, which seems to work so far.*/
        if(startco == true){
            hibye();
        }
    }
    private void RecognizedWord(PhraseRecognizedEventArgs speech){
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }
    private void SetBoolTrue(){
        testbool = true;
    }
    private void SetBoolFalse(){
        testbool = false;
    }
    private void StartFunction(){
        timer1 = 0;
        startco = true;
    }
    private void Hello(){
        Debug.Log("How are you?");
    }
    private void CheckWhistle(){
        Debug.Log("You whistled.");
    }
    private void Rumors(){
        Debug.Log("If you've got to travel, by the Nine Divines, stay on the roads! The wilderness just isn't safe anymore. We've had sightings, you see. The Daedra.");
    }
    private void Forward(){
        Debug.Log("Going forward");
    }
    private void Back(){
        Debug.Log("Going back");
    }
    private void Up(){
        Debug.Log("Going up");
    }
    private void Down(){
        Debug.Log("Going down");
    }
    void hibye(){
        timer1++;
        if(timer1 <= 2000){
            Debug.Log("Hello there. You'll only see this for a few seconds.");
        } else{
            Debug.Log("Ok, bye now.");
            startco = false;
        }
    }
}
