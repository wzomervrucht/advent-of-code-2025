using AdventOfCode2025.Puzzles.Day02;

var assembly = typeof(GiftShop).Assembly.Location;
var path = Path.Combine(assembly, "..", "Input", "input02.txt");
var input = await File.ReadAllLinesAsync(path);

Console.WriteLine($"Day {GiftShop.Day}: {GiftShop.Title}");
Console.Write("Part One: ");
Console.WriteLine(GiftShop.Solve1(input));
Console.Write("Part Two: ");
Console.WriteLine(GiftShop.Solve2(input));
