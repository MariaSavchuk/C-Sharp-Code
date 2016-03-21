using UnityEngine;
using System.Collections;

namespace RoleGame{
public class StaticEnemyScript : MonoBehaviour {

	public int takeHP = 5;
	
	void OnCollisionEnter2D(Collision2D col){
			if (col.gameObject.tag == "Player") {
				Settings.currentPlayer.currentHP -= takeHP;
				col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 600));
			}
		}
	/*void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			Settings.currentPlayer.currentHP += addHP;
			Settings.currentPlayer.health = Health.NONE;
			Destroy (gameObject);
		}
	}*/
}
}
