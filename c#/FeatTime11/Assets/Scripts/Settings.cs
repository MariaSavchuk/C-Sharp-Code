using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace RoleGame
{
    class Settings
    {
        static public Wizard currentPlayer;
		static public Wizard lastSavedPlayer;
        static public Language lang = Language.RU;
        static public bool sound = false;
		static public int AnimationID=11;
		static public int openedLevels = 1;
		static public int lastLevel = 0;
		static public string[] Levels = {"Level1", "Level2", "Level3", "Level4", "Level5", "Level6", "Level7"};

		public static void LevelFinished(){
			if (lastLevel >= openedLevels - 2) {
				Settings.currentPlayer.experience += 100;
				Settings.lastSavedPlayer = new Wizard(Settings.currentPlayer);
			}
			if (lastLevel == openedLevels - 1)
				openedLevels++;
			if (lastLevel == Levels.Length - 1)
				Application.LoadLevel("Finish");
			else 
				Application.LoadLevel ("ChooseLevelScene");
			//lastLevel++;
			/*if (lastLevel > Levels.Length-1)
				Application.LoadLevel ("StartMenu");
			else
				Application.LoadLevel(Levels[++lastLevel]);*/
		}
		public static void LevelFailed(){
			Application.LoadLevel("Fail");
		}
		public static void StartLevel(){

			Settings.currentPlayer = new Wizard(lastSavedPlayer);
			//Settings.currentPlayer = Settings.lastSavedPlayer;
			ButtonArtifactScript.UpdateTypeArray ();
			foreach (Artifact art in currentPlayer.bag)
				if (art is LightningStick) 
					(art as LightningStick).Renew ();
			//LoadHeroScript.Save ();
		}

	}
}
