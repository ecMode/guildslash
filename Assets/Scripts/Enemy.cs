using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class Enemy
    {
        private int currentHP;
        private int maxHP;
        private int currentMP;
        private int strength;
        private int intelligence;
        private int dexterity;
        private int stamina;
        public int MaxHP { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Dexterity { get; set; }
        public int Stamina { get; set; }
        public int CurrentHP { get; set; }
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
            MaxHP = 10;
            Strength = 10;
            Intelligence = 10;
            Dexterity = 10;
            Stamina = 10;
            DamagePotential = new Range<int>(1,3);
            CurrentHP = 10;
            ExperienceToAward = random.Next(100, 500);
        }

        public string toString()
        {
            return "HP: " + MaxHP;
        }
    }
}
