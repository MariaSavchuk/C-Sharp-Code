using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
namespace RoleGame
{
public class CreateScript : MonoBehaviour 
{
		static Race race = Race.HUMAN;
		static string Name;
		static Gender gender = Gender.MALE;
	void Update () {
			SetAnimator ();
			SetAnimation ();

	}
		void Start()
		{
			race = Race.HUMAN;
			gender = Gender.MALE;
		}
		public void SetAnimator()
		{
			int buf = 0;
			if (race == Race.HUMAN)
				buf += 10;
			if (race == Race.DWARF)
				buf += 20;
			if (race == Race.ELF)
				buf += 30;
			if (race == Race.ORC)
				buf += 40;
			if (race == Race.GOBLIN)
				buf += 50;
			if (gender == Gender.MALE)
				buf += 1;
			if (gender == Gender.FEMALE)
				buf += 2;
			Settings.AnimationID = buf;
		}
		private void SetAnimation()
		{
			GameObject.FindWithTag ("CreateMenuImage").GetComponent<Animator> ().SetFloat ("Type", Settings.AnimationID);
		}
		public void CheckGender(int num)
		{
			if (num == 1)
				gender = Gender.MALE;
			else
				gender = Gender.FEMALE;
		}
		public void CheckRace(int num)
		{
			if (num == 1)
				race = Race.HUMAN;
			if (num == 2)
				race = Race.DWARF;
			if (num == 3)
				race = Race.ELF;
			if (num == 4)
				race = Race.ORC;
			if (num == 5)
				race = Race.GOBLIN;
		}
		public void Create()
		{
			InputField inputName = GameObject.FindWithTag ("EnterName").GetComponent<InputField>();
			Name=inputName.text;
			Settings.lastSavedPlayer = new Wizard (Name, race, gender);
			Settings.openedLevels = 1;
			Settings.lastLevel = 0;
			Application.LoadLevel("History");
		}
		public void Back()
		{
			Application.LoadLevel("StartMenu");
		}
		public void Exit()
		{
			Application.Quit ();
		}
}
}
