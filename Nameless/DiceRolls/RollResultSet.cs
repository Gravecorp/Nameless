using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.DiceRolls
{
    public class RollResultSet
    {
        private List<RollResult> resultList = null;

        public RollResultSet()
        {
           
        }

        public RollResultSet(List<RollResult> list)
        {
            resultList = list;
        }

        public List<RollResult> ResultList
        {
            get 
            {
                if (resultList == null)
                {
                    resultList = new List<RollResult>();
                }
                return resultList; 
            }
            set 
            {
                if (resultList.Count > 0 && value != null)
                {
                    resultList.AddRange(value);
                }
                else
                {
                    resultList = value;
                }
            }
        }

        public int GetTotal()
        {
            int ret = 0;
            if (ResultList.Count > 0)
            {
                ResultList.ForEach(x => { ret += x.Result; });
            }
            return (ret);
        }
    }
}
