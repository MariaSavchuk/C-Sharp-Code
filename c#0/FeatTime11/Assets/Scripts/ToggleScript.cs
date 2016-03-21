using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace RoleGame
{
public class ToggleScript : MonoBehaviour {

		private Toggle tog;
		private Animator anim;
	// Use this for initialization
	void Start () {
			tog = GetComponent<Toggle> ();
			anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
			if (tog.isOn)
				anim.SetBool ("Is On", true);
			else
				anim.SetBool ("Is On", false);
	
	}
}
}
