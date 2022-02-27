using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PickupChao : MonoBehaviour
{
    public Transform player;
    public Transform PlayerHoldSpot;
    public Transform PlayerLookSpot;
    public Transform PlayerDropSpot;
    public GameObject ChaoDetector;
    public GameObject Chao;
    public CapsuleCollider ChaoCol;
    public Animator anim;
    public AnimatorControllerParameter[] parameters;
    public ChaoBrain2 StoredBrain;
    public ChaoBehavior StoredBehavior;
    public Expressions StoredExpressions;
    public DetectObjects Detector;
    public GameObject infoPanel;
    public Text nameText;
    public bool holdingChao;
    public bool panelActive;
    // Start is called before the first frame update
    void Start()
    {
        Detector = ChaoDetector.GetComponent<DetectObjects>();
        StoredBrain = Chao.GetComponent<ChaoBrain2>();
        StoredBehavior = Chao.GetComponent<ChaoBehavior>();
        StoredExpressions = Chao.GetComponent<Expressions>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Detector.playerNearby == true){
            // Chao.GetComponent<Rigidbody>().Sleep();
            // Comment this out when testing moving Chao with rigidbody, as putting the rigidbody in Sleep stops the Chao's movement.
            if(Input.GetKeyDown(KeyCode.I) && panelActive == false){
                infoPanel.SetActive(true);
                panelActive = true;
                nameText.text = StoredBrain.ChaoName;
            }
            else if(Input.GetKeyDown(KeyCode.I) && panelActive == true){
                infoPanel.SetActive(false);
            }
        }
        if(Detector.playerNearby == false){
            Chao.GetComponent<Rigidbody>().WakeUp();
            infoPanel.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.G) && Detector.playerNearby == true && holdingChao == false){
            StoredBrain.Swim = false;
            StopAnimBools();
            StoredExpressions.thinking = false;
            Debug.Log("HoldingChao is true");
            holdingChao = true;
            StoredBrain.enabled = false;
            StoredBehavior.enabled = false;
            Chao.transform.SetParent(PlayerHoldSpot);
            Chao.transform.position = PlayerHoldSpot.position;
            Chao.transform.Rotate(0.0f,0.0f,0.0f, Space.World);
            Chao.transform.LookAt(PlayerLookSpot);
            Chao.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ; 
            // Chao.GetComponent<Rigidbody>().Sleep();
            // Chao.GetComponent<CapsuleCollider>();
            ChaoCol.enabled = false;
            // Physics.autoSimulation = false;
            // Chao.GetComponent<Rigidbody>().useGravity = false;
            // Chao.GetComponent<Rigidbody>().isKinematic = true;
            // Chao.GetComponent<Rigidbody>().mass = 0;
            // Chao.GetComponent<Rigidbody>().angularDrag = 0;
            // Destroy(Chao.GetComponent<Rigidbody>());
        }
        else if(Input.GetKeyDown(KeyCode.G) && holdingChao == true){
            Chao.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            Chao.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            Debug.Log("HoldingChao is false");
            holdingChao = false;
            StoredBrain.enabled = true;
            StoredBrain.isActive = false;
            StoredBrain.idleWait = 3;
            StoredBrain.wanderEndTimer = 31;
            StoredBehavior.enabled = true;
            ChaoCol.enabled = true;
            // Physics.autoSimulation = true;
            // Chao.GetComponent<Rigidbody>().WakeUp();
            // Chao.AddComponent<Rigidbody>();
            // Chao.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY; 
            // Chao.GetComponent<Rigidbody>().velocity=Vector3.zero;
            // Chao.GetComponent<Rigidbody>().angularVelocity=Vector3.zero;
            Chao.transform.SetParent(null);
            // Chao.GetComponent<Rigidbody>().position = PlayerDropSpot.position;
            Chao.transform.position = PlayerDropSpot.position;
            // Chao.GetComponent<Rigidbody>().position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }
    void StopAnimBools(){
        foreach(AnimatorControllerParameter parameter in anim.parameters) {            
        anim.SetBool(parameter.name, false);            
        }
    }
    //Works pretty well except the Chao floats if set down while moving. In SA2 doing this causes the player to throw the Chao so this shouldn't be a problem. Will just need to update the script
    //to detect if the player is moving when they try to drop the Chao and fire an entirely different result if that's the case.
}