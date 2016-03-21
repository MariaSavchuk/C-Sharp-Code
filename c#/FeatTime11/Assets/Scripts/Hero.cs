using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RoleGame
{
	[Serializable()]
	class Hero : IComparable,ISerializable
	{
		
		protected static int nextID = 1;
		protected uint _age = 0;
		protected int _currentHP = 100;
		protected int _maxHP = 100;
		protected uint _experience = 0;
		protected Health _health = Health.NONE;
		public int ID
		{
			get;
			protected set;
		}
		public string name
		{
			get;
			protected set;
		}
		public Condition condition
		{
			get;
			set;
		}
		public Health health
		{
			get { return _health; }
			set
			{
				_health = value;
				if (value == Health.PARALYSED)
					ableToMove = false;
				else
					ableToMove = true;
			}
		}
		public bool ableToSpeak
		{
			get;
			set;
		}
		public bool ableToMove
		{
			get;
			protected set;
		}
		public Race race
		{
			get;
			set;
		}
		public Gender gender
		{
			get;
			set;
		}
		public uint age
		{
			get { return _age; }
			set
			{
				if (value >= _age)
					_age = value;
			}
		}
		public int currentHP
		{
			get { return _currentHP; }
			set
			{
				if (value >= 0)
				{
					_currentHP = value;
					if (_currentHP > _maxHP)
						_currentHP = _maxHP;
				}
				else
					_currentHP = 0;
				if ((float)_currentHP / _maxHP < 0.1)
				{
					condition = Condition.WEAKENED;
					ableToSpeak = true;
				}
				if ((float)_currentHP / _maxHP >= 0.1)
				{
					condition = Condition.NORMAL;
					ableToSpeak = true;
				}
				if (_currentHP == 0)
				{
					condition = Condition.DEAD;
					ableToMove = false;
					ableToSpeak = false;
				}
			}
		}
		public int maxHP
		{
			get { return _maxHP; }
			set
			{
				if (value >= 0)
					_maxHP = value;
				if (_currentHP > maxHP)
					_currentHP = _maxHP;
			}
		}
		public uint experience
		{
			get { return _experience; }
			set
			{
				if (value >= _experience)
				{
					_experience = value;
					maxHP = (int)(100 + 10 * (_experience / 1000));
				}
			}
		}
		public LinkedList<Artifact> bag;
		public Hero(string _name, Race _race, Gender _gender)
		{
			ID = nextID++;
			if (_name != null)
				name = _name;
			else
				name = String.Format("New hero" + ID);
			condition = Condition.NORMAL;
			health = Health.NONE;
			ableToSpeak = true;
			ableToMove = true;
			race = _race;
			gender = _gender;
			bag = new LinkedList<Artifact>();
		}
		public Hero(Hero hero)
		{
			ID = nextID++;
			name = hero.name;
			race = hero.race;
			gender = hero.gender;
			age = hero.age;
			ableToMove = hero.ableToMove;
			ableToSpeak = hero.ableToSpeak;
			condition = hero.condition;
			health = hero.health;
			maxHP = hero.maxHP;
			currentHP = hero.currentHP;
			experience = hero.experience;
			bag = new LinkedList<Artifact>();
			foreach (Artifact art in hero.bag) {
				if(art is LittleLiveBottle)
					bag.AddLast(new LittleLiveBottle(art));
				if(art is MiddleLiveBottle)
					bag.AddLast(new MiddleLiveBottle(art));
				if(art is BigLiveBottle)
					bag.AddLast(new BigLiveBottle(art));
				if(art is LittleDeadBottle)
					bag.AddLast(new LittleDeadBottle(art));
				if(art is MiddleDeadBottle)
					bag.AddLast(new MiddleDeadBottle(art));
				if(art is BigDeadBottle)
					bag.AddLast(new BigDeadBottle(art));
				if(art is LightningStick)
					bag.AddLast(new LightningStick(art));
				if(art is FrogLegsDecoction)
					bag.AddLast(new FrogLegsDecoction(art));
				if(art is BasiliskEye)
					bag.AddLast(new BasiliskEye(art));
				if(art is PoisonousSpittle)
					bag.AddLast(new PoisonousSpittle(art));
			}
		}
		public Hero(SerializationInfo sInfo, StreamingContext contextArg)
		{
			this.ableToMove = (bool)sInfo.GetValue("AbleToMove", typeof(bool));
			this.ableToSpeak = (bool)sInfo.GetValue("AbleToSpeak", typeof(bool));
			this.age = (uint)sInfo.GetValue("Age", typeof(uint));
			this.condition = (Condition)sInfo.GetValue("Condition", typeof(Condition));
			this.currentHP = (int)sInfo.GetValue("CurrentHP", typeof(int));
			this.experience= (uint)sInfo.GetValue("Experience", typeof(uint));
			this.gender = (Gender)sInfo.GetValue("Gender", typeof(Gender));
			this.health = (Health)sInfo.GetValue("Health", typeof(Health));
			this.ID = (int)sInfo.GetValue("ID", typeof(int));
			this.maxHP = (int)sInfo.GetValue("MaxHP", typeof(int));
			this.name = (string)sInfo.GetValue("Name", typeof(string));
			this.race = (Race)sInfo.GetValue("Race", typeof(Race));
			this.bag= (LinkedList<Artifact>)sInfo.GetValue("Bag", typeof(LinkedList<Artifact>));
			
		}
		public int CompareTo(object obj)
		{
			if (!(obj is Hero))
				throw new ArgumentException("Object is not Hero");
			Hero hero = obj as Hero;
			if (this.experience > hero.experience)
				return 1;
			if (this.experience < hero.experience)
				return -1;
			return 0;
		}
		public override string ToString()
		{
			string buf = "";
			string res = "";
			if (Settings.lang == Language.EN)
			{
				res = String.Format("ID: " + ID + "\r\nname: " + name + "\r\ncondition: " + condition + "\r\nhealth: " + health);
				buf = ableToSpeak ? "is able to speak" : "is not able to speak";
				res = String.Format(res + "\r\n" + buf);
				buf = ableToMove ? "is able to move" : "is not able to move";
				res = String.Format(res + "\r\n" + buf + "\r\nrace: " + race + "\r\ngender: " + gender);
				res = String.Format(res + "\r\nage: " + age + "\r\ncurrent healthpoints: " + currentHP + "\r\nmax healthpoints: " + maxHP + "\r\nexperience: " + experience);
			}
			else 
			{
				res = String.Format("ИМЯ:   " + name);
				switch (health)
				{
				case Health.NONE:
					buf = "здоров";
					break;
				case Health.SICK:
					buf = "болен";
					break;
				case Health.PARALYSED:
					buf = "парализован";
					break;
				case Health.POISONED:
					buf = "отравлен";
					break;
				}
				res = String.Format(res + "\r\nСОСТОЯНИЕ: " + buf);
				switch (race)
				{
				case Race.HUMAN:
					buf = "человек";
					break;
				case Race.DWARF:
					buf = "гном";
					break;
				case Race.ELF:
					buf = "эльф";
					break;
				case Race.ORC:
					buf = "орк";
					break;
				case Race.GOBLIN:
					buf = "гоблин";
					break;
				}
				res = String.Format(res + "\r\nРАСА:   " + buf);
				res = String.Format(res +  "\r\nОПЫТ:   " + experience+"\r\nЗДОРОВЬЕ:   " + currentHP + "/" + maxHP);
			}
			return res;
		}
		public void TakeArtifact(Artifact artifact)
		{
			if ((artifact is LightningStick || artifact is BasiliskEye || artifact is PoisonousSpittle) && bag.Contains (artifact))
				throw new Exception ("Персонаж не может хранить более одного такого артефакта!");
			if (bag.Count < 6 )
				bag.AddLast(artifact);
			else
				throw new Exception("Мешок персонажа переполнен!");
		}
		public void ThrowArtifact(Artifact artifact)
		{
			if (bag.Contains(artifact))
				bag.Remove(artifact);
			else
				throw new Exception("В мешке персонажа нет такого артефакта!");
		}
		public void UseArtifact(Artifact artifact, Hero target, float power)
		{
			if (bag.Contains(artifact))
				foreach (Artifact art in bag)
			{
				if (art.Equals(artifact))
				{
					art.MakeMagicAction(target, this, power);
					experience += 5;
					if (!art.renewable && art.capacity == 0)
						ThrowArtifact(art);
					break;
				}
			}
			else
				throw new Exception("В мешке персонажа нет такого артефакта!");
		}
		public void UseArtifact(Artifact artifact, Hero target)
		{
			UseArtifact(artifact, target, 1);
		}
		public void UseArtifact(Artifact artifact, float power)
		{
			UseArtifact(artifact, this, power);
		}
		public void UseArtifact(Artifact artifact)
		{
			UseArtifact(artifact, this, 1);
		}
		public void GiveArtifact(Artifact artifact, Hero target)
		{
			if (bag.Contains(artifact))
			{
				ThrowArtifact(artifact);
				target.TakeArtifact(artifact);
			}
			else
				throw new Exception("В мешке персонажа нет такого артефакта!");
		}
		public void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
		{
			sInfo.AddValue("AbleToMove", this.ableToMove);
			sInfo.AddValue("AbleToSpeak", this.ableToSpeak);
			sInfo.AddValue("Age", this.age);
			sInfo.AddValue("Condition", this.condition);
			sInfo.AddValue("CurrentHP", this.currentHP);
			sInfo.AddValue("Experience", this.experience);
			sInfo.AddValue("Gender", this.gender);
			sInfo.AddValue("Health", this.health);
			sInfo.AddValue("ID", this.ID);
			sInfo.AddValue("MaxHP", this.maxHP);
			sInfo.AddValue("Name", this.name);
			sInfo.AddValue("Race", this.race);
			sInfo.AddValue("Bag", this.bag);
			
		}
	}
}
