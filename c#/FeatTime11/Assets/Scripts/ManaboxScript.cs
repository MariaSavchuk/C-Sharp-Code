using UnityEngine;
using System.Collections;

namespace RoleGame{
public class ManaboxScript : MonoBehaviour {

	public int addMana = 30;
	
	/*void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			Settings.currentPlayer.currentMana += addMana;
			Destroy (gameObject);
		}
	}*/
		void OnTriggerEnter2D(Collider2D col){
			if (col.gameObject.tag == "Player") {
				Settings.currentPlayer.currentMana += addMana;
				Destroy (gameObject);
			}
		}
}
}