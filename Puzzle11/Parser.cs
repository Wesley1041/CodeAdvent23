namespace Puzzle11;

public static class Parser
{
    public static ParseResult ParseSpace()
    {
        // Parse input
        var lines = ParseLines();
        var width = lines.First().Length;
        var height = lines.Count;
        var grid = new bool[width, height];
        var emptyRows = new bool[height];
        var populatedColumns = new bool[width];

        for (var y = 0; y < height; y++)
        {
            if (!lines[y].Contains('#')) emptyRows[y] = true;
            
            for (var x = 0; x < width; x++)
                if (lines[y][x] == '#')
                {
                    grid[x, y] = true;
                    populatedColumns[x] = true;
                }
        }

        // Find empty rows and columns
        var emptyColumnsInt = new int[width];
        var emptyColumnsCount = 0;
        for (var x = 0; x < width; x++)
        {
            if (!populatedColumns[x]) emptyColumnsCount++;
            emptyColumnsInt[x] = emptyColumnsCount;
        }
        
        var emptyRowsInt = new int[width];
        var emptyRowsCount = 0;
        for (var y = 0; y < height; y++)
        {
            if (emptyRows[y]) emptyRowsCount++;
            emptyRowsInt[y] = emptyRowsCount;
        }

        return new ParseResult(emptyColumnsInt, emptyRowsInt, grid);
    }

    private static List<string> ParseLines()
    {
        var list = new List<string>();
        
        while (true)
        {
            var line = Console.ReadLine();

            if (string.IsNullOrEmpty(line)) return list;
            
            list.Add(line);
        }
    }

    private static bool[,] ParseGrid(List<string> lines)
    {
        var width = lines[0].Length;
        var height = lines.Count;
        var grid = new bool[width, height];

        for (var x = 0; x < width; x++)
            for (var y = 0; y < height; y++)
                grid[x, y] = lines[y][x] == '#';

        return grid;
    }

    private static void PrintGrid(List<string> lines)
    {
        foreach (var line in lines)
            Console.WriteLine(line);
    }
}