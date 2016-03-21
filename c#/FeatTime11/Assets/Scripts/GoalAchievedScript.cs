using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace RoleGame{
	public class GoalAchievedScript : MonoBehaviour {
		Animator anim;
		bool haveToCheck = true;
		void Start () {
			anim = GetComponent<Animator> ();
			anim.SetBool("IsAchieved", false);
		}
		void Update () {
			if (haveToCheck && EndColliderScript.IHaveIt) {
				anim.SetBool("IsAchieved", true);
				haveToCheck = false;
				TextExceptionScript.TextWrite("Цель достигнута!");
			}
		}
	}
}
