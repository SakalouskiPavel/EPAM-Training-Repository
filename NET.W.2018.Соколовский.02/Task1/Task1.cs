using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Properties;

namespace Task1
{
    public class Task1
    {
        public static int InsertNumber(int numberSource, int numberIn, int i, int j)
        {
            if ((i < 0 || i > 31) || (j < 0 || j > 31))
            {
                throw new ArgumentOutOfRangeException(Resources.WrongBorders);
            }

            if (i > j)
            {
                i = i + j;
                j = i - j;
                i = i - j;
            }

            int insertableNumber = numberIn << i;
            int mask = int.MaxValue >> (30 - j); 
            return (insertableNumber & mask) | numberSource;
        }
    }
}
