using AdventOfCode2025.Puzzles.Day01;

var assembly = typeof(SecretEntrance).Assembly.Location;
var path = Path.Combine(assembly, "..", "Input", "input01.txt");
var input = await File.ReadAllLinesAsync(path);

Console.WriteLine($"Day {SecretEntrance.Day}: {SecretEntrance.Title}");
Console.Write("Part One: ");
Console.WriteLine(SecretEntrance.Solve1(input));
Console.Write("Part Two: ");
Console.WriteLine(SecretEntrance.Solve2(input));
