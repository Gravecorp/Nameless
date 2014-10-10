using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.DiceRolls
{
    public class DiceRoller
    {
        private RNGSubClass random = null;

        public DiceRoller()
        {
            random = new RNGSubClass();
        }

        public int SingleRollAsInt(Die die)
        {
            int ret = 0;

            ret = random.Next(1, die.Sides);

            return (ret);
        }

        public RollResult SingleRollAsResult(Die die)
        {
            int result = SingleRollAsInt(die);
            RollResult ret = new RollResult(die, result);
            return (ret);
        }

        public RollResultSet RollList(List<Die> diceList)
        {
            RollResultSet ret = new RollResultSet();

            foreach (Die die in diceList)
            {
                RollResult result = SingleRollAsResult(die);
                ret.ResultList.Add(result);
            }

            return (ret);
        }


        private class RNGSubClass
        {
            RNGCryptoServiceProvider rnd;
            Byte[] randomBytes = new Byte[4];
            public RNGSubClass()
            {
                rnd = new RNGCryptoServiceProvider();
            }
            public UInt32 Next()
            {
                rnd.GetBytes(randomBytes);
                return BitConverter.ToUInt32(randomBytes, 0);
            }
            public int Next(int maxValue)
            {
                return this.Next(0, maxValue);
            }
            public Int32 Next(Int32 minValue, Int32 maxValue)
            {
                if (minValue > maxValue)
                    throw new ArgumentOutOfRangeException("minValue");
                if (minValue == maxValue) return minValue;
                Int64 diff = maxValue - minValue;
                while (true)
                {
                    rnd.GetBytes(randomBytes);
                    UInt32 rand = BitConverter.ToUInt32(randomBytes, 0);

                    Int64 max = (1 + (Int64)UInt32.MaxValue);
                    Int64 remainder = max % diff;
                    if (rand < max - remainder)
                    {
                        return (Int32)(minValue + (rand % diff));
                    }
                }
            }
        }
    }
}
