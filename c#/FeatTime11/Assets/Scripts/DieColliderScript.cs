using UnityEngine;
using System.Collections;

namespace RoleGame{
	public class DieColliderScript : MonoBehaviour {
		void OnTriggerEnter2D(Collider2D col){
			if (col.gameObject.tag == "Player") {
				Settings.LevelFailed();
			}
		}

	}
}
