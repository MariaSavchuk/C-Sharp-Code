using UnityEngine;
using System.Collections;

namespace RoleGame{
	public class SickStormScript : MonoBehaviour {
		void OnTriggerEnter2D(Collider2D col){
			if (col.gameObject.tag == "Player") {
				Settings.currentPlayer.health = Health.SICK;
				PlayerScript.sickLastTime= PlayerScript.sickDeltaTime;
			}
		}
	}
}
