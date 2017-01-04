using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Axe : BaseWeapon
{

	public Axe(int level) : base(level) {
		if (level == 1)
			itemScale = 5;
		else
			itemScale = 1.5;
		randomFactor = .1;
        Modifier = Modifiers.NORMAL;
    }
}

