namespace AdventOfCode2025.Puzzles;

public class InvalidInputException(string? message = null) : Exception(Format(message))
{
    private static string Format(string? message)
    {
        return string.IsNullOrEmpty(message) ? "Invalid input." : $"Invalid input: {message}";
    }
}
