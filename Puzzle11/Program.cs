using Helpers;
using Puzzle11;

var parseResult = Parser.ParseSpace();
var grid = parseResult.Grid;
var emptyRows = parseResult.EmptyRows;
var emptyColumns = parseResult.EmptyColumns;
var emptySpaceMultiplier = 1000000;

var galaxies = new List<Galaxy>();

for (var x = 0; x < grid.GetLength(0); x++)
    for (var y = 0; y < grid.GetLength(1); y++)
        if (grid[x, y])
        {
            galaxies.Add(new Galaxy(new Position(x, y)));
        }

long distance = 0;
var pairs = 0;

Console.WriteLine($"Galaxies: {galaxies.Count}");

foreach (var galaxy in galaxies)
{
    foreach (var other in galaxies)
    {
        if (other == galaxy) continue;
        distance += GetDistance(galaxy, other);
        pairs++;
    }
}

Console.WriteLine($"Pairs: {pairs / 2}");
Console.WriteLine($"Distance: {distance / 2}");

// Functions
long GetDistance(Galaxy galaxy1, Galaxy galaxy2)
{
    var distance = galaxy1.GetDistance(galaxy2);
    var emptyColumnsCount = Math.Abs(emptyColumns[galaxy2.Position.X] - emptyColumns[galaxy1.Position.X]);
    var emptyRowsCount = Math.Abs(emptyRows[galaxy2.Position.Y] - emptyRows[galaxy1.Position.Y]);
    distance += (emptyColumnsCount + emptyRowsCount) * (emptySpaceMultiplier - 1);
    
    return distance;
}