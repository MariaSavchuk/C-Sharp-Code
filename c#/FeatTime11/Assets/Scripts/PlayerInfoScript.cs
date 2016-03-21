using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace RoleGame
{
public class PlayerInfoScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public static void TextWrite()
	{
			Text Information = (GameObject.FindWithTag ("PlayerInfo")).GetComponent<Text> ();
			Information.text = Settings.currentPlayer.ToString ();
			//Information.text = TargetScript.Target.ToString ();
	}
}
}
