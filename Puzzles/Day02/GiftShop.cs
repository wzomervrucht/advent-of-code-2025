using AdventOfCode2025.Puzzles.Common;

namespace AdventOfCode2025.Puzzles.Day02;

public static class GiftShop
{
    public const int Day = 2;
    public const string Title = "Gift Shop";

    public static Answer Solve1(IReadOnlyList<string> input)
    {
        var ranges = input.Join().Split(',').Select(IdRange.Parse);
        var ids = ranges.SelectMany(range => range.GetInvalidIds());
        return ids.Sum();
    }

    public static Answer Solve2(IReadOnlyList<string> input)
    {
        var ranges = input.Join().Split(',').Select(IdRange.Parse);
        var ids = ranges.SelectMany(range => range.GetAllInvalidIds());
        return ids.Sum();
    }

    private readonly record struct IdRange(long FirstId, long LastId)
    {
        public static IdRange Parse(string range)
        {
            Validate.IsMatch(range, @"^\d+-\d+$");
            var dash = range.IndexOf('-');
            var first = range[..dash];
            var last = range[(dash + 1)..];
            return new IdRange(long.Parse(first), long.Parse(last));
        }

        public IEnumerable<long> GetInvalidIds() => GetIdsWithRepeats(2);

        public IEnumerable<long> GetAllInvalidIds()
        {
            var length = LastId.ToString().Length;
            return Enumerable.Range(2, length - 1).SelectMany(GetIdsWithRepeats).Distinct();
        }

        private IEnumerable<long> GetIdsWithRepeats(int repeats)
        {
            var value = GetFirstRepeatedValue(repeats);
            var id = Repeated(value, repeats);

            while (id <= LastId)
            {
                yield return id;
                id = Repeated(++value, repeats);
            }
        }

        private long GetFirstRepeatedValue(int repeats)
        {
            var first = FirstId.ToString();
            var length = first.Length / repeats;

            if (length * repeats < first.Length)
            {
                return long.Pow(10, length);
            }

            var value = long.Parse(first[..length]);
            var id = Repeated(value, repeats);
            return id >= FirstId ? value : value + 1;
        }

        private static long Repeated(long value, int repeats)
        {
            return long.Parse(Enumerable.Repeat(value, repeats).Join());
        }
    }
}
