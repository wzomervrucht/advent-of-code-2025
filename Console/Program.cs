using AdventOfCode2025.Puzzles.Day01;

var assembly = typeof(Puzzle01).Assembly.Location;
var path = Path.Combine(assembly, "..", "Input", "input01.txt");
var input = await File.ReadAllLinesAsync(path);

Console.WriteLine($"Day {Puzzle01.Day}: {Puzzle01.Title}");
Console.Write("Part One: ");
Console.WriteLine(Puzzle01.Solve1(input));
Console.Write("Part Two: ");
Console.WriteLine(Puzzle01.Solve2(input));
