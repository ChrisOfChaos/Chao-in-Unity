using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdpersoncharactercontroller : MonoBehaviour
{
    public float speed;
    public float runspeed;
    public float RotateSpeed;
    public float jumpSpeed;
    public float swimSpeed;
    public float swimUpSpeed;
    public Rigidbody rb;
    private GroundDetector gdetect;
    public GameObject waterDetect;
    public PlayerSwim storedswimarea;
    public GameObject otherGameObject;
    public bool GroundMirror;
    void Awake()
    {
        gdetect = otherGameObject.GetComponent<GroundDetector>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        storedswimarea = waterDetect.GetComponent<PlayerSwim>();
    }
    void Update()
    {
        PlayerMovement();
    }
    void PlayerMovement()
    {
        //GetComponent<Rigidbody>();
        //Rigidbody.freezeRotation = true;
        /*float hor = Input.GetAxis("Horizontal");
        Debug.Log("Camera will rotate");
        transform.Rotate(Vector3.up * hor * RotateSpeed * Time.deltaTime);

        float ver = Input.GetAxis("Vertical");
        Vector3 PlayerMovement = new Vector3(hor, 0f, ver) * speed * Time.deltaTime;
        transform.Translate(PlayerMovement, Space.Self);*/
        if (Input.GetKey(KeyCode.F))
        {
            float hor = Input.GetAxis("Horizontal");
            // Debug.Log("Camera will rotate");
            transform.Rotate(Vector3.up * hor * RotateSpeed * Time.deltaTime);

            float ver = Input.GetAxis("Vertical");
            Vector3 PlayerMovement = new Vector3(hor, 0f, ver) * runspeed * Time.deltaTime;
            transform.Translate(PlayerMovement, Space.Self);
        }
        else
        {
            float hor = Input.GetAxis("Horizontal");
            // Debug.Log("Camera will rotate");
            transform.Rotate(Vector3.up * hor * RotateSpeed * Time.deltaTime);

            float ver = Input.GetAxis("Vertical");
            Vector3 PlayerMovement = new Vector3(hor, 0f, ver) * speed * Time.deltaTime;
            transform.Translate(PlayerMovement, Space.Self);
        }

        /*if(yetAnotherScript.grounded == true)
        {
            GroundMirror = true;
            Debug.Log("Player is grounded.");
        }*/
        GroundMirror = gdetect.grounded;

        if(Input.GetKeyDown (KeyCode.Space) == true && GroundMirror == true)
        {
            if(storedswimarea.inWater == true){
                Debug.LogWarning("Player is swimming upwards");
                rb.AddForce (Vector3.up * jumpSpeed*2, ForceMode.Impulse);
            } else{
                rb.AddForce (Vector3.up * jumpSpeed, ForceMode.Impulse);
            }
        }
        //TEST FOR SWIM CONTROLS
        // if(Input.GetKeyDown (KeyCode.Space) == true && storedswimarea.inWater == true)
        // {
        //     rb.AddForce (Vector3.up * swimSpeed, ForceMode.Impulse);
        // }
        /*void OnTriggerStay(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                Debug.Log("On ground");
                isGrounded = true;
            }
        }
        void OnTriggerExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                Debug.Log("Not on ground");
                isGrounded = false;
            }
        }*/
    }
}