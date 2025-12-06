namespace AdventOfCode2025.Puzzles;

public readonly record struct Answer(string Value)
{
    public override string ToString() => Value;

    public static implicit operator Answer(string value) => new(value);
    public static implicit operator Answer(int value) => new(value.ToString());
    public static implicit operator Answer(long value) => new(value.ToString());
}
