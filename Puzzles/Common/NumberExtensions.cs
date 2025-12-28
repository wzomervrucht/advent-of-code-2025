using System.Numerics;

namespace AdventOfCode2025.Puzzles.Common;

internal static class NumberExtensions
{
    extension<T>(IEnumerable<T> numbers) where T : INumber<T>
    {
        public T Product() => numbers.Aggregate(T.MultiplicativeIdentity, (x, y) => x * y);
    }

    extension<T>(T) where T : INumber<T>
    {
        public static T Pow(T x, int n) => Enumerable.Repeat(x, n).Product();
    }
}
