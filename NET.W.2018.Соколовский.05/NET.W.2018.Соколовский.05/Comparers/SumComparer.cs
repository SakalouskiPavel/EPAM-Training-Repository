using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NET.W._2018.Соколовский._05.Comparers
{
    public class SumComparer : IComparer<int[]>
    {
        private bool _ascending;

        public SumComparer(bool ascending = false)
        {
            this._ascending = ascending;
        }

        public int Compare(int[] lhs, int[] rhs)
        {
            if (lhs.Sum() > rhs.Sum())
            {
                return this._ascending ? -1 : 1;
            }

            return this._ascending ? 1 : -1;
        }
    }
}