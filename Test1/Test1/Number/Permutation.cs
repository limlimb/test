using System;
using System.Collections.Generic;
using System.Linq;

namespace Test1.Number
{
    /// <summary>順列
    /// </summary>
    public static class Permutation
    {
        public static IEnumerable<IEnumerable<T>> Permutations<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException("配列がnullです。");
            return GetPermutations(source.ToArray());
        }

        private static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> source)
        {
            var c = source.Count();
            if (c == 1)
                yield return source;
            else
                for (int i = 0; i < c; i++)
                    foreach (var p in GetPermutations(source.Take(i).Concat(source.Skip(i + 1))))
                        yield return source.Skip(i).Take(1).Concat(p);
        }
        
        public static IEnumerable<string> Permutations(this string str)
        {
            return str.ToCharArray().Permutations<char>().Select(x => new string(x.ToArray()));
        }
    }
}
