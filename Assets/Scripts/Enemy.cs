using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Enemy
{
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
    public int Stamina { get; set; }
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

    private Range<int> damagePotential;
    public Range<int> DamagePotential
    {
        get
        {
            return damagePotential;
        }
        set
        {
            damagePotential = value;
        }
    }
    public Double ExperienceToAward { get; set; }

    private static Random random = new Random();
    public Enemy() {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        Name = new string(Enumerable.Repeat(chars, 5)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        Level = GameManager.instance.Player.Level;
        MaxHP = CurrentHP = CalculateMaxHP();
        Strength = 10;
        Intelligence = 10;
        Dexterity = 10;
        Stamina = 10;
        DamagePotential = new Range<int>(1,3);
        ExperienceToAward = CalculateEXPAwarded();
    }

    private int CalculateMaxHP()
    {
        return (Level * 2 + 5);
    }

    private double CalculateEXPAwarded()
    {
        double levelAdjusted = Level * 10;
        return (levelAdjusted - 8);
    }
}
