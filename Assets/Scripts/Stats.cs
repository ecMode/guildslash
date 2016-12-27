using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public static class Stats
    {
        public const int HP = 0;
        public const int MP = 1;
        public const int Strength = 2; // Increase Physical Damage
        public const int Dexterity = 3; // Increase Crit chance - logarythmic
        public const int Intelligence = 4; // Increases MP - Constant, Increases Magic Damage
        public const int Vitality = 5; // Increases HP - Constant
        public const int Evasion = 6;
        public const int Defense = 7;
        public const int Accurancy = 8;
        public const int MagicFind = 9;

    }
}
