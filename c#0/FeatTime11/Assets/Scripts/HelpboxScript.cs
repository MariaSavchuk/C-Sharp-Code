using UnityEngine;
using System.Collections;

namespace RoleGame{
public class HelpboxScript : MonoBehaviour {
		public int addHP = 30;

		/*void OnCollisionEnter2D(Collision2D col){
			if (col.gameObject.tag == "Player") {
				Settings.currentPlayer.currentHP += addHP;
				Settings.currentPlayer.health = Health.NONE;
				Destroy (gameObject);
			}
		}*/
		void OnTriggerEnter2D(Collider2D col){
			if (col.gameObject.tag == "Player") {
				Settings.currentPlayer.currentHP += addHP;
				Settings.currentPlayer.health = Health.NONE;
				Destroy (gameObject);
			}
		}

}
}
