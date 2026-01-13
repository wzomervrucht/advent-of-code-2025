using AdventOfCode2025.Puzzles.Day03;

var assembly = typeof(Lobby).Assembly.Location;
var path = Path.Combine(assembly, "..", "Input", "input03.txt");
var input = await File.ReadAllLinesAsync(path);

Console.WriteLine($"Day {Lobby.Day}: {Lobby.Title}");
Console.Write("Part One: ");
Console.WriteLine(Lobby.Solve1(input));
Console.Write("Part Two: ");
Console.WriteLine(Lobby.Solve2(input));
