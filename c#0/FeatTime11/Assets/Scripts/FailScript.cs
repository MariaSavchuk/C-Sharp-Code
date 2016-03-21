using UnityEngine;
using System.Collections;

namespace RoleGame{
	public class FailScript : MonoBehaviour {

		public void Close()
		{
			Application.LoadLevel("ChooseLevelScene");
		}
		public void Replay()
		{
			Application.LoadLevel (Settings.Levels [Settings.lastLevel]);
		}
	}
}
