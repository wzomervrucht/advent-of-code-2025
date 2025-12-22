using AdventOfCode2025.Puzzles.Common;

namespace AdventOfCode2025.Puzzles.Day01;

public static class SecretEntrance
{
    public const int Day = 1;
    public const string Title = "Secret Entrance";

    public static Answer Solve1(IReadOnlyList<string> input)
    {
        var dial = new PasswordDial(100, 50);
        input.Select(Rotation.Parse).ForEach(dial.Rotate);
        return dial.Password;
    }

    public static Answer Solve2(IReadOnlyList<string> input)
    {
        var dial = new PasswordDial0x434C49434B(100, 50);
        input.Select(Rotation.Parse).ForEach(dial.Rotate);
        return dial.Password;
    }

    private enum Direction
    {
        Left,
        Right,
    }

    private readonly record struct Rotation(Direction Direction, int Distance)
    {
        public int Value => Direction == Direction.Right ? Distance : -Distance;

        public static Rotation Parse(string line)
        {
            Validate.IsMatch(line, @"^[LR]\d+$");
            var direction = line[0] == 'L' ? Direction.Left : Direction.Right;
            var distance = int.Parse(line[1..]);
            return new Rotation(direction, distance);
        }
    }

    private class PasswordDial(int size, int position)
    {
        public int Size { get; } = size;
        public int Position { get; protected set; } = position;
        public int Password { get; protected set; } = 0;

        public virtual void Rotate(Rotation rotation)
        {
            Position += rotation.Value;

            if (Position % Size == 0)
            {
                Password++;
            }
        }
    }

    private class PasswordDial0x434C49434B(int size, int position) : PasswordDial(size, position)
    {
        public override void Rotate(Rotation rotation)
        {
            if (rotation.Direction == Direction.Right)
            {
                Position = ((Position % Size) + Size) % Size;
                Position += rotation.Distance;
                Password += Position / Size;
            }
            else
            {
                Position = ((Position % Size) - Size) % Size;
                Position -= rotation.Distance;
                Password -= Position / Size;
            }
        }
    }
}
