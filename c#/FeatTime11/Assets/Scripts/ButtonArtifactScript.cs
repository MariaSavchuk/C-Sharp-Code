using UnityEngine;
using System.Collections;
using System;

namespace RoleGame{
	public class ButtonArtifactScript : MonoBehaviour {

		public static int[] TypeArray = new int[6];

		static int TypeID(Artifact art){
			int id = 0;
			if (art is LittleLiveBottle)
				id = 1;
			if (art is MiddleLiveBottle)
				id = 2;
			if (art is BigLiveBottle)
				id = 3;
			if (art is LittleDeadBottle)
				id = 4;
			if (art is MiddleDeadBottle)
				id = 5;
			if (art is BigDeadBottle)
				id = 6;
			if (art is BasiliskEye)
				id = 7;
			if (art is FrogLegsDecoction)
				id = 8;
			if (art is LightningStick)
				id = 9;
			if (art is PoisonousSpittle)
				id = 10;
			return id;
		}
		public static void UpdateTypeArray(){
			int i = 0;
			foreach (Artifact art in Settings.currentPlayer.bag) {
				TypeArray[i] = TypeID(art);
				i++;
			}
			for(int j= i; j<6; j++)
				TypeArray[j]= 0;
			GameObject[] buts = GameObject.FindGameObjectsWithTag ("ButArtifact");
			for(i = 0; i < 5; i++){
				for(int j = i; j < 6; j++){
					if(buts[i].name.CompareTo(buts[j].name) == 1){
						GameObject buf = buts[i];
						buts[i] = buts[j];
						buts[j] = buf;
					}
				}
			}
			/*for (i = 0; i<6; i++) {
				Animator anim = buts[i].GetComponent<Animator>();
				anim.SetInteger("Type", 0);
			}
			*/
			for (i = 0; i < 6; i++) {
				Animator anim = buts[i].GetComponent<Animator>();
				anim.SetFloat("TypeFloat", TypeArray[i]);
			}
		}
	}
}
