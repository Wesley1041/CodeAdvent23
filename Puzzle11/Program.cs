using Helpers;
using Puzzle11;

var grid = Parser.ParseSpace();

var galaxies = new List<Galaxy>();

for (var x = 0; x < grid.GetLength(0); x++)
    for (var y = 0; y < grid.GetLength(1); y++)
        if (grid[x, y])
        {
            galaxies.Add(new Galaxy(new Position(x, y)));
        }

var distance = 0;
var pairs = 0;

Console.WriteLine($"Galaxies: {galaxies.Count}");

foreach (var galaxy in galaxies)
{
    foreach (var other in galaxies)
    {
        if (other == galaxy) continue;
        distance += galaxy.GetDistance(other);
        pairs++;
    }
}

Console.WriteLine($"Pairs: {pairs / 2}");
Console.WriteLine($"Distance: {distance / 2}");