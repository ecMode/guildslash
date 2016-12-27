﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class Character
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

        public int CurrentHP
        {
            get { return currentHP; }
            set { currentHP = value; }
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

        public Character()
        {
            level = 10;
            CurrentHP = calculateHP();
            currentMP = maxMP;
            strength = 20;
            intelligence = 20;
            dexterity = 20;
            stamina = 20;
            DamagePotential = new Range<int>(1, 5);
        }

        private int calculateClassHPModifier()
        {
            if (characterClass == Classes.Mage)
                return 2;
            return 0;
        }

        private int calculateHP()
        {
            int staminaMod = stamina * 10;
            int levelMod = level * calculateClassHPModifier();
            return stamina + levelMod;
        }
    }
}