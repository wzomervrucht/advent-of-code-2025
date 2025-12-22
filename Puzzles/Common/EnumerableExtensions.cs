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
    }
}
