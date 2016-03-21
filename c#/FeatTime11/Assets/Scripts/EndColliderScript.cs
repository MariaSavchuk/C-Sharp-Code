using UnityEngine;
using System.Collections;

namespace RoleGame{
	public class EndColliderScript : MonoBehaviour {
		public static bool IHaveIt;
		void Start(){
			IHaveIt = false;
		}
		void OnTriggerEnter2D(Collider2D col){
			if (col.gameObject.tag == "Player") {
				if(IHaveIt == true)
					Settings.LevelFinished();
			}
		}
		
	}
}
