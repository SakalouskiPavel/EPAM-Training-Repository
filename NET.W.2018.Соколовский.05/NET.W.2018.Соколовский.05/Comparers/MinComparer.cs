using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NET.W._2018.Соколовский._05.Comparers
{
    public class MinComparer : IComparer<int[]>
    {
        private bool _ascending;

        public MinComparer(bool ascending = false)
        {
            this._ascending = ascending;
        }

        public int Compare(int[] lhs, int[] rhs)
        {
            if (lhs.Min() > rhs.Min())
            {
                return this._ascending ? -1 : 1;
            }

            return this._ascending ? 1 : -1;
        }
    }
}
