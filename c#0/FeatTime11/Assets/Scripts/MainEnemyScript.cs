using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

namespace RoleGame{
	public class MainEnemyScript : MonoBehaviour {
		public float speed=3f;
		private float direction = 1f;
		public int takeHP = 10;
		private Animator anim;
		private float Timer =0.8f;
		private Hero enemy;
		public float poisTimer = 2f;
		public float sickTimer = 5f;
		private float hitTime=0.2f;
		private float attackTime=0.8f;
		private bool isAttacking=false;
		private bool isHited=false;
		private GameObject player;
		private Text DemonInfo;
		void Start () {
			anim = GetComponent<Animator>();
			enemy = new Hero ("Enemy", Race.HUMAN, Gender.MALE);
			player=GameObject.FindWithTag("Player");
			DemonInfo = GameObject.FindWithTag ("DemonInfo").GetComponent<Text> ();
		}
		
		void Update () {
			if (enemy.ableToMove)
			{
				GetComponent<Rigidbody2D> ().velocity = new Vector2 ((float)(direction * speed), (float)(GetComponent<Rigidbody2D> ().velocity.y));
				transform.localScale = new Vector3 (direction * Mathf.Abs (transform.localScale.x), transform.localScale.y, 1);
			}
			if (enemy.condition == Condition.DEAD) {
				Timer-=Time.deltaTime;
				anim.SetBool("IsDying", true);
			}
			if ((Math.Abs (player.transform.position.x - gameObject.transform.position.x) < 5)&&(Math.Abs (player.transform.position.y - gameObject.transform.position.y) < 3))
			{
				DemonInfo.text=String.Format("Здоровье врага: "+enemy.currentHP+"/"+enemy.maxHP);
			}
			else
				DemonInfo.text=String.Format("");
				
			if (isAttacking) 
			{
				anim.SetBool ("Attack", true);
				attackTime-=Time.deltaTime;
				if(attackTime < 0.0f)
				{
					isAttacking=false;
					anim.SetBool("Attack", false);
					attackTime=0.8f;
					direction*=-1;
				}
			}
			if (isHited) 
			{
				anim.SetBool ("Hit", true);
				hitTime-=Time.deltaTime;
				if(hitTime < 0.0f)
				{
					isHited=false;
					anim.SetBool("Hit", false);
					hitTime=0.2f;
				}
			}
			if (Timer <= 0.0f) {
				DemonInfo.text=String.Format("");
				Destroy (gameObject);
			}
			
			CheckPoisoned ();
			CheckSick ();
			//anim.SetBool("Hit", false);
			//anim.SetBool("Attack", false);
		}
		void OnCollisionEnter2D(Collision2D col){
			if ((col.gameObject.tag == "Wall")||(col.gameObject.tag == "MovingEnemy"))
				direction *= -1f;
			if (col.gameObject.tag == "Player") {
				if(attackTime==0.8f)
				{
				anim.SetBool ("Attack", true);
				isAttacking=true;
				Settings.currentPlayer.currentHP -= takeHP;
				col.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0,450));
				if((col.gameObject.transform.position.x>gameObject.transform.position.x&&direction<0)||(col.gameObject.transform.position.x<gameObject.transform.position.x&&direction>0))
				{
					direction*=-1f;
				}
				}
			}
			if (col.gameObject.tag == "Eye") {
				enemy.health = Health.PARALYSED;
			}
			if (col.gameObject.tag == "Spittle") {
				enemy.health = Health.POISONED;
				anim.SetBool("Hit", true);
				isHited=true;
			}
			if (col.gameObject.tag == "Lightning") {
				Slider slide = (GameObject.FindWithTag ("PowerChoose")).GetComponent<Slider> ();
				float Power = slide.value * 100;
				if (Power == 0)
					Power = 1;
				try {
					Settings.currentPlayer.UseArtifact (new LightningStick (), enemy, Power);;
					anim.SetBool("Hit", true);
					isHited=true;
				} catch (Exception e) {
					TextExceptionScript.TextWrite(e.Message);
				}
			}
		}
		void OnTriggerEnter2D(Collider2D col)
		{
			if ((col.gameObject.tag == "Wall")||(col.gameObject.tag == "MovingEnemy"))
				direction *= -1f;
			if (col.gameObject.tag == "Eye")
			{
				enemy.health = Health.PARALYSED;
			}
			if (col.gameObject.tag == "Spittle")
			{
				enemy.health = Health.POISONED;
				anim.SetBool("Hit", true);
				isHited=true;
			}
			if (col.gameObject.tag == "Lightning")
			{
				Slider slide = (GameObject.FindWithTag ("PowerChoose")).GetComponent<Slider> ();
				float Power = slide.value * 100;
				if (Power == 0)
					Power = 1;
				try 
				{
					Settings.currentPlayer.UseArtifact (new LightningStick (), enemy, Power);
					anim.SetBool("Hit", true);
					isHited=true;
				} 
				catch (Exception e)
				{
					TextExceptionScript.TextWrite(e.Message);
				}
			}
		}
		/*void OnTriggerEnter2D(Collider2D col){
			if ((col.gameObject.tag == "Wall")||(col.gameObject.tag == "MovingEnemy")||(col.gameObject.tag == "Player"))
				direction *= -1f;
			if (col.gameObject.tag == "Player") {
				anim.SetBool("MovingEnemyIsDead",true);
				speed=0;
				col.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0,800));
			}
			if (col.gameObject.tag == "Lightning") {
				anim.SetBool("MovingEnemyIsDead",true);
				speed=0;
			}
		}*/
		void CheckPoisoned(){
			if (enemy.health == Health.POISONED) {
				poisTimer -= Time.deltaTime;
				if(poisTimer <= 0)
				{
					poisTimer = 2f;
					enemy.currentHP -= 1;
					anim.SetBool("Hit", true);
					isHited=true;
				}
			}
		}
		void CheckSick(){
			if (enemy.health == Health.SICK) {
				sickTimer -= Time.deltaTime;
				if(sickTimer <=0)
				{
					sickTimer = 5f;
					enemy.currentHP -= 1;
					anim.SetBool("Hit", true);
					isHited=true;
				}
			}
		}
	}
}

