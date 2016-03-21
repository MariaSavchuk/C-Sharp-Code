using UnityEngine;
using System.Collections;
using System;
namespace RoleGame
{
public class StartMenuScript : MonoBehaviour {

		public void New()
		{
			Console.WriteLine("Start");
			Application.LoadLevel("CreateScene");
		}
		public void Load()
		{
			Application.LoadLevel("LoadScene");
		}
		public void Exit()
		{
			Application.Quit ();
		}
		public void Rules()
		{
			Application.LoadLevel("Rules");
		}
}
}
