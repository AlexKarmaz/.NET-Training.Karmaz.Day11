using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Tests
{
    public static class Comparator
    {
        public static readonly Comparison<int> comparatorForInt32 = delegate (int x, int y)
        {
            return x.CompareTo(y);
        };

        public static readonly Comparison<string> comparatorForString = delegate (string x, string y)
        {
            return x.CompareTo(y);
        };
    }
}
