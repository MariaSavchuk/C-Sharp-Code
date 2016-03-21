using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

namespace RoleGame
{
	class TargetScript : MonoBehaviour 
	{
		public static Wizard Target;
		private Text TargetInfo;
		void Start()
		{
			Target = new Wizard ("Tar", Race.HUMAN, Gender.FEMALE);
			if(gameObject.name == "Princess")
				Target.health = Health.PARALYSED;
			if (gameObject.name == "Monk")
				Target.currentHP = 0;
			TargetInfo = GameObject.FindWithTag ("TargetInfo").GetComponent<Text> ();

		}
		void Update(){
			if (gameObject.name == "Princess") 
			{
				if(Target.health==RoleGame.Health.NONE)
				{
					EndColliderScript.IHaveIt = true;
					gameObject.GetComponent<Animator>().SetBool("Activate", true);
					TargetInfo.text = String.Format ("");
				}
			}
			if (gameObject.name == "Monk") 
			{
				if(Target.condition != Condition.DEAD)
				{
					EndColliderScript.IHaveIt = true;
					gameObject.GetComponent<Animator>().SetBool("Activate", true);
					TargetInfo.text = String.Format ("");
				}
			}
		}
		void OnTriggerEnter2D(Collider2D col){
			if (col.gameObject.tag == "Player") {
				Toggle tog=(GameObject.FindWithTag("CheckInc")).GetComponent<Toggle>();
				tog.interactable=true;
				Animator anim=tog.GetComponent<Animator>();
				anim.SetBool("Interactable",true);
			}
		}
		void OnTriggerExit2D(Collider2D col)
		{
			if (col.gameObject.tag == "Player") 
			{
				Toggle tog=(GameObject.FindWithTag("CheckInc")).GetComponent<Toggle>();
				tog.interactable=false;
				tog.isOn = false;
				//Settings.currentPlayer.currentHP=0;
				Animator anim=tog.GetComponent<Animator>();
				anim.SetBool("Interactable",false);
			}


		}
		// Update is called once per fram
	}
}
