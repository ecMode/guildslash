using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BaseEntity
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
    private string name;
    public int MaxHP {
        get
        {
            return maxHP;
        }
        set
        {
            maxHP = value;
        }
    }
    public int Strength
    {
        get { return strength; }
        set { strength = value; }
    }
    public int Intelligence
    {
        get { return intelligence; }
        set { intelligence = value; }
    }
    public int Dexterity
    {
        get { return dexterity; }
        set { dexterity = value; }
    }
    public int Stamina
    {
        get { return stamina; }
        set { stamina = value; }
    }
    public int CurrentHP
    {
        get
        {
            return currentMP;
        }
        set
        {
            currentMP = value;
        }
    }
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
		
	private BaseWeapon equippedWeapon;
	public BaseWeapon EquippedWeapon {
		get { return equippedWeapon; }
		set { equippedWeapon = value; }
	}

	public int CalculateDamage()
    {
        int minDamage = equippedWeapon == null ? 0 : equippedWeapon.MinDamage;
        int maxDamage = equippedWeapon == null ? 0 : equippedWeapon.MaxDamage;
        return random.Next (0 + minDamage, 3 + maxDamage);
	}
}
