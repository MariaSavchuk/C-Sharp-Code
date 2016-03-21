using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
namespace RoleGame
{
public class NearTargetScript : MonoBehaviour {
	private Text TargetInfo;
	public string info;
	// Use this for initialization
	void Start () {
		TargetInfo = GameObject.FindWithTag ("TargetInfo").GetComponent<Text> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D col){

		if ((col.gameObject.tag == "Player")&&((TargetScript.Target.health!=Health.NONE)||(TargetScript.Target.currentHP!=TargetScript.Target.maxHP))) {
				TargetInfo.text =info;
		}
	}
	
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") {
			TargetInfo.text = String.Format ("");
		}
	}
}
}
