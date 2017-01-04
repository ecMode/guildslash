using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Player : BaseEntity
    {
        private Classes characterClass;
        private Guid characterId;
        private int currentMP;
        private int maxMP;
        private int attributes;
        private BaseWeapon equippedWeapon;
        private double currentExperience;
        private double maxExperience;
        private double gold;
        private int healthRegenerationRate;
        private int manaRegenerationRate;
        private float criticalStrikeChance;
        private float modifiedCriticalStrikeChance;

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
            Level = 1;
            Strength = 10;
            Intelligence = 10;
            Dexterity = 10;
            Stamina = 10;
            Attributes = 10;
            ModifiedCriticalStrikeChance = .05F;
            MaxHP = CurrentHP = CalculateMaxHP();
            maxMP = currentMP = CalculateMaxMP();
            currentExperience = 0;
            maxExperience = CalculateMaxExperience();
            Name = "Negative";
            healthRegenerationRate = CalculateHealthRegenerationRate();
            EquippedWeapon = new Axe(Level);
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
            int staminaMod = Stamina * 5;
            int levelMod = Level * CalculateClassHPModifier();
			return staminaMod + levelMod;
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
            int intelligenceMod = Intelligence * 5;
            int levelMod = Level * CalculateClassMPModifier();
            return intelligenceMod + levelMod;
        }

        public void LevelUp()
        {
            Level++;
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
            return Math.Pow(Level, 2) / .05;
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
            return modifiedCriticalStrikeChance * Dexterity;
        }
    }
