using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

namespace RoleGame{
	public class PlayerScript : MonoBehaviour {

		public float maxSpeed = 0.1f; 
		private static bool isFacingRight = true;
		public static bool _isFacingRight{
			get{
				return isFacingRight;
			}
		}
		private Animator anim;
		private Animator conditionAnimator;
		private bool isGrounded = false;
		public Transform groundCheck;
		private float groundRadius = 0.2f;
		public LayerMask whatIsGround;
		public static bool isProtected=false;
		//public int HP;
		//public int Mana;
		//public string health;
		public static float poisDeltaTime = 2.0f;
		public static float sickDeltaTime = 5.0f;
		public static float poisLastTime = 0.0f;
		public static float sickLastTime=0.0f;
		//public int lastpois;
		private void Start()
		{
			anim = GetComponent<Animator>();
			conditionAnimator = GameObject.FindWithTag ("CanvasCondition").GetComponent<Animator> ();
			poisLastTime = 0.0f;
			sickLastTime=0.0f;
			isFacingRight = true;
			anim.SetFloat ("Type", Settings.AnimationID);
			if(Settings.lastSavedPlayer == null) Settings.lastSavedPlayer = new Wizard ("Персонаж", Race.HUMAN, Gender.MALE);
			Settings.StartLevel ();
			FillMagicBook ();
		}
	
		private void FixedUpdate()
		{
			isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround); 
			anim.SetBool ("Grounded", isGrounded);
			/*if (!isGrounded)
				return;*/
			if (Settings.currentPlayer.ableToMove) {
				float move = Input.GetAxis ("Horizontal");
				anim.SetFloat ("Speed", Mathf.Abs (move));
				GetComponent<Rigidbody2D> ().velocity = new Vector2 ((float)(move * maxSpeed), (float)(GetComponent<Rigidbody2D> ().velocity.y));
				if (move > 0 && !isFacingRight)
					Flip ();
				else if (move < 0 && isFacingRight)
					Flip ();
			}
			else
				anim.SetFloat ("Speed", 0);
			CheckPoisoned ();
			CheckSick ();
			if (Settings.currentPlayer.currentHP == 0)
				Settings.LevelFailed ();
		}
		private void Update()
		{
			EventSystem.current.SetSelectedGameObject (gameObject, null);
			if (Settings.currentPlayer.ableToMove && isGrounded && (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))) 
			{
				anim.SetBool("Grounded", false);
				GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 600));				
			}
			if (Input.GetKey(KeyCode.Escape))
			{
				Application.Quit();
			}
			
			if (Input.GetKey(KeyCode.R))
			{
				Settings.LevelFailed();
			}
			if (isProtected && (ArmourScript.time >= 0.0f)) {
				TextExceptionScript.TextWrite(String.Format("Время действия брони "+((int)(ArmourScript.time)).ToString()));
				ArmourScript.MakeProtection ();
				ArmourScript.time -= Time.deltaTime;
			}
			else
			{
				if(ArmourScript.time<=0.0f)
					ArmourScript.StopProtection();
				ArmourScript.time=1f;
			}
			if(Settings.currentPlayer.health==Health.NONE)
				conditionAnimator.SetFloat("Condition Number",0);
			if(Settings.currentPlayer.health==Health.PARALYSED)
				conditionAnimator.SetFloat("Condition Number",3);
			PlayerInfoScript.TextWrite ();
			//HP = Settings.currentPlayer.currentHP;
			//Mana = Settings.currentPlayer.currentMana;
			//health = Settings.currentPlayer.health.ToString();
			//lastpois = poisLastTime;
		}
		private void Flip()
		{
			isFacingRight = !isFacingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
		/*void OnTriggerEnter2D(Collider2D col){
			if (col.gameObject.name == "dieCollider")
				LevelFailed ();
			if (col.gameObject.name == "endCollider")
				LevelFinished ();
			if (col.gameObject.name == "Helpbox") {
				Settings.currentPlayer.currentHP -= 30;
				Destroy(col.gameObject);
			}
		}*/
		/*void OnGUI(){
			GUI.Label (new Rect (0f, 0f, 100f, 20f), "HP: " + Settings.currentPlayer.currentHP);
			GUI.Label (new Rect (0f, 20f, 100f, 20f), "Mana: " + Settings.currentPlayer.currentMana);
			GUI.Label (new Rect (100f, 0f, 150f, 20f), "Condition: " + Settings.currentPlayer.condition);
			GUI.Label (new Rect (100f, 20f, 150f, 20f), "Health: " + Settings.currentPlayer.health);
		}*/
		void CheckPoisoned(){
			if (Settings.currentPlayer.health == Health.POISONED) {
				conditionAnimator.SetFloat("Condition Number",1);
				poisLastTime-=Time.deltaTime;
				if(poisLastTime<=0.0f)
				{
					poisLastTime=poisDeltaTime;
					Settings.currentPlayer.currentHP -= 1;
				}
			}
		}
		void CheckSick(){
			if (Settings.currentPlayer.health == Health.SICK) {
				conditionAnimator.SetFloat("Condition Number",2);
				sickLastTime-=Time.deltaTime;
				if(sickLastTime <= 0.0f)
				{
					sickLastTime = sickDeltaTime;
					Settings.currentPlayer.currentHP -= 1;
				}
			}
		}
		public void SayIncantation(string Incantation){
			Slider slide=(GameObject.FindWithTag("PowerChoose")).GetComponent<Slider>();
			TextExceptionScript.TextWrite ("");
			float Power=slide.value*100;
			if (Power==0)
				Power=1;
			try
			{
				Toggle tog=(GameObject.FindWithTag("CheckInc")).GetComponent<Toggle>();
				if(!tog.isOn)
				{
				if(Incantation=="AddHealth")
					Settings.currentPlayer.SayIncantation (new AddHealth (), Power);
				if(Incantation=="Cure")
					Settings.currentPlayer.SayIncantation (new Cure (),Power);
				if(Incantation=="Antidote")
					Settings.currentPlayer.SayIncantation (new Antidote(), Power);
				if(Incantation=="Revive")
					Settings.currentPlayer.SayIncantation (new Revive (), Power);
				if(Incantation=="Armour")
					Settings.currentPlayer.SayIncantation (new Armour (ArmourScript.StartProtection), Power);
				if(Incantation=="StartMoving")
					Settings.currentPlayer.SayIncantation (new StartMoving (),Power);
				}
				else
				{
					if(Incantation=="AddHealth")
						Settings.currentPlayer.SayIncantation (new AddHealth (),TargetScript.Target,Power);
					if(Incantation=="Cure")
						Settings.currentPlayer.SayIncantation (new Cure (), TargetScript.Target,Power);
					if(Incantation=="Antidote")
						Settings.currentPlayer.SayIncantation (new Antidote(), TargetScript.Target,Power);
					if(Incantation=="Revive")
						Settings.currentPlayer.SayIncantation (new Revive (), TargetScript.Target,Power);
					if(Incantation=="Armour")
						Settings.currentPlayer.SayIncantation (new Armour (ArmourScript.StartProtection), TargetScript.Target,Power);
					if(Incantation=="StartMoving")
						Settings.currentPlayer.SayIncantation (new StartMoving (),TargetScript.Target,Power);
				}
			}
			catch(Exception e)
			{
				//textException=GameObject.FindWithTag("Exception");
		      TextExceptionScript.TextWrite(e.Message);
			}
		}
		public void UseArtifact(int butNumber){
			Slider slide=(GameObject.FindWithTag("PowerChoose")).GetComponent<Slider>();
			float Power=slide.value*100;
			int[] arr = ButtonArtifactScript.TypeArray;
			if (Power==0)
				Power=1;
			try
			{
				if(arr[butNumber] == 1)
					Settings.currentPlayer.UseArtifact (new LittleLiveBottle ());
				if(arr[butNumber] == 2)
					Settings.currentPlayer.UseArtifact (new MiddleLiveBottle ());
				if(arr[butNumber] == 3)
					Settings.currentPlayer.UseArtifact (new BigLiveBottle ());
				if(arr[butNumber] == 4)
					Settings.currentPlayer.UseArtifact (new LittleDeadBottle ());
				if(arr[butNumber] == 5)
					Settings.currentPlayer.UseArtifact (new MiddleDeadBottle ());
				if(arr[butNumber] == 6)
					Settings.currentPlayer.UseArtifact (new BigDeadBottle ());
				if(arr[butNumber] == 7)
					GameObject.FindWithTag("Eye").GetComponent<SpriteRenderer>().enabled = true;
				if(arr[butNumber] == 9)
				{
					foreach(Artifact art in Settings.currentPlayer.bag)
						if(art is LightningStick && art.capacity==0)
							throw new Exception("Артефакт уже истратил свою силу!");
					GameObject.FindWithTag("Lightning").GetComponent<SpriteRenderer>().enabled = true;
				}
				if(arr[butNumber] == 10)
					GameObject.FindWithTag("Spittle").GetComponent<SpriteRenderer>().enabled = true;
				Toggle tog=(GameObject.FindWithTag("CheckInc")).GetComponent<Toggle>();
				if(!tog.isOn)
				{
					if(arr[butNumber] == 8)
						Settings.currentPlayer.UseArtifact (new FrogLegsDecoction ());
				}
				else
				{
					if(arr[butNumber] == 8)
						Settings.currentPlayer.UseArtifact (new FrogLegsDecoction (), TargetScript.Target);
				}
				ButtonArtifactScript.UpdateTypeArray();
			}
			catch(Exception e)
			{
				//textException=GameObject.FindWithTag("Exception");
				TextExceptionScript.TextWrite(e.Message);
			}
		}
		public void ThrowArtifact(int butNumber){
			int[] arr = ButtonArtifactScript.TypeArray;
			try
			{
				if(arr[butNumber] == 1)
					Settings.currentPlayer.ThrowArtifact (new LittleLiveBottle ());
				if(arr[butNumber] == 2)
					Settings.currentPlayer.ThrowArtifact (new MiddleLiveBottle ());
				if(arr[butNumber] == 3)
					Settings.currentPlayer.ThrowArtifact (new BigLiveBottle ());
				if(arr[butNumber] == 4)
					Settings.currentPlayer.ThrowArtifact (new LittleDeadBottle ());
				if(arr[butNumber] == 5)
					Settings.currentPlayer.ThrowArtifact (new MiddleDeadBottle ());
				if(arr[butNumber] == 6)
					Settings.currentPlayer.ThrowArtifact (new BigDeadBottle ());
				if(arr[butNumber] == 7)
					Settings.currentPlayer.ThrowArtifact (new BasiliskEye ());
				if(arr[butNumber] == 8)
					Settings.currentPlayer.ThrowArtifact (new FrogLegsDecoction ());
				if(arr[butNumber] == 9)
					Settings.currentPlayer.ThrowArtifact (new LightningStick ());
				if(arr[butNumber] == 10)
					Settings.currentPlayer.ThrowArtifact (new PoisonousSpittle ());
				ButtonArtifactScript.UpdateTypeArray();
			}
			catch(Exception e)
			{
				TextExceptionScript.TextWrite(e.Message);
			}
		}
		public void FillMagicBook()
		{
			foreach(Incantation inc in Settings.currentPlayer.magicBook)
			{
				Animator anim;
				anim = (GameObject.FindWithTag(inc.ToString().Substring(9, inc.ToString().Length-9))).GetComponent<Animator>();
				anim.SetBool("Known",true);
			}
		}
		public void Back()
		{
			Application.LoadLevel ("ChooseLevelScene");
		}
	}
}
