using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoBehavior : MonoBehaviour
{
    public Transform target;
	public Transform waypoint1;
	public Transform waypoint2;
	public Transform waypoint3;
	public Transform waypoint4;
	public Transform waypoint5;
	public Transform waypoint6;
	public Transform waypoint7;
	public Transform waypoint8;
    public Transform swimpoint1;
    public Transform swimpoint2;
    public Transform swimpoint3;
    public Transform swimpoint4;
    public Transform swimpoint5;
    public Transform swimpoint6;
    public Transform swimpoint7;
    public Transform swimpoint8;
    public Transform jumpWaterPoint1;
    public Transform jumpWaterPoint2;
    public Transform jumpWaterExitPoint;
    public Transform jumpWaterExitPoint2;
    public bool ExitingWater;
    public bool StayOnGround;
	public GameObject theBrain;
	public ChaoBrain2 StoredBrain;
    public ChaoVoice StoredVoice;
    public ChaoStats StoredStats;
    public Rigidbody ChaoBody;
    public Expressions expressions;
    public Animator anim;
    public AnimatorControllerParameter[] parameters;
    public int randomnum;
    public int randomnumonce;
    public DetectObjects GetObject;
    public GameObject sax;
    public int hasyawned;
    public int hascried;
    public int haswaved;
    public int hasbowed;
    public int hasfoodsighed;
    public int hasgonetoplayer;
    public int hasplayedsax;
    public float MoveSpeed;
    public float fallSpeed;
    // Start is called before the first frame update
    void Start()
    {
        StayOnGround = true;
        target = waypoint1;
        StoredBrain = theBrain.GetComponent<ChaoBrain2>();
        StoredVoice = theBrain.GetComponent<ChaoVoice>();
        StoredStats = theBrain.GetComponent<ChaoStats>();
        GetObject = GetObject.GetComponent<DetectObjects>();
        ChaoBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        expressions = GetComponent<Expressions>();
        MoveSpeed = 60f;
        fallSpeed = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        if(StoredBrain.pet == true){
            StoredBrain.globalTimer += Time.deltaTime;
            StopAnimBools();
            anim.SetBool("idle", true);
            expressions.thinking = false;
            expressions.love = true;
            if(StoredBrain.globalTimer >= 3){
                StoredBrain.happiness++;
                StoredBrain.Attention+= 10;
                StoredBrain.pet = false;
                expressions.love = false;
                anim.SetBool("idle", false);
                StoredBrain.globalTimer = 0;
            }
        } else {
            if(StoredBrain.Swim == true){
                // Debug.Log("Chao is going for a swim");
                Swim();
            }
            if(StoredBrain.idle == true){
                // Debug.Log("Chao is idling");
                Idle();
            }
            if(StoredBrain.wander == true){
                // Debug.Log("Chao has begun to wander");
                Wander();
            }
            if(StoredBrain.LookForFood == true){
                // Debug.Log("Chao will look for food");
                LookForFood();
            }
            if(StoredBrain.Asleep == true){
                // Debug.Log("Chao has fallen asleep");
                Asleep();
            }
            //
        }
        if(StayOnGround == true){
            ChaoBody.AddForce(-transform.up * fallSpeed);
        }
    }
    void Idle(){
        StoredBrain.idleTimer += Time.deltaTime;
        StoredBrain.idleEndTimer += Time.deltaTime;
        if(StoredBrain.idleEndTimer <= 30){
            anim.SetBool("think", true);
            expressions.thinking = true;
            if(StoredBrain.idleTimer >= 1.8){
                RandomNumOnce();
                if(StoredBrain.personality.Equals("Crybaby") && randomnumonce == 1){
                    expressions.thinking = false;
                    expressions.tantrum = true;
                    expressions.exActive = true;
                    anim.SetBool("think", false);
                    anim.SetBool("tantrum", true);
                    // StoredVoice.tantrum1 = true;//No crying sound attached to Chao, so I'm commenting this out for now.
                    if(StoredBrain.idleTimer >= 6){
                        hascried++;
                        StopAnimBools();
                        // StoredVoice.tantrum1 = false;//Commented out for the reason above
                        expressions.tantrum = false;
                        expressions.exActive = false;
                        StoredBrain.idleTimer = 0;
                        StoredBrain.idleEndTimer = 30;
                    }
                }
                if(StoredBrain.personality.Equals("Lazy") && randomnumonce == 1){
                    expressions.thinking = false;
                    expressions.tired = true;
                    expressions.exActive = true;
                    anim.SetBool("think", false);
                    anim.SetBool("yawn", true);
                    if(StoredBrain.idleTimer >= 4){
                        hasyawned++;
                        StopAnimBools();
                        expressions.tired = false;
                        expressions.exActive = false;
                        StoredBrain.idleTimer = 0;
                        StoredBrain.idleEndTimer = 30;
                    }
                }
                if(StoredBrain.personality.Equals("Energetic") && randomnumonce == 1){
                    expressions.thinking = false;
                    expressions.happy = true;
                    expressions.exActive = true;
                    anim.SetBool("think", false);
                    anim.SetBool("wave", true);//Placeholder for an energetic behavior animation
                    if(StoredBrain.idleTimer >= 6){
                        haswaved++;
                        StopAnimBools();
                        expressions.happy = false;
                        expressions.exActive = false;
                        StoredBrain.idleTimer = 0;
                        StoredBrain.idleEndTimer = 30;
                    }
                }
                if(randomnumonce == 2){
                    expressions.thinking = false;
                    expressions.happy = true;
                    expressions.exActive = true;
                    anim.SetBool("think", false);
                    anim.SetBool("bow", true);
                        if(StoredBrain.idleTimer >= 3.425){
                            hasbowed++;
                            StopAnimBools();
                            expressions.happy = false;
                            expressions.exActive = false;
                            StoredBrain.idleTimer = 0;
                            StoredBrain.idleEndTimer = 30;
                    }
                }
                if(randomnumonce == 3){
                    if(StoredBrain.Hunger <= 20){
                        expressions.thinking = false;
                        anim.SetBool("think", false);
                        anim.SetBool("bow", true);
                        expressions.needsfood = true;
                        expressions.exActive = true;
                        if(StoredBrain.idleTimer >= 3.425){
                            hasfoodsighed++;
                            StopAnimBools();
                            expressions.needsfood = false;
                            expressions.exActive = false;
                            StoredBrain.idleTimer = 0;
                            StoredBrain.idleEndTimer = 30;
                        }
                    } else {
                        expressions.thinking = false;
                        anim.SetBool("think", false);
                        StoredBrain.idleTimer = 0;
                        StoredBrain.idleEndTimer = 30;
                    }
                }
                if(randomnumonce == 4){
                        if(StoredBrain.Attention <= 20){
                        expressions.thinking = false;
                        anim.SetBool("think", false);
                        anim.SetBool("crawl", true);
                        expressions.happy = true;
                        expressions.exActive = true;
                        target = GetObject.player.transform;
                        followtheTarget();//I think I'm going to make a variation of followtheTarget specifically for following the player, will give me control over Chao's behavior once they stop.
                        if(StoredBrain.idleTimer >= 9.425){
                            hasgonetoplayer++;
                            StopAnimBools();
                            target = waypoint1;
                            expressions.happy = false;
                            expressions.exActive = false;
                            StoredBrain.idleTimer = 0;
                            StoredBrain.idleEndTimer = 30;
                        }
                    } else if(GetObject.ChaoPlayerDistance <= 50){
                            expressions.thinking = false;
                            expressions.happy = true;
                            expressions.exActive = true;
                            anim.SetBool("think", false);
                            anim.SetBool("wave", true);
                            target = GetObject.player.transform;
                            TurnToTarget();
                            // Debug.Log("Chao turns to player and waves");
                            if(StoredBrain.idleTimer >= 3.425){
                                StopAnimBools();
                                target = waypoint1;
                                expressions.happy = false;
                                expressions.exActive = false;
                                StoredBrain.idleTimer = 0;
                                StoredBrain.idleEndTimer = 30;
                        }
                    } else {
                            expressions.thinking = false;
                            anim.SetBool("think", false);
                            // Debug.Log("Chao is relaxing");
                            if(StoredBrain.idleTimer >= 9.425){
                                hasgonetoplayer++;
                                StopAnimBools();
                                target = waypoint1;
                                expressions.happy = false;
                                expressions.exActive = false;
                                StoredBrain.idleTimer = 0;
                                StoredBrain.idleEndTimer = 30;
                        }
                    }
                }
                if(randomnumonce == 5){
                    expressions.thinking = false;
                    anim.SetBool("think", false);
                    if(StoredStats.SaxLesson == 1){
                        expressions.happy0 = true;
                        expressions.exActive = true;
                        anim.SetBool("playSax", true);
                        sax.SetActive(true);
                        if(StoredBrain.idleTimer >= 13){
                            hasplayedsax++;
                            anim.SetBool("playSax", false);
                            sax.SetActive(false);
                            expressions.happy0 = false;
                            expressions.exActive = false;
                            StoredBrain.idleTimer = 0;
                            StoredBrain.idleEndTimer = 30;
                        }
                    }  else {
                        expressions.thinking = false;
                        anim.SetBool("think", false);
                        StoredBrain.idleTimer = 0;
                        StoredBrain.idleEndTimer = 30;
                    }
                }
                // anim.SetBool("think", false);
            }
        }
        if(StoredBrain.idleEndTimer >= 30) {
            randomnumonce = 0;
            StoredBrain.wanderEndTimer = 0;
            //this doesn't seem to be firing as wanderEndTimer stays at 30 for some reason. Will need to look into this.
            StoredBrain.idleWait = 0;
            StoredBrain.idleEndTimer = 0;
            StoredBrain.isActive = false;
        }
    }
    void Wander()
    {
		followtheTarget();
        // randomnum = 8;
        //Delete this when done testing swimming
        //To test Swim(), uncomment randomnum set to 8, then comment out Random.Range(1,8)
		StoredBrain.wanderTimer += Time.deltaTime;
		StoredBrain.wanderEndTimer += Time.deltaTime;
		if(StoredBrain.wanderTimer >= 10){
			randomnum = Random.Range(1,8);
			switch(randomnum){
				case 1:
					target = waypoint1;
					StoredBrain.wanderTimer = 0;
					break;
				case 2:
					target = waypoint2;
					StoredBrain.wanderTimer = 0;
					break;
				case 3:
					target = waypoint3;
					StoredBrain.wanderTimer = 0;
					break;
				case 4:
					target = waypoint4;
					StoredBrain.wanderTimer = 0;
					break;
				case 5:
					target = waypoint5;
					StoredBrain.wanderTimer = 0;
					break;
				case 6:
					target = waypoint6;
					StoredBrain.wanderTimer = 0;
					break;
				case 7:
					target = waypoint7;
					StoredBrain.wanderTimer = 0;
					break;
				case 8:
					target = waypoint8;
					StoredBrain.wanderTimer = 0;
					break;
			}
		}
		if(StoredBrain.wanderEndTimer >= 30){
			// Debug.Log("Return to idle");
			StoredBrain.wanderTimer = 0;
			StoredBrain.isActive = false;
			anim.SetBool("crawl", false);
		}
	}
    void JumpIntoWater(){
        //Want to move code that makes Chao go into the water here and call it at the start of Swim(), then stop calling it after a timer has reached a certain point.
    }
    void Swim(){
        StopAnimBools();
        anim.SetBool("drown", true);
        //Should be changed to an if statement to check the Chao's swim stat to determine animation, once stats have been added
        StoredBrain.globalTimer += Time.deltaTime;
        Vector3 direction = target.position - this.transform.position;
        float angle = Vector3.Angle(direction,this.transform.forward);
        // this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
        ChaoBody.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
        // var eulerAngles = this.transform.eulerAngles;
        // eulerAngles.y = 0;
        // this.transform.eulerAngles = eulerAngles;
        //Above three lines were a failed attempt to lock the y rotation. I think the line directly under float angle overrides the eulerAngles.y = 0 and prevents it from locking. Commenting
        //out for now as it's not that important atm.
        if(direction.magnitude < 5)
		{
			// anim.SetBool("idle", true);
		}
		if(direction.magnitude > 5)
		{
			// this.transform.Translate(0,0,0.15f);
            ChaoBody.MovePosition(transform.position + (direction.normalized * MoveSpeed * Time.deltaTime));
		}
        if(StoredBrain.globalTimer >= 0.5 && StoredBrain.InWater == false){
            target = jumpWaterPoint1;
        }
        if(StoredBrain.globalTimer >= 1 && StoredBrain.InWater == false){
            target = jumpWaterPoint2;
        }
        if(StoredBrain.globalTimer >= 1.5 && StoredBrain.InWater == false){
            target = swimpoint1;
            // Debug.Log("Chao is jumping into the water");
            //I think this overrides the waypoint change below, swimpoint1 stays the swim waypoint even though the number does randomize.
        }
        if(StoredBrain.globalTimer >= 2){
            StoredBrain.InWater = true;
            StoredBrain.swimTimer += Time.deltaTime;
            StoredBrain.swimEndTimer += Time.deltaTime;
            if(StoredBrain.swimTimer >= 2 && StoredBrain.ExitWater == false){
                // Debug.Log("Swim switch statement running");
                randomnum = Random.Range(1,5);
                switch(randomnum){
                    case 1:
                        target = swimpoint1;
                        StoredBrain.swimTimer = 0;
                        break;
                    case 2:
                        target = swimpoint2;
                        StoredBrain.swimTimer = 0;
                        break;
                    case 3:
                        target = swimpoint3;
                        StoredBrain.swimTimer = 0;
                        break;
                    case 4:
                        target = swimpoint4;
                        StoredBrain.swimTimer = 0;
                        break;
                } //Worried this will keep running even if the swim timer is more than 15, if so it will change the target to something else and the Chao won't leave the water.
            }
            if(StoredBrain.swimEndTimer >= 15 && StoredBrain.exitWaterTimer <= 2){
                StayOnGround = false;
                ChaoBody.useGravity = false;
                StoredBrain.exitWaterTimer += Time.deltaTime;
                // StoredBrain.globalTimer = 0;
                target = jumpWaterExitPoint;
            }
            if(StoredBrain.swimEndTimer >= 15 && StoredBrain.exitWaterTimer >= 2){
                // StoredBrain.globalTimer = 0;
                target = jumpWaterExitPoint2;
            }
        }
        //Holy crap this one is gonna take some time. Might do it gradually. I'm probably gonna have to settle for a stopgap measure. So far the Chao can go in the water but can't get out.
        //That should be an easy fix but I may have to reset the Chao's Y position after they exit the pool.
        //If all else fails just teleport the Chao into the water for 30(ish) seconds then back out, or something simple.
    }
    void followtheTarget (){
		// Vector3 direction = target.position - this.transform.position;
		// float angle = Vector3.Angle(direction,this.transform.forward);
		// direction.y = 0;//this stops the Chao from floating a few cm into the air
        // //Problem with this: locking the y rotation will no doubt cause issues when the Chao tries to swim/climb/fly.
        // //It's going to have to stay, just attempted what fixes I could think of (adding rigidbody and other colliders to Chao) and they didn't work unfortunately. I think as long as I don't
        // //lock the y direction if Chao jumps or climbs it should be fine though. Just need to position the waypoints so that Chao doesn't need to go through floor or float to follow them.
		// this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
		// if(direction.magnitude < 5)
		// {
		// 	anim.SetBool("crawl",false);
		// 	// anim.SetBool("idle", true);
		// }
		// if(direction.magnitude > 5)
		// {
        //     Debug.Log("Chao is following a target");
		// 	this.transform.Translate(0,0,0.15f);
		// 	anim.SetBool("crawl", true);
		// 	anim.SetBool("idle", false);
		// }
        // TESTING MOVING CHAO THROUGH IT'S RIGIDBODY
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
            // Debug.Log(direction);
            // Debug.Log("Chao is following a target");
            ChaoBody.WakeUp();
			ChaoBody.MovePosition(transform.position + (direction.normalized * MoveSpeed * Time.deltaTime));
			anim.SetBool("crawl", true);
			anim.SetBool("idle", false);
		}
	}
    void TurnToTarget(){
        Vector3 direction = target.position - this.transform.position;
		float angle = Vector3.Angle(direction,this.transform.forward);
		direction.y = 0;
		// this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
		ChaoBody.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
    }
    void LookForFood()
    {
        //Works great except Chao is going to waypoint1 instead of food
                if(GetObject.foodInArea.CompareTag("noInteract"))
                {
                    target = waypoint1;
                    //waypoint must be reset in this if statement or else the Chao tries to follow the placeholder, this is stopgap measure. Maybe take the switch statement from Wander() and
                    //make it it's own function? Could call it from here and Wander.
                    Debug.Log("No food found!");
                    StoredBrain.Hunger = 40;
                    StoredBrain.isActive = false;
                    //Something weird going on, isActive and LookForFood not set to false if Chao cannot find food. The Debug.Log is firing so the if statement is running. Need to figure out
                    //what the problem is here.
                    //As a temporary solution, going to set Hunger to 40. I think the Brain script's condition to trigger LookForFood is the problem.
                    //Confirmed the if condition to trigger LookForFood in Brain is causing the issue. Setting Hunger to 40 does solve the problem, at least for now. SOLVED
                }
                else {
                    target = GetObject.foodTransform;
                    Vector3 direction = target.position - this.transform.position;
                    float angle = Vector3.Angle(direction,this.transform.forward);
                    direction.y = 0;//this stops the Chao from floating a few cm into the air
                    // this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
                    ChaoBody.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
                    if(direction.magnitude < 5)//Should fire when Chao is within range of food
                    {
                        StoredBrain.Hunger = StoredBrain.maxHunger;
                        StoredBrain.isActive = false;
                        // GetObject.foodInArea = GetObject.placeholder;
                        // GetObject.foodTransform = GetObject.placeholderTransform;
                        //Need a way to destroy the food after Chao eats it. Destroy target doesn't work.
                        target = waypoint1;
                        //Don't like using this as a stopgap, see comments on FindFood and Start sections.
                        //Destroy(GetObject.foodInArea);//Forced to comment this out for now because it is causing too many errors.
                        anim.SetBool("crawl",false);
                        // anim.SetBool("idle", true);

                    }
                    if(direction.magnitude > 5)
                    {
                        Debug.Log("Chao is going to food");
                        // this.transform.Translate(0,0,0.15f);
                        ChaoBody.MovePosition(transform.position + (direction.normalized * MoveSpeed * Time.deltaTime));
                        anim.SetBool("crawl", true);
                        anim.SetBool("idle", false);
                    }
            }
    }
    void Asleep()
    {
        // StoredBrain.Sleep = 100;
        // StoredBrain.isActive = false;
        StoredBrain.sleepfallRate = 0;
		StoredBrain.sleepTimer += Time.deltaTime;
		if(StoredBrain.sleepTimer >= 0){
            anim.SetBool("idle", false);
            anim.SetBool("Sleep1", true);
            expressions.asleep = true;
            expressions.exActive = true;
        }
        if(StoredBrain.sleepTimer >= 10){
			anim.SetBool("Sleep1", true);
			anim.SetBool("Sleep2", false);
		}
        if(StoredBrain.sleepTimer >= 20){
			anim.SetBool("Sleep1", false);
			anim.SetBool("Sleep2", true);
		}
        if(StoredBrain.sleepTimer >= 30){
			anim.SetBool("Sleep2", false);
		}
        if(StoredBrain.sleepTimer >= 32.5){
			StoredBrain.Sleep = 100;
            StoredBrain.isActive = false;
            StoredBrain.sleepTimer = 0;
            StoredBrain.sleepfallRate = StoredBrain.storedSleepfallRate;
            expressions.asleep = false;
            expressions.exActive = false;
            //Need to change this once I add an expression for waking up.
		}
    }
    void Evolve(){
        //  anim.SetBool("sit", true);
        //  Cocoon.SetActive = true;
        //  CocoonAnim.SetBool("Appear", true);
        //  Cocoon.renderer.material.color.a = 0.5; // 50 % transparent
        //  Cocoon.renderer.material.color.a = 1.0; // fully opaque
        //  evolveTimer += Time.deltaTime;
        //  if(evolveTimer >= 10){
        //      Cocoon.SetActive = false;
        //      //Something to blendshape the Chao into it's evolution and replace it's emote ball accordingly.
        //}
    }
    void StopAnimBools(){
        foreach(AnimatorControllerParameter parameter in anim.parameters) {            
        anim.SetBool(parameter.name, false);            
        }
    }
    void RandomNumOnce(){
        if(randomnumonce == 0){
            randomnumonce = Random.Range(1, 6);
        }
    }
}