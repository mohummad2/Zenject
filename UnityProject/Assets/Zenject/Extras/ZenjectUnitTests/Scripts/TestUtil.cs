using System;
using System.Collections.Generic;
using System.Linq;

namespace ModestTree.Tests
{
    public static class TestUtil
    {
        public static bool ContainSameElements<T>(
            IEnumerable<T> listA, IEnumerable<T> listB)
        {
            return ContainSameElementsInternal(listA.ToList(), listB.ToList());
        }

        static bool ContainSameElementsInternal<T>(
            List<T> listA, List<T> listB)
        {
            // We don't care how they are sorted as long as they are sorted the same way so just use hashcode
            Comparison<T> comparer = (T left, T right) => (left.GetHashCode().CompareTo(right.GetHashCode()));

            listA.Sort(comparer);
            listB.Sort(comparer);

            return Enumerable.SequenceEqual(listA, listB);
        }

        public static string PrintList<T>(List<T> list)
        {
            return list.Select(x => x.ToString()).ToArray().Join(",");
        }
    }
}
