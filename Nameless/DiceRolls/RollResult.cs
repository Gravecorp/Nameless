using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.DiceRolls
{
    public class RollResult
    {
        private Die sidedDie;
        private int result;

        public RollResult(Die sidedDie, int result)
        {
            SidedDie = sidedDie;
            Result = result;
        }

        public Die SidedDie
        {
            get { return sidedDie; }
            set { sidedDie = value; }
        }

        public int Result
        {
            get { return result; }
            set { result = value; }
        }
    }
}
