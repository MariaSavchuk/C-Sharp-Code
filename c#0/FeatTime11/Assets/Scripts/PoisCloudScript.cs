using UnityEngine;
using System.Collections;

namespace RoleGame{
	public class PoisCloudScript : MonoBehaviour {
		void OnTriggerEnter2D(Collider2D col){
			if (col.gameObject.tag == "Player") {
				Settings.currentPlayer.health = Health.POISONED;
				PlayerScript.poisLastTime= PlayerScript.poisDeltaTime;
			}
		}
	}
}
