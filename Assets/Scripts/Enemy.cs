using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Enemy
{
	private static Random random = new Random();
    private int currentHP;
    private int maxHP;
    private int currentMP;
    private int strength;
    private int intelligence;
    private int dexterity;
    private int stamina;
    private int level;
    public int MaxHP { get; set; }
    public int Strength { get; set; }
    public int Intelligence { get; set; }
    public int Dexterity { get; set; }
    public int Stamina
    {
        get { return stamina; }
        set { stamina = value; }
    }
    public int CurrentHP { get; set; }
    public int Level {
        get
        {
            return level;
        }
        set
        {
            level = value;
        }
    }
    private string name;
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }
		
    public Double ExperienceToAward { get; set; }
	private BaseWeapon equippedWeapon;
	public BaseWeapon EquippedWeapon {
		get { return equippedWeapon; }
		set { equippedWeapon = value; }
	}

    public Enemy() {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        Range<int> levelModifier = new Range<int>(level, level + 5);
        name = new string(Enumerable.Repeat(chars, 5)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        level = GameManager.instance.Player.Level;
        strength = 10 + levelModifier.nextInt();
        intelligence = 10 + levelModifier.nextInt();
        dexterity = 10 + levelModifier.nextInt();
        stamina = 10 + levelModifier.nextInt();
        MaxHP = CurrentHP = CalculateMaxHP();
        Strength = 10;
        Intelligence = 10;
        Dexterity = 10;
        Stamina = 10;
        ExperienceToAward = CalculateEXPAwarded();
		equippedWeapon = CreateRandomWeapon();
    }

	public int CalculateDamage() {
		return random.Next (0 + equippedWeapon.MinDamage, 3 + equippedWeapon.MaxDamage);
	}

	public BaseWeapon CreateRandomWeapon()
    {
		BaseWeapon.WeaponTypes weaponType = (BaseWeapon.WeaponTypes)random.Next(0, 2);
		switch(weaponType)
        {
            case BaseWeapon.WeaponTypes.AXE:
                return new Axe(Level);
            case BaseWeapon.WeaponTypes.SWORD:
                return new Sword(Level);
            default:
			    return new Sword(Level);
		}
	}

    private int CalculateMaxHP()
    {
        return (Level * 2) + stamina;
    }

    private double CalculateEXPAwarded()
    {
        double levelAdjusted = Level * 10;
        return (levelAdjusted - 8);
    }
}
