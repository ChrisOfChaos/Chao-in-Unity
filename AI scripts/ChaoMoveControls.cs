using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoMoveControls : MonoBehaviour {
	public Transform target;
	public Transform waypoint1;
	public Transform waypoint2;
	public Transform waypoint3;
	public Transform waypoint4;
	public int randomnum;
	public float Timer;
	public float animTimer;
	public float wanderTimer;
	public float endTimer;
	public float sleepTimer;
	public Animator anim;
	public bool idling;
	public bool wandering;
	public bool LookForFood;
	public bool Asleep;
	public DetectObjects GetFoodObject;
	public GameObject theBrain;
	public ChaoBrain StoredBrain;
	public GameObject expressions;
	public ChaoExpressions StoredExpressions;

	// Use this for initialization
	void Start () {
		target = waypoint1;
		//I don't really like the default waypoint always being the same on startup. Should probably create a randomize function so that it isn't always the same. This would also provide a
		//solution to the FindFood() glitch, which I solved temporarily by making the waypoint default back to 1.
		LookForFood = false;
		StoredBrain = theBrain.GetComponent<ChaoBrain>();
		StoredExpressions = expressions.GetComponent<ChaoExpressions>();
		GetFoodObject = GetFoodObject.GetComponent<DetectObjects>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//IMPORTANT: WILL PROBABLY HAVE TO CHANGE WHICH FUNCTIONS FIRE BASED ON WHAT OTHER FUNCTIONS ARE TRUE (I.E. CHAIN THEM BASED ON EACH OTHER'S STATUS)
		if(idling == true){
			Idle();
		}
		if(wandering == true){
			Wander();
		}
		if(LookForFood == true){
			FindFood();
		}
		if(Asleep == true){
			Sleep();
		}
	}
	void Idle (){
		//Plays a random idle animation based on stats (needs, happiness, skills, personality, etc.)
		Timer += Time.deltaTime;
		anim.SetBool("idle", true);
		if(Timer >= 5){
			randomnum = Random.Range(1,3);
			animTimer += Time.deltaTime;
				switch(randomnum){
					case 1:
						if(StoredBrain.happiness <= 50){
							anim.SetBool("idle", false);
							anim.SetBool("tantrum", true);
							StoredExpressions.Crying = true;
							if(animTimer >= 5){
								anim.SetBool("tantrum", false);
								anim.SetBool("idle", true);
								//Commented this out because this would be set to true just as the function is exiting. It doesn't make sense to set the idle to true if it will immediately switch
								//to wander.
								// wandering = true;
								idling = false;
								// StoredBrain.wander = true;
								StoredBrain.idle = false;
								StoredExpressions.Crying = false;
								Timer = 0;
								animTimer = 0;
								Debug.Log("Tantrum animation has finished.");
								}
							}
						break;
					case 2:
						if(StoredBrain.Sleep <= 20){
							anim.SetBool("idle", false);
							anim.SetBool("yawn", true);
							StoredExpressions.Yawning = true;
							if(animTimer >= 5){
								anim.SetBool("yawn", false);
								anim.SetBool("idle", true);
								// wandering = true;
								idling = false;
								// StoredBrain.wander = true;
								StoredBrain.idle = false;
								StoredExpressions.Yawning = false;
								Timer = 0;
								animTimer = 0;
								Debug.Log("Yawn animation has finished.");
								}
							}
						break;
				}
				//IMPORTANT NOTE! This function runs correctly on startup but if it runs again after the Wander function, it executes but does not return to wander. Also tried enabling wandering
				//manually and was not able to. So something is forcing wandering to stay false and preventing the wander function from being executed again. I think it is a float that needs to be
				//reset or something along those lines but will need to troubleshoot and take a closer look. SOLVED (endTimer needed to be reset)
		}
	}
	void Wander (){
		// idling = false;
		// StoredBrain.idle = false;
		followtheTarget();
		wanderTimer += Time.deltaTime;
		endTimer += Time.deltaTime;
		if(wanderTimer >= 10){
			randomnum = Random.Range(1,4);
			switch(randomnum){
				case 1:
					target = waypoint1;
					wanderTimer = 0;
					break;
				case 2:
					target = waypoint2;
					wanderTimer = 0;
					break;
				case 3:
					target = waypoint3;
					wanderTimer = 0;
					break;
				case 4:
					target = waypoint4;
					wanderTimer = 0;
					break;
			}
		}
		if(endTimer >= 12){
			Debug.Log("Return to idle");
			//This debug log prints but wander and wandering don't get set to false and idle doesn't become true. WanderTimer does reset. Tried setting Idle to true manually while Wander is 
			//active and it sets to false after two seconds. So it's probably something in the idle function.
			//Checked the debug log and once the timer resets it also prints a Debug Log from the Idle function switch statement. That statement sets wander to true and idle to false. So that
			//is the cause of the problem. Will probably have to set up a new second wander Timer as a workaround. SOLVED
			wanderTimer = 0;
			endTimer = 0;
			wandering = false;
			StoredBrain.wander = false;
			anim.SetBool("crawl", false);
			anim.SetBool("idle", true);
			idling = true;
			StoredBrain.idle = true;
		}
	}
	void Sleep(){
		StoredBrain.sleepfallRate = 0;
		sleepTimer += Time.deltaTime;
		if(sleepTimer >= 10){
			anim.SetBool("Sleep1", true);
			anim.SetBool("Sleep2", false);
			anim.SetBool("Sleep3", false);
			StoredBrain.Sleep = 25;
		} if(sleepTimer >= 20){
			anim.SetBool("Sleep1", false);
			anim.SetBool("Sleep2", true);
			anim.SetBool("Sleep3", false);
			StoredBrain.Sleep = 50;
		} if(sleepTimer >= 30){
			anim.SetBool("Sleep1", false);
			anim.SetBool("Sleep2", false);
			anim.SetBool("Sleep3", true);
			StoredBrain.Sleep = 75;
		} if(sleepTimer >= 40){
			anim.SetBool("Sleep3", false);
			anim.SetBool("wakeup", true);
			StoredBrain.sleepfallRate = 2;
			StoredBrain.sleepy = false;
			Asleep = false;
		}
	}
	void FindFood (){
			if(GetFoodObject.foodInArea.CompareTag("noInteract"))
			{
				target = waypoint1;
				//waypoint must be reset in this if statement or else the Chao tries to follow the placeholder, this is stopgap measure. Maybe take the switch statement from Wander() and
				//make it it's own function? Could call it from here and Wander.
				Debug.Log("No food found!");
				StoredBrain.hungry = false;
				StoredBrain.idle = true;
				LookForFood = false;
			}
			else {
			Vector3 direction = target.position - this.transform.position;
			float angle = Vector3.Angle(direction,this.transform.forward);
			direction.y = 0;//this stops the Chao from floating a few cm into the air
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
			if(direction.magnitude < 5)
			{
				StoredBrain.Hunger = StoredBrain.maxHunger;
				StoredBrain.hungry = false;
				StoredBrain.idle = true;
				// GetFoodObject.foodInArea = GetFoodObject.placeholder;
				// GetFoodObject.foodTransform = GetFoodObject.placeholderTransform;
				//Need a way to destroy the food after Chao eats it. Destroy target doesn't work.
				target = waypoint1;
				//Don't like using this as a stopgap, see comments on FindFood and Start sections.
				//Destroy(GetFoodObject.foodInArea);//Forced to comment this out for now because it is causing too many errors.
				LookForFood = false;
				anim.SetBool("crawl",false);
				anim.SetBool("idle", true);

			}
			if(direction.magnitude > 5)
			{
				this.transform.Translate(0,0,0.15f);
				anim.SetBool("crawl", true);
				anim.SetBool("idle", false);
			}}
	}
	void followtheTarget (){
			Vector3 direction = target.position - this.transform.position;
			float angle = Vector3.Angle(direction,this.transform.forward);
			direction.y = 0;//this stops the Chao from floating a few cm into the air
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
			if(direction.magnitude < 5)
			{
				anim.SetBool("crawl",false);
				anim.SetBool("idle", true);
			}
			if(direction.magnitude > 5)
			{
				this.transform.Translate(0,0,0.15f);
				anim.SetBool("crawl", true);
				anim.SetBool("idle", false);
			}
	}
}
