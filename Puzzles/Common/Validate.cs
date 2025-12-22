using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace AdventOfCode2025.Puzzles.Common;

internal static class Validate
{
    public static void IsTrue([DoesNotReturnIf(false)] bool value, string? message = null)
    {
        if (value is not true)
        {
            Fail(message);
        }
    }

    public static void IsNotNull<T>([NotNull] T? value, string? message = null)
    {
        if (value is null)
        {
            Fail(message);
        }
    }

    public static void IsMatch(string value, [StringSyntax(StringSyntaxAttribute.Regex)] string pattern, string? message = null)
    {
        if (!Regex.IsMatch(value, pattern))
        {
            Fail(message);
        }
    }

    [DoesNotReturn]
    public static void Fail(string? message = null)
    {
        throw new InvalidInputException(message);
    }
}
