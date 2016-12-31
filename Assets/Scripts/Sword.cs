using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Sword : BaseWeapon
{

	public Sword(int level) : base(level) {
		if (level == 1)
			itemScale = 7;
		else
			itemScale = 2;
		randomFactor = .8;
	}
}

