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
        private int attributes;
        private Weapon equippedWeapon;
        private string name;
        private Range<int> damagePotential;
        private double currentExperience;
        private double maxExperience;
        private double gold;
        private int healthRegenerationRate;
        private int manaRegenerationRate;
        private float criticalStrikeChance;
        private float modifiedCriticalStrikeChance;

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
        public Range<int> DamagePotential
        {
            get
            {
                Range<int> strengthPotential = new Range<int>(0, Math.Floor(Convert.ToDouble(strength / 5)));
                return strengthPotential.addRange(EquippedWeapon.Damage);
            }
        }
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
        public double MaxExperience
        {
            get
            {
                return maxExperience;
            }
            set
            {
                maxExperience = value;
            }
        }
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
        public int Attributes
        {
            get { return attributes; }
            set { attributes = value; }
        }
        public float CriticalStrikeChance
        {
            get { return CalculateCriticalStrikeChance(); }
        }
        public float ModifiedCriticalStrikeChance
        {
            get { return modifiedCriticalStrikeChance; }
            set
            {
                modifiedCriticalStrikeChance = value;
            }
        }

        public Player()
        {
            level = 1;
            strength = 10;
            intelligence = 10;
            dexterity = 10;
            stamina = 10;
            attributes = 10;
            modifiedCriticalStrikeChance = .05F;
            maxHP = currentHP = CalculateMaxHP();
            maxMP = currentMP = CalculateMaxMP();
            currentExperience = 0;
            maxExperience = CalculateMaxExperience();
            equippedWeapon = new Weapon();
            name = "FuckYou";
            healthRegenerationRate = CalculateHealthRegenerationRate();
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
            attributes++;
        }

        private double CalculateMaxExperience()
        {
            return Math.Pow(level, 2) / .05;
        }

        private int CalculateHealthRegenerationRate()
        {
            return 1;
        }

        private int CalculateManaRegenerationRate()
        {
            return 1;
        }

        private float CalculateCriticalStrikeChance()
        {
            return modifiedCriticalStrikeChance * dexterity;
        }
    }
}
