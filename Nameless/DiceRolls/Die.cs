using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.DiceRolls
{
    public class Die
    {
        private int sides = 6;

        public Die(int sides)
        {
            Sides = sides;
        }

        public int Sides
        {
            get { return sides; }
            set { sides = value; }
        }
    }
}
