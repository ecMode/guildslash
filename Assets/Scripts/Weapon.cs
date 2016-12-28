using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class Weapon : BaseItem
    {
        private Range<int> damage;
        public Range<int> Damage
        {
            get
            {
                return damage;
            }
            set
            {
                damage = value;
            }
        }

        public Weapon()
        {
            Damage = new Range<int>(3, 20);
        }

        public enum WeaponTypes
        {
            AXE,
            SWORD,
            STAFF,
            DAGGER,
            MACE
        }
    }
}
