using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RoleGame
{
	[Serializable()]
	abstract class Artifact : IMagic, ISerializable
	{
		protected int _capacity = 0;
		public int capacity
		{
			get { return _capacity; }
			protected set
			{
				if (value >= 0)
					_capacity = value;
				else
					_capacity = 0;
			}
		}
		public bool renewable
		{
			get;
			protected set;
		}
		
		public Artifact(int _cap, bool _new)
		{
			capacity = _cap;
			renewable = _new;
		}
		public Artifact(Artifact art)
		{
			capacity = art.capacity;
			renewable = art.renewable;
		}
		public Artifact(SerializationInfo sInfo, StreamingContext contextArg)
		{
			this.capacity = (int)sInfo.GetValue("Capasity", typeof(int));
			this.renewable = (bool)sInfo.GetValue("Renewable", typeof(bool));
		}
		public virtual void MakeMagicAction(Hero target, Hero actor, float power) { }
		public override bool Equals(object obj)
		{
			if (!(obj is Artifact))
				return false;
			Artifact artifact = (obj as Artifact);
			return (this.ToString()).Equals(artifact.ToString());
		}
		public override int GetHashCode()
		{
			return (this.ToString()).GetHashCode();
		}
		public void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
		{
			sInfo.AddValue("Capasity", this.capacity);
			sInfo.AddValue("Renewable", this.renewable);
		}
	}
	//-------------------------------------------------------------------------------
	//-------------------------------------------------------------------------------
	//-------------------------------------------------------------------------------
	[Serializable()]
	class LittleLiveBottle : Artifact,ISerializable
	{
		public LittleLiveBottle() : base(10, false) { }
		public LittleLiveBottle(Artifact art) : base(art) { }
		public override void MakeMagicAction(Hero target, Hero actor, float power)
		{
			MakeMagicAction(actor);
		}
		public void MakeMagicAction(Hero actor)
		{
			actor.currentHP += capacity;
			capacity = 0;
		}
		public LittleLiveBottle(SerializationInfo sInfo, StreamingContext contextArg):base(sInfo,contextArg)
		{
		}
		
		public new void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
		{
			base.GetObjectData (sInfo, contextArg);
		}
	}
	//-----------------------------------------------------------------------------
	[Serializable()]
	class MiddleLiveBottle : Artifact, ISerializable
	{
		public MiddleLiveBottle() : base(25, false) { }
		public MiddleLiveBottle(Artifact art) : base(art) { }
		public override void MakeMagicAction(Hero target, Hero actor, float power)
		{
			MakeMagicAction(actor);
		}
		public void MakeMagicAction(Hero actor)
		{
			actor.currentHP += capacity;
			capacity = 0;
		}
		public MiddleLiveBottle(SerializationInfo sInfo, StreamingContext contextArg):base(sInfo,contextArg)
		{
		}
		
		public new void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
		{
			base.GetObjectData (sInfo, contextArg);
		}
	}
	//-----------------------------------------------------------------------------
	[Serializable()]
	class BigLiveBottle : Artifact, ISerializable
	{
		public BigLiveBottle() : base(50, false) { }
		public BigLiveBottle(Artifact art) : base(art) { }
		public override void MakeMagicAction(Hero target, Hero actor, float power)
		{
			MakeMagicAction(actor);
		}
		public void MakeMagicAction(Hero actor)
		{
			actor.currentHP += capacity;
			capacity = 0;
		}
		public BigLiveBottle(SerializationInfo sInfo, StreamingContext contextArg):base(sInfo,contextArg)
		{
		}
		
		public new void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
		{
			base.GetObjectData (sInfo, contextArg);
		}
	}
	//-----------------------------------------------------------------------------
	[Serializable()]
	class LittleDeadBottle : Artifact, ISerializable
	{
		public LittleDeadBottle() : base(10, false) { }
		public LittleDeadBottle(Artifact art) : base(art) { }
		public override void MakeMagicAction(Hero target, Hero actor, float power)
		{
			MakeMagicAction(actor);
		}
		public void MakeMagicAction(Hero actor)
		{
			if (!(actor is Wizard))
				throw new Exception("Маной обладает только маг");
			(actor as Wizard).currentMana += capacity;
			capacity = 0;
		}
		public LittleDeadBottle(SerializationInfo sInfo, StreamingContext contextArg):base(sInfo,contextArg)
		{
		}
		
		public new void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
		{
			base.GetObjectData (sInfo, contextArg);
		}
	}
	//-----------------------------------------------------------------------------
	[Serializable()]
	class MiddleDeadBottle : Artifact, ISerializable
	{
		public MiddleDeadBottle() : base(25, false) { }
		public MiddleDeadBottle(Artifact art) : base(art) { }
		public override void MakeMagicAction(Hero target, Hero actor, float power)
		{
			MakeMagicAction(actor);
		}
		public void MakeMagicAction(Hero actor)
		{
			if (!(actor is Wizard))
				throw new Exception("Маной обладает только маг");
			(actor as Wizard).currentMana += capacity;
			capacity = 0;
		}
		public MiddleDeadBottle(SerializationInfo sInfo, StreamingContext contextArg):base(sInfo,contextArg)
		{
		}
		
		public new void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
		{
			base.GetObjectData (sInfo, contextArg);
		}
	}
	//-----------------------------------------------------------------------------
	[Serializable()]
	class BigDeadBottle : Artifact, ISerializable
	{
		public BigDeadBottle() : base(50, false) { }
		public BigDeadBottle(Artifact art) : base(art) { }
		public override void MakeMagicAction(Hero target, Hero actor, float power)
		{
			MakeMagicAction(actor);
		}
		public void MakeMagicAction(Hero actor)
		{
			if (!(actor is Wizard))
				throw new Exception("Маной обладает только маг");
			(actor as Wizard).currentMana += capacity;
			capacity = 0;
		}
		public BigDeadBottle(SerializationInfo sInfo, StreamingContext contextArg):base(sInfo,contextArg)
		{
		}
		
		public new void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
		{
			base.GetObjectData (sInfo, contextArg);
		}
	}
	//-----------------------------------------------------------------------------
	[Serializable()]
	class LightningStick : Artifact, ISerializable
	{
		public LightningStick() : base(100, true) { }
		public LightningStick(Artifact art) : base(art) { }
		public override void MakeMagicAction(Hero target, Hero actor, float power) {
			if (capacity ==0)
				throw new Exception ("Артефакт уже истратил свою силу!");
			if (power > capacity)
				power = (float)capacity;
			target.currentHP -= (int)power;
			capacity -= (int)power;
		}
		public LightningStick(SerializationInfo sInfo, StreamingContext contextArg):base(sInfo,contextArg)
		{
		}
		
		public new void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
		{
			base.GetObjectData (sInfo, contextArg);
		}
		public void Renew()
		{
			if (capacity == 0)
				capacity = 100;
		}
	}
	//-----------------------------------------------------------------------------
	[Serializable()]
	class FrogLegsDecoction : Artifact,ISerializable
	{
		public FrogLegsDecoction() : base(0, false) { }
		public FrogLegsDecoction(Artifact art) : base(art) { }
		public override void MakeMagicAction(Hero target, Hero actor, float power)
		{
			MakeMagicAction(target, actor);
		}
		public void MakeMagicAction(Hero target, Hero actor) {
			if (target.health == Health.POISONED)
				target.health = Health.NONE;
			else
				throw new Exception("Артефакт не оказал воздействие, т.к. персонаж не отравлен!");
		}
		public FrogLegsDecoction(SerializationInfo sInfo, StreamingContext contextArg):base(sInfo,contextArg)
		{
		}
		
		public new void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
		{
			base.GetObjectData (sInfo, contextArg);
		}
	}
	//-----------------------------------------------------------------------------
	[Serializable()]
	class PoisonousSpittle : Artifact, ISerializable
	{
		public PoisonousSpittle() : base(30, true) { }
		public PoisonousSpittle(Artifact art) : base(art) { }
		public override void MakeMagicAction(Hero target, Hero actor, float power)
		{
			MakeMagicAction(target, actor);
		}
		public void MakeMagicAction(Hero target, Hero actor)
		{
			target.health = Health.POISONED;
			target.currentHP -= capacity;
			capacity = 0;
		}
		public PoisonousSpittle(SerializationInfo sInfo, StreamingContext contextArg):base(sInfo,contextArg)
		{
		}
		
		public new void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
		{
			base.GetObjectData (sInfo, contextArg);
		}
	}
	//-----------------------------------------------------------------------------
	[Serializable()]
	class BasiliskEye : Artifact,ISerializable
	{
		public BasiliskEye() : base(0, false) { }
		public BasiliskEye(Artifact art) : base(art) { }
		public override void MakeMagicAction(Hero target, Hero actor, float power)
		{
			MakeMagicAction(target, actor);
		}
		public void MakeMagicAction(Hero target, Hero actor)
		{
			if (target.condition != Condition.DEAD)
				target.health = Health.PARALYSED;
			else
				throw new Exception("Артефакт не оказал воздействие, т.к. персонаж мертв!");
		}
		public BasiliskEye(SerializationInfo sInfo, StreamingContext contextArg):base(sInfo,contextArg)
		{
		}
		
		public new void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
		{
			base.GetObjectData (sInfo, contextArg);
		}
	}
}
