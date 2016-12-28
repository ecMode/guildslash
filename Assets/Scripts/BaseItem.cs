using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class BaseItem
    {
        private string modifier;
        public enum Modifiers
        {
            NORMAL,
            MAGICAL,
            MYSTICAL,
            RARE,
            MYTHICAL,
            ARTIFACT
        }
    }

}
