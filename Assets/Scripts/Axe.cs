using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Axe : BaseWeapon
{
	public Axe(int level) : base(level) {
		itemScale = 2;
		randomFactor = .15;
	}
}

