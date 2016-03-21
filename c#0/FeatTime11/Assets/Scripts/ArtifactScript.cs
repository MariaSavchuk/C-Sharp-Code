using UnityEngine;
using System.Collections;
using System;

namespace RoleGame{
	public class ArtifactScript : MonoBehaviour {
		public string artName = "";

		void OnTriggerEnter2D(Collider2D col){
			try{
				if (col.gameObject.tag == "Player") {
					if (artName == "LittleLiveBottle"){
						Settings.currentPlayer.TakeArtifact(new LittleLiveBottle());
					}
					if (artName == "MiddleLiveBottle"){
						Settings.currentPlayer.TakeArtifact(new MiddleLiveBottle());
					}
					if (artName == "BigLiveBottle"){
						Settings.currentPlayer.TakeArtifact(new BigLiveBottle());
					}
					if (artName == "LittleDeadBottle"){
						Settings.currentPlayer.TakeArtifact(new LittleDeadBottle());
					}
					if (artName == "MiddleDeadBottle"){
						Settings.currentPlayer.TakeArtifact(new MiddleDeadBottle());
					}
					if (artName == "BigDeadBottle"){
						Settings.currentPlayer.TakeArtifact(new BigDeadBottle());
					}
					if (artName == "BasiliskEye"){
						Settings.currentPlayer.TakeArtifact(new BasiliskEye());
					}
					if (artName == "FrogLegsDecoction"){
						Settings.currentPlayer.TakeArtifact(new FrogLegsDecoction());
					}
					if (artName == "LightningStick"){
						Settings.currentPlayer.TakeArtifact(new LightningStick());
					}
					if (artName == "PoisonousSpittle"){
						Settings.currentPlayer.TakeArtifact(new PoisonousSpittle());
					}
					ButtonArtifactScript.UpdateTypeArray();
					Destroy (gameObject);
				}
			}
			catch(Exception e){
				TextExceptionScript.TextWrite(e.Message);
			}
		}
	}
}
