using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
namespace RoleGame
{
	class ArmourScript
	{
		public static int PlayerHP;
		public static Health PlayerHealth;
		public static float time=1f;
		public static void StartProtection(float _time)
		{
			time = _time;
			PlayerScript.isProtected= true;
			PlayerHP = Settings.currentPlayer.currentHP;
			PlayerHealth = Settings.currentPlayer.health;
			
		}
		public static void MakeProtection()
		{
			Settings.currentPlayer.currentHP = PlayerHP;
			Settings.currentPlayer.health = PlayerHealth;
			
		}
		public static void StopProtection()
		{
			Settings.currentPlayer.currentHP=PlayerHP;
			Settings.currentPlayer.health =PlayerHealth;
			PlayerScript.isProtected = false;
			
		}
	}
}

