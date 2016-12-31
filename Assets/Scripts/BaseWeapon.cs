using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BaseWeapon : BaseItem
{
	protected int randomFactor;
	protected int itemScale;

	private static Random random = new Random();
	public enum WeaponTypes {
		AXE,
		DAGGER,
		SWORD
	}

	private int damage;
	public int Damage {
		get { return damage; }
		set { damage = value; }
	}
	public int MinDamage {
		get{ return (1 - randomFactor) * Damage; }
	}

	public int MaxDamage {
		get{ return (1 + randomFactor) * Damage; }
	}

	public int CalculateDamage() {
		return LevelRequirement * itemScale * GetStat(Stats.ENHANCED_EFFECT);
	}

	public BaseWeapon(int level) : base(level) {
		damage = CalculateDamage ();
	}
}

