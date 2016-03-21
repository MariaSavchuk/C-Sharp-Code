using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace RoleGame{
	public class HPInfoScript : MonoBehaviour {
		Text hp;
		void Start () {
			hp = GetComponent<Text> ();
		}
		void Update () {
			hp.text = Settings.currentPlayer.currentHP.ToString();
		}
	}
}
