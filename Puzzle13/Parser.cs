using Helpers;

namespace Puzzle13;

public static class Parser
{
    public static List<bool[,]> ParseInput()
    {
        var grids = new List<bool[,]>();
        while (true)
        {
            var grid = ParseGrid();

            if (grid == null) return grids;

            grids.Add(grid);
        }
    }

    private static bool[,]? ParseGrid()
    {
        var lines = BaseParser.ParseLines();
        if (lines.Count == 0) return null;

        var grid = new bool[lines.First().Length, lines.Count];

        for (var y = 0; y < lines.Count; y++)
            for (var x = 0; x < lines[y].Length; x++)
                grid[x, y] = lines[y][x] == '#';

        return grid;
    }
}
