using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoleGame
{
	interface IMagic
	{
		void MakeMagicAction(Hero target, Hero actor, float power);
	}
}