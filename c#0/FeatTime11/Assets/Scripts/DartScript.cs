using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

namespace RoleGame{
	public class DartScript : MonoBehaviour {
		SpriteRenderer rend;
		BoxCollider2D boxCol;
		private bool isFacingRight = true;
		float dir = 0;
		void Start(){
			rend = GetComponent<SpriteRenderer> ();
			rend.enabled = false;
			boxCol = GetComponent<BoxCollider2D> ();
			boxCol.isTrigger = true;
			
		}
		void FixedUpdate () {
			if (rend.enabled == true) {
				if (PlayerScript._isFacingRight) {
					if (!isFacingRight)
						Flip ();
					if (dir == 0) {
						dir = 1;
						transform.position = GameObject.FindWithTag ("Player").transform.position;
					}
				} else {
					if (isFacingRight)
						Flip ();
					if (dir == 0) {
						dir = -1;
						transform.position = GameObject.FindWithTag ("Player").transform.position;
					}
				}
				if (boxCol.isTrigger)
					boxCol.isTrigger = false;
				//GetComponent<Rigidbody2D> ().velocity = new Vector2 (1f * dir, (float)(GetComponent<Rigidbody2D> ().velocity.y));
				transform.position = new Vector3 (transform.position.x + dir * (0.1f), transform.position.y, transform.position.z);
			} 
			else 
			{
				transform.position = GameObject.FindWithTag ("Player").transform.position;
			}
		}
		void OnCollisionEnter2D(Collision2D col){

			if (col.gameObject.tag != "Player") {
				if (tag == "Lightning") {
					if (col.gameObject.tag == "MovingEnemy")
					{
						try {
							Settings.currentPlayer.UseArtifact (new LightningStick (), new Hero("", Race.HUMAN, Gender.MALE), 5);
							//Destroy (col.gameObject);
						} catch (Exception e) {
							TextExceptionScript.TextWrite(e.Message);
						}
					}
					if (col.gameObject.tag == "Target") {

							Slider slide = (GameObject.FindWithTag ("PowerChoose")).GetComponent<Slider> ();
						float Power = slide.value * 100;
						if (Power == 0)
							Power = 1;
						try {
							Settings.currentPlayer.UseArtifact (new LightningStick (), TargetScript.Target, Power);
						} catch (Exception e) {
							TextExceptionScript.TextWrite(e.Message);
						}
					}
				}
				if (tag == "Spittle") {
					if (col.gameObject.tag == "Target") {
						try {
							Settings.currentPlayer.UseArtifact (new PoisonousSpittle (), TargetScript.Target);
						} catch (Exception e) {
							TextExceptionScript.TextWrite(e.Message);
						}
					}
				}
				if (tag == "Eye") {
					if (col.gameObject.tag == "Target") {
						try {
							Settings.currentPlayer.UseArtifact (new BasiliskEye (), TargetScript.Target);	
						} catch (Exception e) {
							TextExceptionScript.TextWrite(e.Message);
						}
					}
				}
				rend.enabled = false;
				boxCol.isTrigger = true;
				transform.position = GameObject.FindWithTag ("Player").transform.position;
				dir = 0;
			}
		}
		void OnTriggerEnter2D(Collider2D col){
			if (col.gameObject.tag == "Wall") {
				rend.enabled = false;
				boxCol.isTrigger = true;
				transform.position = GameObject.FindWithTag ("Player").transform.position;
				dir = 0;
			}
		}
		private void Flip()
		{
			isFacingRight = !isFacingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}
}
