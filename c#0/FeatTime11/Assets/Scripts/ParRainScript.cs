using UnityEngine;
using System.Collections;

namespace RoleGame{
	public class ParRainScript : MonoBehaviour {
		SpriteRenderer rend;
		public float timeActive = 1;
		private int whenActivated;
		void Start(){
			rend = GetComponent<SpriteRenderer> ();
			rend.enabled = false;
		}
		void Update(){
			if (rend.enabled == true) {
				timeActive-=Time.deltaTime;
			}
			if (rend.enabled == true && timeActive<0.0f)
				Destroy (gameObject);
		}
		void OnTriggerEnter2D(Collider2D col){
			if (col.gameObject.tag == "Player") {
				Settings.currentPlayer.health = Health.PARALYSED;
				rend.enabled = true;
			}
		}
	}
}

