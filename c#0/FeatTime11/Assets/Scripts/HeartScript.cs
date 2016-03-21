using UnityEngine;
using System.Collections;

namespace RoleGame{
public class HeartScript : MonoBehaviour {
		void OnTriggerEnter2D(Collider2D col){
			if (col.gameObject.tag == "Player") {
				EndColliderScript.IHaveIt = true;
				Destroy (gameObject);
			}
		}
	}
}
