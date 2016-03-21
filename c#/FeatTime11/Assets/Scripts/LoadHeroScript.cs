using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace RoleGame{
	public class LoadHeroScript : MonoBehaviour {
		static string[] fileNames = new string[6];
		static string[] loadNames = new string[6];
		static int fileNum=-1;
		[Serializable()]
		class SaveClass:ISerializable{
			public Wizard player;
			public int levelsOpened;
			public int animationID;
			public LinkedList<Incantation> magicBook=new LinkedList<Incantation>();
			public SaveClass()
			{
				player = new Wizard(Settings.lastSavedPlayer);
				levelsOpened = Settings.openedLevels;
				foreach(Incantation inc in Settings.lastSavedPlayer.magicBook)
					magicBook.AddLast(inc);
				animationID=Settings.AnimationID;
			}
			public SaveClass(int z)
			{
				player = new Wizard("Name",Race.HUMAN,Gender.MALE);
				levelsOpened = 0;
				magicBook=new LinkedList<Incantation>();
				animationID=0;
			}
			public void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
			{
				sInfo.AddValue("LevelsOpend", this.levelsOpened);
				sInfo.AddValue("Player", this.player);
				sInfo.AddValue ("MagicBook", this.magicBook);
				sInfo.AddValue ("AnimationID", this.animationID);
				
			}
			public SaveClass(SerializationInfo sInfo, StreamingContext contextArg)
			{
				this.player = (Wizard)sInfo.GetValue("Player", typeof(Wizard));
				this.levelsOpened = (int)sInfo.GetValue("LevelsOpend", typeof(int));
				this.animationID = (int)sInfo.GetValue("AnimationID", typeof(int));
				this.magicBook=(LinkedList<Incantation>)sInfo.GetValue("MagicBook",typeof(LinkedList<Incantation>));
			}
		}
		
		void Start () {
			UpdateToogleNames ();
		}
		void UpdateToogleNames()
		{
			try{
				ReadFileNames();
				for (int i = 0; i<6; i++) {
					(GameObject.Find(String.Format("Label" + (i+1).ToString())).GetComponent<Text>()).text = loadNames[i];
					if(loadNames[i] == "")
						GameObject.Find(String.Format("Save" + (i+1).ToString())).GetComponent<Toggle>().interactable = false;
					else
						GameObject.Find(String.Format("Save" + (i+1).ToString())).GetComponent<Toggle>().interactable = true;
				}
			}
			catch(Exception e)
			{
				Debug.Log(e.Message+"+"+e.GetType());
			}
		}
		public static void ReadFileNames()
		{
			FileStream fin;
			try{
				fin = new FileStream(@"Saves\filenames.txt", FileMode.Open, FileAccess.Read);
				
				StreamReader fstream = new StreamReader(fin);
				try
				{
					int i = 0;
					while(!fstream.EndOfStream)
					{
						fileNames[i] = fstream.ReadLine();
						if(!fstream.EndOfStream)
							loadNames[i] = fstream.ReadLine();
						else
							loadNames[i]="";
						i++;
						if(i==6)
							break;
					}
					for(int j = i; j< 6; j++)
					{
						fileNames[j] = "";
						loadNames[j] = "";
					}
					
					fstream.Close ();
					fin.Close();
				}
				catch (Exception e)
				{
					Debug.Log(e.Message);
				}
				finally 
				{
					fstream.Close();
				}
			}
			catch(Exception e)
			{
				Debug.Log(e.Message+"+"+e.GetType());
			}
		}
		public void ChooseName(int num)
		{
			fileNum = num;
		}
		private void LoadPlayer()
		{
			try
			{
				if(fileNum!=-1)
				{
					SaveClass save = new SaveClass (6);
					Debug.Log("SaveClass");
					FileStream fstream = File.Open(String.Format(@"Saves\save"+fileNum.ToString()+ ".txt"), FileMode.Open);
					BinaryFormatter binaryFormatter = new BinaryFormatter();
					Debug.Log("doneLoadPlayer");
					save = (SaveClass)binaryFormatter.Deserialize(fstream);
					Debug.Log("donedeserialize");
					Settings.lastSavedPlayer = save.player.Copy();
					Debug.Log("donedeserialize");
					Settings.openedLevels = save.levelsOpened;
					Settings.lastLevel = Settings.openedLevels - 1;
					Settings.AnimationID = save.animationID;
					Settings.lastSavedPlayer.magicBook=new HashSet<Incantation>();
					foreach(Incantation inc in save.magicBook)
					{
						Settings.lastSavedPlayer.magicBook.Add(inc);
					}
					
					fstream.Close();
				}
			}
			catch(Exception e)
			{
				Debug.Log(e.Message+"+"+e.ToString());
			}
		}
		public void Load ()
		{
			if (fileNum != -1) {
				LoadPlayer ();
				Application.LoadLevel ("ChooseLevelScene");
			}
		}
		public void Delete()
		{
			try{
				ClearFile (fileNum);
				UpdateToogleNames ();
				for (int i = 0; i<6; i++) {
					Toggle tog=GameObject.Find(String.Format("Save" + (i+1).ToString())).GetComponent<Toggle>();
					if(tog.interactable==true)
					{
						tog.isOn=true;
						break;
					}
					
					
					Debug.Log("dgfd");
				}
			}
			catch
			{
				Debug.Log ("++");
			}
			
		}
		public void ClearFile (int num)
		{
			FileStream  g = new FileStream(@"Saves\filenames.txt", FileMode.Open, FileAccess.Write);
			StreamWriter fstream = new StreamWriter(g);
			for(int i = 0;i<6; i++)
			{
				if(i!=num-1)
				{
					fstream.WriteLine(fileNames[i]);
					fstream.WriteLine(loadNames[i]);
				}
				else
				{
					fileNames[i]="";
					fileNames[i]="";
					fstream.WriteLine("");
					fstream.WriteLine("");
				}
			}
			fstream.Close ();
			g.Close ();
			
		}
		public static void Save()
		{
			ReadFileNames ();
			try
			{
				int num = -1;
				int ind=-1;
				int indmin=-1;
				for (int i=0; i<6; i++) {
					if(fileNames[i] == "")
					{
						num = i;
						fileNames[i] = String.Format(@"Saves\save" + (i+1).ToString() + ".txt");
						loadNames[i] = String.Format(Settings.lastSavedPlayer.name+"_"+DateTime.Now.ToString());
						break;
					}
				}
				if(num==-1)
				{
					Debug.Log ("num=-1");
					DateTime now=DateTime.Now;
					DateTime date=DateTime.Now;
					DateTime datemin=DateTime.Now;
					for (int i=0; i<6; i++) 
					{
						
						DateTime D= DateTime.Parse(loadNames[i].Split (new char[]{'_'})[loadNames[i].Split (new char[]{'_'}).Length-1]);
						Debug.Log ("parse");
						if(D.CompareTo(datemin)==-1)
						{
							datemin=D;
							indmin=i;
						}
						Debug.Log(Settings.lastSavedPlayer.name);
						if(loadNames[i].IndexOf(Settings.lastSavedPlayer.name+"_")==0)
						{
							D= DateTime.Parse(loadNames[i].Split (new char[]{'_'})[loadNames[i].Split (new char[]{'_'}).Length-1]);
							if(D.CompareTo(date)==-1)
							{
								date= D;
								ind=i;
							}
							
						}
					}
					Debug.Log(datemin);
					if(date.CompareTo(now)==0)
					{
						Debug.Log("Compare");
						date=datemin;
						ind=indmin;
					}
					num=ind;
					fileNames[ind] = String.Format(@"Saves\save" + (ind+1).ToString() + ".txt");
					loadNames[ind] = String.Format(Settings.lastSavedPlayer.name+"_"+DateTime.Now.ToString());
				}
				
				BinaryFormatter sr = new BinaryFormatter();
				FileStream f = new FileStream(fileNames[num], FileMode.Create, FileAccess.Write);
				SaveClass save = new SaveClass();
				Debug.Log("done1");
				sr.Serialize(f, save);
				f.Close();
				FileStream  g = new FileStream(@"Saves\filenames.txt", FileMode.Create, FileAccess.Write);
				StreamWriter fstream = new StreamWriter(g);
				for(int i = 0;i<6; i++)
				{
					fstream.WriteLine(fileNames[i]);
					fstream.WriteLine(loadNames[i]);
				}
				
				fstream.Close();
				g.Close();
			}
			catch(Exception e)
			{
				Debug.Log(e.Message+"+"+e.ToString());
			}
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

