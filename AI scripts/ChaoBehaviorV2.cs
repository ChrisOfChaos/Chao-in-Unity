using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoBehaviorV2 : MonoBehaviour
{
    // /*This script will be for storing Chao behavior. Essentially a combination of the current brain and behavior scripts*/
    // /*Going to start under the presumption that there will be a behavior script, Chao Data script, and appearance script. I can get the data directly from scripts using getcomponent, so copying the values should not be necessarcy
    // I should need Needs, Emotions, and Actions*/
    // /*NEEDS*/
    // [Header("ChaoNeeds")]
    // public float Hunger;
    // public float maxHunger;
    // public float Sleep;
    // public float maxSleep;
    // /*EMOTIONS*/
    // [Header("ChaoEmotions")]
    public float Anger;
    public float maxAnger;
    public float Boredom;
    public float maxBoredom;
    public float Energy;
    public float maxEnergy;
    // public float unhappy;//Using this to determine when a Chao throws a tantrum, not the same as Sad. Wiil be set to low value if Chao's hunger is at 25% or less.
    // public float maxUnhappy;
    // public float Ego;
    // public float maxEgo;
    // public float Energy;
    // public float maxEnergy;
    // public float Fear;
    // public float maxFear;
    // public float Joy;
    // public float maxJoy;
    // public float Lonely;
    // public float maxLonely;
    // public float Mate;
    // public float maxMate;
    public float Relax;
    public float maxRelax;
    // public float Stress;
    // public float maxStress;
    public float UrgeToTantrum;
    public float maxUrgeToTantrum;
    // public float Surprise;
    // public float maxSurprise;
    // public float UrgeToCry;
    // public float maxUrgeToCry;
    // [Tooltip("Checking to see what happens if a long message is used as a header, if line breaks happen in it, if so will most likely use header to leave notes for self if needed")]
    // /*ACTIONS*/
    // public bool Wander;
    // public bool Idle;

    // public bool Cry;
    // public bool Sleeping;
    // public bool Tantrum;
    // public bool Wave;
    // public bool FindFood;
    // public bool GoToSleep;

    // public bool isActive;//Checks if Chao is performing an action.
    // public bool isSleeping;
    public Queue<string> needs = new Queue<string>();
    public bool HungerQueued;
    public bool SleepQueued;
    public bool RelaxQueued;
    public bool ThinkQueued;
    public bool BullyQueued;
    public bool TantrumQueued;
    public bool CryQueued;
    public bool FlyQueued;
    public bool WaveQueued;
    public bool AcceptfoodQueued;
    public string currentAction;
    public float Hunger;
    public float maxHunger;
    public float Sleep;
    public float maxSleep;
    public float riseRate1;
    public float riseRate2;
    public float riseRate3;
    public float riseRate4;
    public float riseRate5;
    public float hungerChangeRate;
    public float sleepChangeRate;

    //CHAO DATA
    public ChaoDataProfile ChaoData;
    public DetectObjects1 detect;
    //MOVEMENT & UTILITY RELATED
    // public Transform foodInArea;
    public Transform target;
    public Transform nearbyChaostored;
    public GameObject nearbyChaoObj;
    // public ChaoBehaviorV2 nearbyChaoBehavior;
	public Transform waypoint1;
	public Transform waypoint2;
	public Transform waypoint3;
	public Transform waypoint4;
	public Transform waypoint5;
	public Transform waypoint6;
	public Transform waypoint7;
	public Transform waypoint8;
    public Transform flypoint1;
	public Transform flypoint2;
	public Transform flypoint3;
	public Transform flypoint4;
	public Transform flypoint5;
	public Transform landpoint;
    public Transform swimpoint1;
    public Transform swimpoint2;
    public Transform swimpoint3;
    public Transform swimpoint4;
    public Transform swimpoint5;
    public Transform swimpoint6;
    public Transform swimpoint7;
    public Transform swimpoint8;
    public Transform swimpoint9;
    public Transform swimpoint10;
    public Transform divepoint1;
    public Transform divepoint2;
    public Transform divepoint3;
    public Transform divepoint4;
    public Transform divepoint5;
    public Transform divepoint6;
    public Transform divepoint7;
    public Transform divepoint8;
    public Transform divepoint9;
    public Transform divepoint10;
    public Transform swimexitpoint;
    public Transform shorepoint;
    public Rigidbody ChaoBody;
    public bool swimStart;
    public bool exitWater;
    public bool EndSwimming;
    public bool flyStart;
    public bool ChaoInWater;
    public bool ChaoMoving;
    public bool playerholdingfood;
    public float MoveSpeed;
    public float SwimSpeed;
    public float fallSpeed;
    public int randomnum;
    public int randomnumonce;
    public int randomchancethink;
    public bool resetTimers;
    public float timer1;
    public float timer2;
    public float thinkTimer;
    public float sleepTimer;
    public float bullyTimer;
    public float flyTimer;
    public float flyEndTimer;
    public float landTimer;
    public float landEndTimer;
    public float swimTimer;
    public float swimEndTimer;
    public float leavewaterTimer;
    public float leavewaterEndTimer;
    public float cryTimer;
    public float crysoundTimer;
    public float tantrumTimer;
    public float waveTimer;
    public float globalTimer;
    //ANIMATION RELATED
    public Animator anim;
    public Voices ChaoVoices;
    public bool animToggle;
    public Expressions Express;
    public bool ChaoInteract;
    public bool pet;
    public bool abuse;

    void Awake () {//Bawake
         // Make the game run as fast as possible in Windows
         Application.targetFrameRate = 300;
     }
    void Start(){//Bstart
        Debug.Log("Game started");
        ChaoVoices = GetComponent<Voices>();
        detect = GetComponent<DetectObjects1>();
        anim = GetComponent<Animator>();
        Express = GetComponent<Expressions>();
        ChaoBody = GetComponent<Rigidbody>();
        ChaoData = GetComponent<ChaoDataProfile>();
        SetRandomWaypoint();
        nearbyChaoObj = detect.nearbyChao;
        MoveSpeed = 50;
        fallSpeed = 20;
    }
    void Update(){//Bupdate

        if(Input.GetKeyDown(KeyCode.E) && detect.playerNearby == true){
            pet = true;
            // Debug.Log("Chao is being pet");
        } else if(Input.GetKeyDown(KeyCode.R) && detect.playerNearby == true){
            abuse = true;
            // Debug.Log("Chao is being pet");
        } else if(Input.GetKeyDown(KeyCode.X) && detect.playerNearby == true){
            if(detect.player.GetComponent<PlayerInventory1>().holdingItem == true){
                pet = true;//Placeholder
                GiveItem();
                Debug.LogWarning("Chao was given an item");
                /*Function to check the item and modify Chao's stats accordingly*/
            }
        }
        /* else if(Input.GetKeyDown(KeyCode.T) && detect.playerNearby == true){
            if(playerholdingfood == true && AcceptfoodQueued == false){
                ClearQueue();
                needs.Enqueue("acceptfood");
                AcceptfoodQueued = true;
            }
        }*/
        if(ChaoInWater == true && EndSwimming == false){
            Swimming();
        } else if(EndSwimming == true){
            EndSwim();
        }
        else if(pet == true){
            ClearQueue();
            globalTimer += Time.deltaTime;
            StopAnimBools();
            anim.SetBool("idle", true);
            Express.thinking = false;
            Express.tired = false;
            Express.love = true;
            Express.exActive = true;
            if(globalTimer >= 3){
                ChaoData.happiness+= 5;
                ChaoData.Attention+= 10;
                pet = false;
                Express.love = false;
                Express.exActive = false;
                anim.SetBool("idle", false);
                globalTimer = 0;
            }
        }else if(abuse == true){
            ClearQueue();
            globalTimer += Time.deltaTime;
            StopAnimBools();
            anim.SetBool("hit", true);//Will change this to trip at some point
            Express.thinking = false;
            Express.hit = true;
            Express.exActive = true;
            if(globalTimer >= 0.5){
                ChaoData.happiness-= 20;
                // ChaoData.Attention-= 10;
                abuse = false;
                Express.hit = false;
                Express.exActive = false;
                anim.SetBool("hit", false);
                ClearQueue();
                needs.Enqueue("cry");
                CryQueued = true;
                globalTimer = 0;
            }
        }else{
            if(ChaoInteract == false){
                MaintainValues();
                NeedsDecay();
                EmotionsDecay();
                CheckQueue();
                ActionCheck();
                AddActionToQueue();
            }
            if(ChaoInteract == true){
                StopAnimBools();
                ClearQueue();
            }
        }

        // anim.SetBool("crawl", false);//This is the only way I have found that prevents Crawl from being true after Wander finishes.

        //*Commented this out to test petting. I want to try a few different iterations of the pet function, so I'm leaving this in case I want to restore it.*/
        // if(ChaoInteract == false){
        //     MaintainValues();
        //     NeedsDecay();
        //     EmotionsDecay();
        //     CheckQueue();
        //     ActionCheck();
        //     AddActionToQueue();
        // }
        // if(ChaoInteract == true){
        //     StopAnimBools();
        //     ClearQueue();
        // }
    }
    void CheckQueue(){//BCheckQueue
        foreach(var queueitem in needs){
            currentAction = needs.Peek();
        }
        if(needs.Count == 0){
            currentAction = "wander";
        }
    }
    void ActionCheck(){//Bactioncheck
        /*checks the queue to see what the current top action is, then triggers it*/
        if(currentAction == "lookforfood"){
            // LookForFood();
            GoToFood();
        }
        else if(currentAction == "gotosleep"){
            GoToSleep();
        }
        else if(currentAction == "wander"){
            Wander();
        }
        else if(currentAction == "actrelaxed"){
            ActRelaxed();
        }
        else if(currentAction == "think"){
            Thinking();
        }
        else if(currentAction == "bullyingachao"){
            Bully();
        }
        else if(currentAction == "cry"){
            Cry();
        }
        else if(currentAction == "fly"){
            Fly();
        }
        else if(currentAction == "tantrum"){
            Tantrum();
        }
        else if(currentAction == "wave"){
            WaveToPlayer();
        }
        // else if(currentAction == "acceptfood"){
        //     EatFood();
        // }
    }
    void AddActionToQueue(){//baddaction
        /*This checks the Needs and Emotion values and adds them to the queue accordingly*/
        /*NEEDS CHECKS*/
        if(Hunger >= maxHunger*0.9 && HungerQueued == false && detect.foodInArea != null){//should be triggered at 15
        //This is overriding the sleep bool for some reason.(SOLVED: Dequeued )
            needs.Enqueue("lookforfood");
            HungerQueued = true;
        }
        if(Sleep >= maxSleep*0.5 && SleepQueued == false){//should be triggerered at 10
            needs.Enqueue("gotosleep");
            SleepQueued = true;
        }
        if(Relax >= maxRelax*0.85 && RelaxQueued == false){
            needs.Enqueue("actrelaxed");
            RelaxQueued = true;
            /*This is a placeholder. I would like to make emotion-related behavior more complex(compare to other emotions, randomly select a relax-related action)*/
        }
        if(UrgeToTantrum >= maxUrgeToTantrum*0.9 && TantrumQueued == false){
            needs.Enqueue("tantrum");
            TantrumQueued = true;
        }
        /*Checks a think random roll that happens after each action. If the roll is greater than 6, think is added to the queue*/
        if(randomchancethink >= 4 && ThinkQueued == false){
            needs.Enqueue("think");
            ThinkQueued = true;
        }
        if(Boredom >= maxBoredom *0.6 && BullyQueued == false && ChaoData.Personality == "Bully"){
            needs.Enqueue("bullyingachao");
            BullyQueued = true;
        }
        if(Energy >= maxEnergy*0.5 && ChaoData.FlyStat >= 1 && FlyQueued == false){
            needs.Enqueue("fly");
            FlyQueued = true;
        }

        //ACTIONS RELATED TO PLAYER DISTANCE
        /*Chao waves to player if it has a positive relationship with them and they are nearby*/
        if(detect.playerNearby == true && WaveQueued == false && ChaoData.Attention >= 20){
            needs.Enqueue("wave");
            WaveQueued = true;
        }
    }
    void NeedsDecay(){//Bneedsdecay
    /*Needs decay at rates based on the Chao's stored personality. A similar method will be applied to emotions*/
        if(ChaoData.Personality == "Big Eater"){
            Hunger+=Time.deltaTime * riseRate2;
            Sleep+=Time.deltaTime * riseRate1;
        } else if(ChaoData.Personality == "Lazy"){
            Hunger+=Time.deltaTime * riseRate1;
            Sleep+=Time.deltaTime * riseRate2;
        } else{
            Hunger+=Time.deltaTime * riseRate1;
            Sleep+=Time.deltaTime * riseRate1;
        }
    }
    void EmotionsDecay(){//Bemotionsdecay
        if(ChaoData.Personality == "Carefree"){
            Relax+=Time.deltaTime * riseRate2;
        } else{
            Relax+=Time.deltaTime * riseRate1;
        }
        if(ChaoData.Personality == "Energetic"){
            Energy+=Time.deltaTime * riseRate2;
        } else{
            Energy+=Time.deltaTime * riseRate1;
        }
        if(Hunger>=maxHunger*0.5){
            if(ChaoData.Personality == "Crybaby"){
                UrgeToTantrum+=Time.deltaTime * riseRate2;
            } else{
                UrgeToTantrum+=Time.deltaTime * riseRate1;
            }
        }
        Boredom+=Time.deltaTime * riseRate1;
    }
    /*CHAO ACTIONS*/
    /*These are the actions that the Chao is capable of.*/
    void Thinking(){//Bthinking
        StopAnimBools();
        /*This action is triggered at the beginning of other actions, it isn't really it's own action*/
        thinkTimer+=Time.deltaTime;
        if(thinkTimer <= 2.4){
            anim.SetBool("think", true);
            Express.thinking = true;
            Express.exActive = true;
            //addvoicehere
        } else{
            thinkTimer = 0;
            randomchancethink = 0;
            anim.SetBool("think", false);
            Express.thinking = false;
            Express.exActive = false;
            ThinkQueued = false;
            needs.Dequeue();
        }
    }
    void rollThink(){
        randomchancethink = Random.Range(1,10);
    }
    void WaveToPlayer(){//BWaveToPlayer
        StopAnimBools();
        waveTimer+=Time.deltaTime;
        if(waveTimer <= 1.66){
            TurnToTarget();
            target = detect.player.GetComponent<Transform>();
            anim.SetBool("wave", true);
            Express.happy = true;
            Express.exActive = true;
            //addvoicehere
        } else{
            SetRandomWaypoint();
            waveTimer = 0;
            anim.SetBool("wave", false);
            Express.happy = false;
            Express.exActive = false;
            WaveQueued = false;
            needs.Dequeue();
        }
        
    }
    void TurnToTarget(){//Bturntotarget
        Vector3 direction = target.position - this.transform.position;
		float angle = Vector3.Angle(direction,this.transform.forward);
		direction.y = 0;
		// this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
		ChaoBody.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
    }
    // void LookForFood(){//Blookforfood
    //     timer1 = 0;
    //     /*This is a placeholder that gradually increases the Hunger value. Will be replacing it with a followthetarget call with the target set to food*/
    //     StopAnimBools();
    //     target = detect.foodInArea.GetComponent<Transform>();
    //     GoToFood();
    // }
    void Bully(){//Bbully
        StopAnimBools();
        nearbyChaoObj.GetComponent<ChaoBehaviorV2>().ChaoInteract = true;//Going to make a variation of this that lets the nearby Chao face the Bully Chao.
        /*Currently works but for some reason, when the Chao gets ready to punch the other Chao, it goes back to crawling, then punches the Chao.*/
        target = nearbyChaoObj.GetComponent<Transform>();//This is a placeholder, nearby Chao will be added with DetectObjects1
        Vector3 direction = target.position - this.transform.position;
		float angle = Vector3.Angle(direction,this.transform.forward);
		direction.y = 0;
		ChaoBody.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
		if(direction.magnitude < 5)
		{
            bullyTimer+=Time.deltaTime;
            Debug.Log("Chao is attacking another Chao!");
            Express.smug = false;
            Express.exActive = false;
            if(Express.smug == false && Express.exActive == false){
                Express.effort = true;
                Express.exActive = true;
            }
            // Debug.Log("Chao has stopped.");
            anim.SetBool("crawl", false);
            anim.SetBool("punch",true);
            if(bullyTimer >= 1){
                nearbyChaoObj.GetComponent<ChaoBehaviorV2>().ClearQueue();
                nearbyChaoObj.GetComponent<ChaoBehaviorV2>().ChaoInteract = false;
                nearbyChaoObj.GetComponent<ChaoBehaviorV2>().abuse = true;
                // nearbyChaoBehavior.UrgeToCry = nearbyChaoBehavior.maxUrgeToCry;//no need for this atm because abuse triggers the crying animation and loss of happiness. But will replace with maxing out UrgeToCry later.
                Debug.Log("You should only see this once!");
                StopAnimBools();
                needs.Dequeue();
                SetRandomWaypoint();
                bullyTimer = 0;
                Boredom = Boredom - maxBoredom*0.6f;;
                Express.effort = false;
                Express.exActive = false;
                BullyQueued = false;
                //Set nearbyChao's Urge to Cry to max value
            }
		}
		if(direction.magnitude > 5)
		{
            Debug.Log("Oh no! Chao is going to bully another Chao!");
            // Debug.Log(direction);
            // Debug.Log("Chao is following a target");
			ChaoBody.MovePosition(transform.position + (direction.normalized * MoveSpeed * Time.deltaTime));
            // Debug.Log("If Chao has stopped wandering, you shouldn't see this.");
            Express.smug = true;
            Express.exActive = true;
            anim.SetBool("crawl", true);
			anim.SetBool("idle", false);
		}
    }
    void Cry(){
        StopAnimBools();
        /*This action is triggered at the beginning of other actions, it isn't really it's own action*/
        cryTimer+=Time.deltaTime;
        if(cryTimer <= 16){
            anim.SetBool("cry", true);
            ChaoVoices.sadcrying.SetActive(true);//edit crying sound to add spacing, also would be ideal to keep at 15 second range
            Express.tantrum = true;
            Express.exActive = true;
        } else{
            cryTimer = 0;
            randomchancethink = 0;
            anim.SetBool("cry", false);
            ChaoVoices.sadcrying.SetActive(false);
            Express.tantrum = false;
            Express.exActive = false;
            CryQueued = false;
            needs.Dequeue();
        }
    }
    void GoToSleep(){
        StopAnimBools();
        // ResetTimers();//resettimers doesn't currently work.
        sleepTimer+=Time.deltaTime;
        // Sleep-=Time.deltaTime * riseRate1*4;
        if(sleepTimer >= 0){
            Express.asleep = true;
            Express.exActive = true;
            anim.SetBool("Sleep1", true);
        }
        if(sleepTimer >= 5){
            anim.SetBool("Sleep1", false);
            anim.SetBool("Sleep2", true);
        }
        if(sleepTimer >= 10){
            Express.asleep = false;
            Express.wakeup = true;
            anim.SetBool("Sleep2", false);
        }
        if(sleepTimer >= 15){
            Express.wakeup = false;
            Express.exActive = false;
            Sleep = 0;
            sleepTimer = 0;
            SleepQueued = false;
            rollThink();
            needs.Dequeue();
        }
    }
    void ActRelaxed(){//BActRelaxed
        StopAnimBools();
        // ResetTimers();
        timer2+=Time.deltaTime;
        if(timer2 <= 3.5){
            anim.SetBool("yawn", true);
            Express.tired = true;
            Express.exActive = true;
        }
        else{
            timer2 = 0;
            anim.SetBool("yawn", false);
            StopAnimBools();
            Express.tired = false;
            Express.exActive = false;
            Relax = 0;
            RelaxQueued = false;
            rollThink();
            needs.Dequeue();
        }
    }
    /* WANDER IS THE "DEFAULT" ACTION WHEN NONE ARE LEFT IN THE QUEUE */
    void Wander(){//BWander(bookmark)
        StopAnimBools();
        //followtheTarget();
        // ResetTimers();

        /*Pretty sure this is redundant, no if check should be needed because it happens in the action that calls Wander()*/
        if(currentAction == "wander"){
            // Debug.Log("Chao is wandering");
            followtheTarget();
        }

        timer1++;
        if(timer1 >= 2000){
            SetRandomWaypoint();
            timer1 = 0;
        }
        // anim.SetBool("crawl", false);
    }
    //CHAO MOVEMENT
    void followtheTarget (){//BfollowtheTarget
        swimStart = false;//Forced to add this because it doesn't get set to false when Chao leaves water every time! With this, anything that causes the Chao to move sets this to false.
        ChaoBody.useGravity = true;
        ChaoBody.isKinematic = false;
        //Forced to add this due to problems with swimming. This forces the Chao's gravity back on so that it's not possible for it to not be reset if the Chao moves.
		Vector3 direction = target.position - this.transform.position;
		float angle = Vector3.Angle(direction,this.transform.forward);
		direction.y = 0;
		ChaoBody.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
		if(direction.magnitude < 5)
		{
            // Debug.Log("Chao has stopped.");
            // anim.SetBool("crawl", false);
		}
		if(direction.magnitude > 5)
		{
            // Debug.Log(direction);
            // Debug.Log("Chao is following a target");
            ChaoBody.WakeUp();
			ChaoBody.MovePosition(transform.position + (direction.normalized * MoveSpeed * Time.deltaTime));
            // Debug.Log("If Chao has stopped wandering, you shouldn't see this.");
			anim.SetBool("crawl", true);
			anim.SetBool("idle", false);
		}
	}

    void Fly(){//BFly
        /*Chao flies around in the air for a few minutes, similar to Wander*/
        StopAnimBools();
        ChaoInteract = false;
        pet = false;
        flyEndTimer+=Time.deltaTime;
        if(flyStart == false){
            Debug.Log("This was triggered");
            target = flypoint1;
            flyStart = true;
        }
        anim.SetBool("fly", true);
        if(flyEndTimer <= 20){
            isFlying();
            flyTimer++;
            if(flyTimer >= 2000){
                randomnum = Random.Range(1,5);
                flyTimer = 0;
                switch(randomnum){
                    case 1:
                        target = flypoint1;
                        break;
                    case 2:
                        target = flypoint2;
                        break;
                    case 3:
                        target = flypoint3;
                        break;
                    case 4:
                        target = flypoint4;
                        break;
                    case 5:
                        target = flypoint5;
                        break;
                }
            }
        } else {
                isLanding();
            }
    }
    void isFlying (){//BisFlying
        Express.happy = true;
        Express.exActive = true;
        ChaoBody.useGravity = false;
		Vector3 direction = target.position - this.transform.position;
		float angle = Vector3.Angle(direction,this.transform.forward);
		// direction.y = 0;Allows the Chao to fly.
		ChaoBody.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
		if(direction.magnitude < 5)
		{
            // Debug.Log("Chao has stopped.");
            // anim.SetBool("crawl", false);
		}
		if(direction.magnitude > 5)
		{
            // Debug.Log(direction);
            // Debug.Log("Chao is following a target");
            ChaoBody.WakeUp();
			ChaoBody.MovePosition(transform.position + (direction.normalized * MoveSpeed * Time.deltaTime));
            // Debug.Log("If Chao has stopped wandering, you shouldn't see this.");
			// anim.SetBool("crawl", true);//Commented out anim bool setting as that will probably be done in the Fly function.
			// anim.SetBool("idle", false);
		}
	}
    void isLanding(){//BisLanding
        target = waypoint3;//Would like to add more landing points and randomize which one the Chao lands at, but will do later.
        landTimer+=Time.deltaTime;
		Vector3 direction = target.position - this.transform.position;
		float angle = Vector3.Angle(direction,this.transform.forward);
		// direction.y = 0;Allows the Chao to fly.
		ChaoBody.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
		if(direction.magnitude < 3)
		{
            landEndTimer+=Time.deltaTime;
            ChaoBody.useGravity = true;
            followtheTarget();
            StopAnimBools();
            if(landEndTimer >= 3){
                flyStart = false;
                Energy = 0;
                SetRandomWaypoint();
                Express.happy = false;
                Express.exActive = false;
                FlyQueued = false;
                flyEndTimer = 0;
                landTimer = 0;
                landEndTimer = 0;
                ClearQueue();
                // Debug.Log("Chao has stopped.");
                // anim.SetBool("crawl", false);
            }
		}
		if(direction.magnitude > 3)
		{
            // Debug.Log(direction);
            // Debug.Log("Chao is following a target");
            ChaoBody.WakeUp();
			ChaoBody.MovePosition(transform.position + (direction.normalized * MoveSpeed * Time.deltaTime));
            // Debug.Log("If Chao has stopped wandering, you shouldn't see this.");
			// anim.SetBool("crawl", true);//Commented out anim bool setting as that will probably be done in the Fly function.
			// anim.SetBool("idle", false);
		}
    }

    void Swimming(){//BSwimming
        StopAnimBools();
        //Sets the initial swimpoint, a bool is needed to make sure it is only set one time.
        if(swimStart==false){
            if(ChaoData.SwimStat <= 10){
                SetRandomSwimpoint();
            } else{
                Debug.LogWarning("You shouldn't see this when Chao exits water");
                SetRandomDivepoint();
            }
            swimStart=true;
        }
        ChaoBody.useGravity = false;
        ChaoBody.isKinematic = true;
        if(ChaoData.SwimStat >= 5){
            Express.exActive = true;
            Express.happy = true;
            anim.SetBool("swim", true);
        } else{
            Express.exActive = true;
            Express.drowning = true;
            anim.SetBool("drown", true);
        }
        swimEndTimer+=Time.deltaTime;
        if(swimEndTimer <= 20 && EndSwimming == false){
            followtheTargetSwim();
            swimTimer+=Time.deltaTime;
            if(swimTimer >= 3){
                swimTimer = 0;
                if(ChaoData.SwimStat >= 10){
                    SetRandomDivepoint();
                } else{
                    SetRandomSwimpoint();
                }
            }
        } else{
            swimEndTimer = 0;
            EndSwimming = true;
        }
        Debug.LogWarning("Chao is swimming.");
    }
    void followtheTargetSwim(){//BfollowtheTarget
		Vector3 direction = target.position - this.transform.position;
		float angle = Vector3.Angle(direction,this.transform.forward);
		//direction.y = 0;
		ChaoBody.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
		if(direction.magnitude < 5)
		{
            // Debug.Log("Chao has stopped.");
            // anim.SetBool("crawl", false);
		}
		if(direction.magnitude > 5)
		{
            // Debug.Log(direction);
            // Debug.Log("Chao is following a target");
            ChaoBody.WakeUp();
			ChaoBody.MovePosition(transform.position + (direction.normalized * SwimSpeed * Time.deltaTime));
            // Debug.Log("If Chao has stopped wandering, you shouldn't see this.");
		}
	}
    void EndSwim(){
        target = swimexitpoint;//Would like to add more landing points and randomize which one the Chao lands at, but will do later.
        // leavewaterTimer+=Time.deltaTime;
		Vector3 direction = target.position - this.transform.position;
		float angle = Vector3.Angle(direction,this.transform.forward);
		// direction.y = 0;Allows the Chao to fly.
		ChaoBody.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
		if(direction.magnitude < 3 && exitWater == false)
		{
            target = shorepoint;
            exitWater = true;
		} else if(direction.magnitude < 3 && exitWater == true){
            StopAnimBools();
            SetRandomWaypoint();
            ChaoBody.useGravity = true;
            ChaoBody.isKinematic = false;
            Express.drowning = false;//Might change this to an if check since, if the Chao has a high swim stat, they wouldn't have the drowning expression while swimming.
            Express.happy = false;
            Express.exActive = false;
            exitWater = false;
            swimStart = false;
            EndSwimming = false;
            swimTimer = 0;
            swimEndTimer = 0;
        }
		if(direction.magnitude > 3 && exitWater == false)
        {
            // ChaoBody.WakeUp();
			ChaoBody.MovePosition(transform.position + (direction.normalized * MoveSpeed * Time.deltaTime));
		} else if(direction.magnitude > 3 && exitWater == true){
            // ChaoBody.WakeUp();
            /*For some reason, the Chao's gravity and kinematic settings aren't getting reset in the two lines below. Adding a debug log to make sure this section
            of the code is triggered.*/
            Debug.LogWarning("Chao is heading to shore.");
            /*It seems that, for whatever reason, this line of code never becomes true. Added the gravity and kinematic reset to a different part of the function.*/
            ChaoBody.useGravity = true;
            ChaoBody.isKinematic = false;
			ChaoBody.MovePosition(transform.position + (direction.normalized * MoveSpeed * Time.deltaTime));
        }
    }
    // void SwimExitResetBody(){
    //     //resets the Chao's rigidbody settings, can run once the Chao exits the water by being picked up or at the end of it's swim timer.
    //     ChaoBody.useGravity = true;
    //     ChaoBody.isKinematic = false;
    // }
    void SetRandomSwimpoint(){
        randomnum = Random.Range(1,10);
        switch(randomnum){
            case 1:
                target = swimpoint1;
                break;
            case 2:
                target = swimpoint2;
                break;
            case 3:
                target = swimpoint3;
                break;
            case 4:
                target = swimpoint4;
                break;
            case 5:
                target = swimpoint5;
                break;
            case 6:
                target = swimpoint6;
                break;
            case 7:
                target = swimpoint7;
                break;
            case 8:
                target = swimpoint8;
                break;
            case 9:
                target = swimpoint9;
                break;
            case 10:
                target = swimpoint10;
                break;
        }
    }
    void SetRandomDivepoint(){
        randomnum = Random.Range(1,10);
        switch(randomnum){
            case 1:
                target = divepoint1;
                break;
            case 2:
                target = divepoint2;
                break;
            case 3:
                target = divepoint3;
                break;
            case 4:
                target = divepoint4;
                break;
            case 5:
                target = divepoint5;
                break;
            case 6:
                target = divepoint6;
                break;
            case 7:
                target = divepoint7;
                break;
            case 8:
                target = divepoint8;
                break;
            case 9:
                target = divepoint9;
                break;
            case 10:
                target = divepoint10;
                break;
        }
    }
    
    void Tantrum(){//BTantrum
        /*Chao will cry if it's hunger is 10/half of max. In the future, it will be triggered at 3/4 max for normal Chao, not at all for certain personalities, or stay
        at 1/2 marker for Crybaby Chao.*/
        StopAnimBools();
        // ResetTimers();
        tantrumTimer+=Time.deltaTime;
        if(tantrumTimer <= 4){
            anim.SetBool("tantrum", true);
            ChaoVoices.tantrum.SetActive(true);
            Express.tantrum = true;
            Express.exActive = true;
        }
        else{
            tantrumTimer = 0;
            StopAnimBools();
            ChaoVoices.tantrum.SetActive(false);
            Express.tantrum = false;
            Express.exActive = false;
            UrgeToTantrum = 0;
            TantrumQueued = false;
            rollThink();
            needs.Dequeue();
        }
    }
    void GoToFood (){//Bgotofood
        StopAnimBools();
        timer1 = 0;
        target = detect.foodInArea.GetComponent<Transform>();
		Vector3 direction = target.position - this.transform.position;
		float angle = Vector3.Angle(direction,this.transform.forward);
		direction.y = 0;
		ChaoBody.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
		if(direction.magnitude < 7)
		{
            Debug.Log("Chao has stopped.");
            EatFood();
		}
		if(direction.magnitude > 7)
		{
            // Debug.Log(direction);
            Debug.Log("Chao is following a target");
            ChaoBody.WakeUp();
			ChaoBody.MovePosition(transform.position + (direction.normalized * MoveSpeed * Time.deltaTime));
            // Debug.Log("If Chao has stopped wandering, you shouldn't see this.");
			anim.SetBool("crawl", true);
			anim.SetBool("idle", false);
		}
	}
    void EatFood(){//Beatfood
        /*This will be triggered after lookforfood*/
        //Transform position of nearbyFood to Chao holdbox
        //TurnToTarget();//This doesn't seem to make a difference, was an attempt to fix Chao not directly facing the fruit
        Hunger-=Time.deltaTime * riseRate5;
        //StopAnimBools();
        anim.SetBool("sit",true);//replace with eating animation
        detect.foodInArea.GetComponent<Animator>().SetBool("disappear", true);
        detect.foodInArea.GetComponent<Transform>().transform.position = detect.holdbox.GetComponent<Transform>().transform.position;
        if(Hunger <= 0){
            detect.foodInArea.SetActive(false);
            detect.foodInArea = null;
            UrgeToTantrum = 0;
            //AcceptfoodQueued = false;//in case the food was given to Chao by the player
            HungerQueued = false;
            SetRandomWaypoint();
            rollThink();
            needs.Dequeue();
        }
    }
    void MaintainValues(){
        /*Resets all values if they go past their maximum or minimum*/
        if(Hunger >= maxHunger+5){
            Hunger=maxHunger;
        }
        if(Hunger <= -5){
            Hunger=0;
        }
        if(Sleep >= maxSleep+5){
            Sleep=maxSleep;
        }
        if(Sleep <= -5){
            Sleep=0;
        }
        if(Relax >= maxRelax+5){
            Relax=maxRelax;
        }
        if(Relax <= -5){
            Relax=0;
        }
        if(Boredom >= maxBoredom+5){
            Boredom=maxBoredom;
        }
        if(Boredom <= -5){
            Boredom=0;
        }
    }
    void CrawlWalkStart(){
        if(ChaoData.RunStat >= 100){
            anim.SetBool("walk", true);
        } else{
            anim.SetBool("crawl", true);
        }
    }
    void CrawlWalkEnd(){
        if(ChaoData.RunStat >= 100){
            anim.SetBool("walk", false);
        } else{
            anim.SetBool("crawl", false);
        }
    }
    void StopAnimBools(){
        animToggle = true;
        if(animToggle == true){
            foreach(AnimatorControllerParameter parameter in anim.parameters) {            
                anim.SetBool(parameter.name, false);            
            }
            animToggle = false;
        }
    }
    void ResetTimers(){
        resetTimers = true;
        if(resetTimers == true){
            timer1 = 0;
            resetTimers = false;
        }
    }
    public void SetRandomWaypoint(){//Bsetrandomwaypoint
        randomnum = Random.Range(1,8);
        switch(randomnum){
            case 1:
                target = waypoint1;
                break;
            case 2:
                target = waypoint2;
                break;
            case 3:
                target = waypoint3;
                break;
            case 4:
                target = waypoint4;
                break;
            case 5:
                target = waypoint5;
                break;
            case 6:
                target = waypoint6;
                break;
            case 7:
                target = waypoint7;
                break;
            case 8:
                target = waypoint8;
                break;
        }
    }
    void GiveItem(){
        //how do I want to do this?
        if(detect.player.GetComponent<PlayerInventory1>().currentitem.GetComponent<itemstats>().itemtag == "increaseswim"){
            Debug.LogWarning("Chao swim will increase");
            ChaoData.IncreaseSwim();
        } else if(detect.player.GetComponent<PlayerInventory1>().currentitem.GetComponent<itemstats>().itemtag == "increasefly"){
            Debug.LogWarning("Chao fly will increase");
            ChaoData.IncreaseFly();
        } else if(detect.player.GetComponent<PlayerInventory1>().currentitem.GetComponent<itemstats>().itemtag == "increaserun"){
            Debug.LogWarning("Chao run will increase");
            ChaoData.IncreaseRun();
        } else if(detect.player.GetComponent<PlayerInventory1>().currentitem.GetComponent<itemstats>().itemtag == "increasepower"){
            Debug.LogWarning("Chao power will increase");
            ChaoData.IncreasePower();
        } else if(detect.player.GetComponent<PlayerInventory1>().currentitem.GetComponent<itemstats>().itemtag == "fooditem"){
            Hunger = 0;//Placeholder, ideally would like to have Chao eat the fruit instead of just resetting it's hunger.
            Debug.LogWarning("Chao will eat this.");
        } else if(detect.player.GetComponent<PlayerInventory1>().currentitem.GetComponent<itemstats>().itemtag == "wearable"){
            Debug.LogWarning("Chao will wear this item");
        }
    }
    void ClearQueue(){
        /*Clears the action queue completely. Most likely will be used when a Chao's actions need to be interrupted.*/
        Debug.Log("Queue cleared");
        needs.Clear();
        currentAction = "undefined";
        HungerQueued = false;
        SleepQueued = false;
        RelaxQueued = false;
        ThinkQueued = false;
    }
    
}
