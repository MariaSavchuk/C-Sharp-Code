using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RoleGame
{
	[Serializable()]
	abstract class Incantation : IMagic,ISerializable
	{
		protected int _minMana;
		public int minMana
		{
			get { return _minMana; }
			protected set
			{
				if (value >= 0)
					_minMana = value;
				else
					_minMana = 0;
			}
		}
		public bool needToSpeak
		{
			get;
			protected set;
		}
		public bool needToMove
		{
			get;
			protected set;
		}
		
		public Incantation(int _minmana, bool _speak, bool _move)
		{
			minMana = _minmana;
			needToMove = _move;
			needToSpeak = _speak;
		}
		public Incantation(SerializationInfo sInfo, StreamingContext contextArg)
		{
			this.minMana = (int)sInfo.GetValue("MinMana", typeof(int));
			this.needToMove = (bool)sInfo.GetValue("NeedToMove", typeof(bool));
			this.needToSpeak = (bool)sInfo.GetValue("NeedToSpeak", typeof(bool));
		}
		public virtual void MakeMagicAction(Hero target, Hero actor, float power)
		{
			if (!(actor is Wizard))
				throw new Exception ("Произнести заклинание может только маг");
			if (needToMove && !actor.ableToMove)
				throw new Exception ("Персонаж не может двигаться!");
			if (power < 0)
				power = 0;
			if ((target.condition == Condition.DEAD)&&!(this is RoleGame.Revive)) 
			{
				throw new Exception("Персонаж мёртв!");
			}
			if ((actor as Wizard).currentMana < (uint)(minMana * power))
				throw new Exception(String.Format("Недостаточно маны! Необходимо: {0}",(uint)(minMana * power)));
			(actor as Wizard).currentMana -= (int)(minMana * power);
		}
		public override bool Equals(object obj)
		{
			if (!(obj is Incantation))
				return false;
			Incantation incantation = (obj as Incantation);
			return (this.ToString()).Equals(incantation.ToString());
		}
		public override int GetHashCode()
		{
			return (this.ToString()).GetHashCode();
		}
		public void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
		{
			sInfo.AddValue("MinMana", this.minMana);
			sInfo.AddValue("NeedToMove", this.needToMove);
			sInfo.AddValue("NeedToSpeak", this.needToSpeak);
		}
	}
	[Serializable()]
	class AddHealth : Incantation,ISerializable
	{
		public AddHealth()
			: base(2, true, true)
		{
		}
		public override void MakeMagicAction(Hero target, Hero actor, float power)
		{
			if ((target.maxHP - target.currentHP )<(int)(power * minMana)/2)
			{
				power=2*(target.maxHP-target.currentHP)/minMana;
			}
			if (target.currentHP == target.maxHP)
				throw new Exception ("Персонаж здоров!");

				base.MakeMagicAction (target, actor, power);
				target.currentHP += (int)(power * minMana) / 2;
		}
		public void MakeMagicAction(Hero target, Hero actor)
		{
			MakeMagicAction(target, actor, 1);
		}
		public void MakeMagicAction(Hero actor, float power)
		{
			MakeMagicAction(actor, actor, power);
		}
		public AddHealth(SerializationInfo sInfo, StreamingContext contextArg):base(sInfo,contextArg)
		{
		}
		public new void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
		{
			base.GetObjectData (sInfo, contextArg);
		}
	}
	[Serializable()]
	class Cure : Incantation,ISerializable
	{
		public Cure()
			: base(15, false, true)
		{
		}
		public override void MakeMagicAction(Hero target, Hero actor, float power) 
		{ 
			MakeMagicAction(target, actor);
		}
		public void MakeMagicAction(Hero target, Hero actor)
		{
			if (target.health == Health.SICK) 
			{
				base.MakeMagicAction(target, actor, 1);
				target.health = Health.NONE;
			}
			else
				throw new Exception("Заклинание не оказало воздействия, т.к. персонаж не болен!");
		}
		public Cure(SerializationInfo sInfo, StreamingContext contextArg):base(sInfo,contextArg)
		{
		}
		
		public new void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
		{
			base.GetObjectData (sInfo, contextArg);
		}
	}
	[Serializable()]
	class Antidote : Incantation,ISerializable
	{
		public Antidote()
			: base(30, true, true)
		{
		}
		public override void MakeMagicAction(Hero target, Hero actor, float power) {
			MakeMagicAction(target, actor);
		}
		public void MakeMagicAction(Hero target, Hero actor)
		{
			if (target.health == Health.POISONED) {
				base.MakeMagicAction(target, actor, 1);
				target.health = Health.NONE;

			}
			else
				throw new Exception("Заклинание не оказало воздействия, т.к. персонаж не отравлен!");
		}
		public Antidote(SerializationInfo sInfo, StreamingContext contextArg):base(sInfo,contextArg)
		{
		}
		
		public new void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
		{
			base.GetObjectData (sInfo, contextArg);
		}
	}
	[Serializable()]
	class Revive : Incantation,ISerializable
	{
		public Revive()
			: base(150, false, true)
		{
		}
		public override void MakeMagicAction(Hero target, Hero actor, float power)
		{
			MakeMagicAction(target, actor);
		}
		public void MakeMagicAction(Hero target, Hero actor)
		{

			if (target.condition == Condition.DEAD)
			{
				base.MakeMagicAction(target, actor, 1);
				target.currentHP = target.maxHP;
			}
			else
				throw new Exception("Заклинание не оказало воздействия, т.к. персонаж не мёртв!");
		}
		public Revive(SerializationInfo sInfo, StreamingContext contextArg):base(sInfo,contextArg)
		{
		}
		
		public new void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
		{
			base.GetObjectData (sInfo, contextArg);
		}
	}
	[Serializable()]
	class Armour : Incantation,ISerializable
	{

		public delegate void StartProtection(float time);
		[NonSerialized]
		StartProtection launch;

		public Armour(StartProtection _launch)
			: base(20, true, true)
		{
			launch = _launch;
		}
		public override void MakeMagicAction(Hero target, Hero actor, float power)
		{
			if (power < 10)
				power = 10;
			base.MakeMagicAction(target, actor, power/10);
			launch((power/5));//типа единица времени 5 секунд
		}
		public void MakeMagicAction(Hero target, Hero actor)
		{
			MakeMagicAction(target, actor, 1);
		}
		public void MakeMagicAction(Hero actor, float power)
		{
			MakeMagicAction(actor, actor, power/10);
		}
		public Armour(SerializationInfo sInfo, StreamingContext contextArg):base(sInfo,contextArg)
		{
		}
		
		public new void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
		{
			base.GetObjectData (sInfo, contextArg);
		}
	}
	[Serializable()]
	class StartMoving : Incantation,ISerializable
	{
		public StartMoving()
			: base(85, true, false)
		{
		}
		public override void MakeMagicAction(Hero target, Hero actor, float power)
		{
			MakeMagicAction(target, actor);
		}
		public void MakeMagicAction(Hero target, Hero actor)
		{
			if (target.health == Health.PARALYSED)
			{
				base.MakeMagicAction(target, actor, 1);
				target.health = Health.NONE;
			}
			else
				throw new Exception("Заклинание не оказало воздействия, т.к. персонаж не болен!");
		}
		public StartMoving(SerializationInfo sInfo, StreamingContext contextArg):base(sInfo,contextArg)
		{
		}
		
		public new void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
		{
			base.GetObjectData (sInfo, contextArg);
		}
	}
}

