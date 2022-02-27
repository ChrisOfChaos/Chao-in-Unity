using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chase : MonoBehaviour {
	public Transform player;
	public Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 direction = player.position - this.transform.position;
		float angle = Vector3.Angle(direction,this.transform.forward);
		if(Vector3.Distance(player.position, this.transform.position) < 10 && angle < 30)
		{
			direction.y = 0;

			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
			anim.SetBool("idle",false);
			if(direction.magnitude > 5)
			{
				this.transform.Translate(0,0,0.05f);
				anim.SetBool("crawl",true);
				anim.SetBool("attack", false);
			}
			else
			{
				anim.SetBool("attack",true);
				anim.SetBool("crawl", false);
			}
		}
		else
		{
			anim.SetBool("idle",true);
			anim.SetBool("crawl", false);
			anim.SetBool("attack", false);
		}

		
	}
}
