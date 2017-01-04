using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Enemy : BaseEntity
{
	private static Random random = new Random();
    private List<string> names = new List<string> {
        "Rogue Two",
        "Acid Spitter",
        "Fancy Pants",
        "Berserker",
        "Archer",
        "The Malevolent One"
    };
		
    public Double ExperienceToAward { get; set; }

    public Enemy(int level) {
        /*const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        Name = new string(Enumerable.Repeat(chars, 5)
            .Select(s => s[random.Next(s.Length)]).ToArray());*/
        Name = names[random.Next(names.Count)];
        Range<int> levelModifier = new Range<int>(level, level + 5);
        Level = level;
        Strength = 10 + levelModifier.nextInt();
        Intelligence = 10 + levelModifier.nextInt();
        Dexterity = 10 + levelModifier.nextInt();
        Stamina = 10 + levelModifier.nextInt();
        MaxHP = CurrentHP = CalculateMaxHP();
        ExperienceToAward = CalculateEXPAwarded();
		EquippedWeapon = CreateRandomWeapon();
    }

	public BaseWeapon CreateRandomWeapon()
    {
		BaseWeapon.WeaponTypes weaponType = (BaseWeapon.WeaponTypes)random.Next(0, 10);
        BaseWeapon weapon;
		switch(weaponType)
        {
            case BaseWeapon.WeaponTypes.AXE:
                weapon = new Axe(Level);
                weapon.RandomizeStats();
                return weapon;
            case BaseWeapon.WeaponTypes.SWORD:
                weapon = new Sword(Level);
                weapon.RandomizeStats();
                return weapon;
            default:
			    return null;
		}
	}

    private int CalculateMaxHP()
    {
        return (Level * 2) + Stamina;
    }

    private double CalculateEXPAwarded()
    {
        double levelAdjusted = Level * 10;
        return (levelAdjusted - 8);
    }
}
