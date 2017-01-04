using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BaseWeapon : BaseItem
{
	protected double randomFactor;
	protected double itemScale;

	private static Random random = new Random();
	public enum WeaponTypes {
		AXE,
        SWORD,
        DAGGER
	}

	public int Damage {
		get { return CalculateDamage(); }
	}

	public int MinDamage {
		get{ return (int)Math.Round((1 - randomFactor) * Damage); }
	}

	public int MaxDamage {
		get{ return (int)Math.Round((1 + randomFactor) * Damage); }
	}

	public int CalculateDamage() {
        int enhancedEffect = GetStatValue(Stats.ENHANCED_EFFECT);
        if (enhancedEffect == 0)
            return (int)Math.Round(LevelRequirement * itemScale);
        else
            return (int)Math.Round(LevelRequirement * itemScale * (1 + ((double)enhancedEffect / (double)100)));
	}

	public BaseWeapon(int level) : base(level) {
	}
}

