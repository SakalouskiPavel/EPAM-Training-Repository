using System;
using System.Collections.Generic;

namespace Test6.Solution
{
    public class EnumerableGenerator<T>
    {
        public IEnumerable<T> GetEnumerable(T firstMember, T secondMember, int count, Func<T, T, T> formula)
        {
            yield return firstMember;
            yield return secondMember;
            var currentMember = secondMember;
            var prevMember = firstMember;

            for (int i = 0; i < count - 2; i++)
            {
                var result = formula.Invoke(currentMember, prevMember);
                prevMember = currentMember;
                currentMember = result;
                yield return currentMember;
            }
        }
    }
}