using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace RoleGame{
	public class MPInfoScript : MonoBehaviour {
		Text mp;
		void Start () {
			mp = GetComponent<Text> ();
		}
		void Update () {
			mp.text = Settings.currentPlayer.currentMana.ToString();
		}
	}
}