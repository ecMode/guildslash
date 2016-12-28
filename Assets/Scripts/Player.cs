using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class Player
    {
        private Classes characterClass;
        private Guid characterId;
        private int level;
        private int currentHP;
        private int maxHP;
        private int currentMP;
        private int maxMP;
        private int strength;
        private int intelligence;
        private int dexterity;
        private int stamina;
        private Weapon equippedWeapon;
        private string name;

        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int CurrentMP
        {
            get { return currentMP; }
            set { currentMP = value; }
        }
        public int MaxMP
        {
            get { return maxMP; }
            set { maxMP = value; }
        }
        public int CurrentHP
        {
            get { return currentHP; }
            set
            {
                currentHP = value;
            }
        }
        public int MaxHP
        {
            get { return maxHP; }
            set { maxHP = value; }
        }
        private Range<int> damagePotential;
        public Range<int> DamagePotential
        {
            get
            {
                Range<int> strengthPotential = new Range<int>(0, Math.Floor(Convert.ToDouble(strength / 5)));
                return strengthPotential.addRange(EquippedWeapon.Damage);
            }
        }
        private double currentExperience;
        public double CurrentExperience
        {
            get
            {
                return currentExperience;
            }
            set
            {
                if (value < 0)
                {
                    currentExperience = 0;
                }
                else
                {
                    currentExperience = value;
                }
            }
        }
        public double MaxExperience { get; set; }
        public int Intelligence
        {
            get
            {
                return intelligence;
            }
            set
            {
                intelligence = value;
            }
        }
        public int Strength
        {
            get
            {
                return strength;
            }
            set
            {
                strength = value;
            }
        }
        public int Stamina
        {
            get
            {
                return stamina;
            }
            set
            {
                stamina = value;
            }
        }
        public int Dexterity
        {
            get
            {
                return dexterity;
            }
            set
            {
                dexterity = value;
            }
        }

        public Weapon EquippedWeapon
        {
            get
            {
                return equippedWeapon;
            }
            set
            {
                equippedWeapon = value;
            }
        }

        public Player()
        {
            level = 1;
            Strength = 10;
            Intelligence = 10;
            Dexterity = 10;
            Stamina = 10;
            MaxHP = CurrentHP = CalculateMaxHP();
            MaxMP = CurrentMP = CalculateMaxMP();
            CurrentExperience = 0;
            MaxExperience = CalculateMaxExperience();
            EquippedWeapon = new Weapon();
            Name = "FuckYou";
        }

        private int CalculateClassHPModifier()
        {
            switch (characterClass)
            {
                case Classes.MAGE:
                    return 0;
                case Classes.WARRIOR:
                    return 2;
                case Classes.ROGUE:
                    return 1;
                default:
                    return 0;
            }
        }

        private int CalculateMaxHP()
        {
            int staminaMod = Stamina * 10;
            int levelMod = level * CalculateClassHPModifier();
            return Stamina + levelMod;
        }

        private int CalculateClassMPModifier()
        {
            switch(characterClass)
            {
                case Classes.MAGE:
                    return 2;
                case Classes.WARRIOR:
                    return 0;
                case Classes.ROGUE:
                    return 1;
                default:
                    return 0;
            }
        }

        private int CalculateMaxMP()
        {
            int intelligenceMod = Intelligence * 10;
            int levelMod = level * CalculateClassMPModifier();
            return Intelligence + levelMod;
        }

        public void LevelUp()
        {
            level++;
            MaxHP = CurrentHP = CalculateMaxHP();
            MaxMP = CurrentMP = CalculateMaxMP();
            MaxExperience = CalculateMaxExperience();
            Intelligence += 1;
            Dexterity += 1;
            Strength += 1;
            Stamina += 1;
        }

        private double CalculateMaxExperience()
        {
            return Math.Pow(level,2) / .05;
        }
    }
}
