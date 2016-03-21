using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Runtime.Serialization;
namespace RoleGame
{
	[Serializable()]
	class Wizard : Hero,ISerializable
	{
		protected int _currentMana = 100;
		protected int _maxMana = 100;
		[NonSerialized]
		public HashSet<Incantation> magicBook;
		
		public int currentMana
		{
			get { return _currentMana; }
			set
			{
				if (value < 0)
					_currentMana = 0;
				if (value >= 0)
					_currentMana = value;
				if (_currentMana > _maxMana)
					_currentMana = _maxMana;
			}
		}
		public int maxMana
		{
			get { return _maxMana; }
			set
			{
				if (value >= 0)
					_maxMana = value;
				if (_currentMana > _maxMana)
					_currentMana = _maxMana;
			}
		}
		
		public Wizard(string _name, Race _race, Gender _gender) : base(_name, _race, _gender)
		{ 
			magicBook = new HashSet<Incantation>();
		}
		public Wizard(Wizard wizard) : base(wizard)
		{
			maxMana = wizard.maxMana;
			currentMana = wizard.currentMana;
			magicBook = new HashSet<Incantation>();
			foreach (Incantation inc in wizard.magicBook)
				magicBook.Add (inc);
		}
		public Wizard(SerializationInfo sInfo, StreamingContext contextArg):base(sInfo,contextArg)
		{
			this.currentMana = (int)sInfo.GetValue("CurrentMana", typeof(int));
			this.maxMana = (int)sInfo.GetValue("MaxMana", typeof(int));
		}
		public override string ToString()
		{
			string res = base.ToString();
			if(Settings.lang==Language.EN)
				res = String.Format(res + "\r\nmanapoints: " + currentMana + "\r\nmax manapoints " + maxMana);
			else
				res = String.Format(res + "\r\nМАНА:   " + currentMana + "/" + maxMana);
			return res;
		}
		public void LearnIncantation(Incantation incantation)
		{
			if (!magicBook.Contains(incantation))
				magicBook.Add(incantation);
			else
				throw new Exception("Персонаж уже знает это заклинание!");
		}
		public void ForgetIncantation(Incantation incantation)
		{
			if (magicBook.Contains<Incantation>(incantation))
				magicBook.Remove(incantation);
			else
				throw new Exception("Персонаж не знает этого заклинания");
		}
		public void SayIncantation(Incantation incantation, Hero target, float power)
		{
			if (magicBook.Contains(incantation))
			{
				incantation.MakeMagicAction(target, this, power);
				experience += 5;
				maxMana += 1;
			}
			else
				throw new Exception("Персонаж не знает этого заклинания");
		}
		public void SayIncantation(Incantation incantation, Hero target)
		{
			SayIncantation(incantation, target, 1);
		}
		public void SayIncantation(Incantation incantation, float power) 
		{
			SayIncantation(incantation, this, power);
		}
		public new void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
		{
			base.GetObjectData (sInfo, contextArg);
			sInfo.AddValue("CurrentMana", this.currentMana);
			sInfo.AddValue("MaxMana", this.maxMana);
			
		}
		public Wizard Copy()
		{
			Wizard wiz = new Wizard (this.name,this.race,this.gender);
			wiz.ableToMove = this.ableToMove;
			wiz.ableToSpeak = this.ableToSpeak;
			wiz.age = this.age;
			wiz.condition = this.condition;
			wiz.currentHP = this.currentHP;
			wiz.currentMana = this.currentMana;
			wiz.experience = this.experience;
			wiz.health = this.health;
			wiz.ID = this.ID;
			wiz.maxHP = this.maxHP;
			wiz.maxMana = this.maxMana;
			foreach (Artifact art in this.bag)
				wiz.bag.AddLast (art);
			return wiz;
		}
	}
}
