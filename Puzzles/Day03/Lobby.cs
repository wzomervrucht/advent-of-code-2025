using AdventOfCode2025.Puzzles.Common;

namespace AdventOfCode2025.Puzzles.Day03;

public static class Lobby
{
    public const int Day = 3;
    public const string Title = "Lobby";

    public static Answer Solve1(IReadOnlyList<string> input)
    {
        var banks = input.Select(BatteryBank.Parse);
        return banks.Sum(bank => bank.GetMaximalJoltage(2));
    }

    public static Answer Solve2(IReadOnlyList<string> input)
    {
        var banks = input.Select(BatteryBank.Parse);
        return banks.Sum(bank => bank.GetMaximalJoltage(12));
    }

    private class BatteryBank(IEnumerable<int> batteries)
    {
        public IReadOnlyList<int> Batteries { get; } = [..batteries];

        public static BatteryBank Parse(string batteries)
        {
            Validate.IsMatch(batteries, @"^[1-9]*$");
            return new BatteryBank(batteries.Select(c => c - '0'));
        }

        public long GetMaximalJoltage(int digits)
        {
            Validate.IsTrue(Batteries.Count >= digits);

            var joltage = 0L;
            var start = 0;

            while (digits-- > 0)
            {
                var index = Enumerable.RangeUntil(start, Batteries.Count - digits).MaxBy(i => Batteries[i]);
                joltage = 10 * joltage + Batteries[index];
                start = index + 1;
            }

            return joltage;
        }
    }
}
