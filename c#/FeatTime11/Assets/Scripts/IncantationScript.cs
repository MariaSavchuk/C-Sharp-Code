using System;
using UnityEngine;
using System.Collections;

namespace RoleGame{
	public class IncantationScript : MonoBehaviour {
		public string incName="";
		private Animator anim;
		private GameObject but;
		void Start(){
			but = GameObject.FindWithTag(incName);
			anim = but.GetComponent<Animator>();
		}
		void OnTriggerEnter2D(Collider2D col){
			try 
			{
				if (col.gameObject.tag == "Player") 
				{
					anim.SetBool ("Known", true);
					if (incName == "AddHealth")
						Settings.currentPlayer.LearnIncantation (new AddHealth ());
					if (incName == "Cure")
						Settings.currentPlayer.LearnIncantation (new Cure ());
					if (incName == "Antidote")
						Settings.currentPlayer.LearnIncantation (new Antidote ());
					if (incName == "Revive")
						Settings.currentPlayer.LearnIncantation (new Revive ());
					if (incName == "Armour")
						Settings.currentPlayer.LearnIncantation (new Armour (ArmourScript.StartProtection));
					if(incName=="StartMoving")
						Settings.currentPlayer.LearnIncantation (new StartMoving ());
					Destroy (gameObject);
					
				}
			}
			catch (Exception e)
			{
				//textException=GameObject.FindWithTag("Exception");
				TextExceptionScript.TextWrite(e.Message);
			}
		}
	}
}

