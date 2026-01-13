namespace AdventOfCode2025.Puzzles.Common;

internal static class EnumerableExtensions
{
    extension<T>(IEnumerable<T> items)
    {
        public void ForEach(Action<T> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }

        public string Join(string? separator = null) => string.Join(separator, items);
    }

    extension(Enumerable)
    {
        public static IEnumerable<int> RangeUntil(int start, int end) => Enumerable.Range(start, end - start);
    }
}
