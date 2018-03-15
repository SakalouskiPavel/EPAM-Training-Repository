using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Task1
    {
        public static int InsertNumber(int numberSource, int numberIn, int from, int to)
        {
            int insertableNumber = numberIn << from;
            insertableNumber = (int)Math.Sqrt(numberIn) > to - 1 ? numberIn >> (int)Math.Sqrt(numberIn) - to : insertableNumber;
            return  insertableNumber | numberSource;
        }
    }
}
