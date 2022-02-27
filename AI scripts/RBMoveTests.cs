using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBMoveTests : MonoBehaviour
{
    public Transform target;
    public Animator anim;
    public Rigidbody ChaoBody;
    public float MoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        MoveSpeed = 10;
        ChaoBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
    }
    // void FixedUpdate()
    // {
    //     FollowTarget();
    // }
    void FollowTarget(){
        // This rigidbody version of the function works but has some issues.
        //--There's a delay when the Chao starts to move, they don't start moving until a few seconds after the function is running.
        //--The speed (regardless of what MoveSpeed is set to) varies a lot. The Chao will shoot forward, then slow down as it reaches it's target.
        //--Movement is very jittery. I know this is common with rigidbody movement though.
		Vector3 direction = target.position - this.transform.position;
		float angle = Vector3.Angle(direction,this.transform.forward);
		direction.y = 0;
		ChaoBody.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
		if(direction.magnitude < 5)
		{
			anim.SetBool("crawl",false);
			// anim.SetBool("idle", true);
		}
		if(direction.magnitude > 5)
		{
            Debug.Log(direction);
            Debug.Log("Chao is following a target");
            ChaoBody.WakeUp();
			ChaoBody.MovePosition(transform.position + (direction.normalized * MoveSpeed * Time.deltaTime));
			anim.SetBool("crawl", true);
			anim.SetBool("idle", false);
		}
    }
}
