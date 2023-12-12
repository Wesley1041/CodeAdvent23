namespace Puzzle11;

public static class Parser
{
    public static bool[,] ParseSpace()
    {
        // Parse input
        var lines = ParseLines();
        var width = lines.First().Length;
        var height = lines.Count;
        var grid = new bool[width, height];
        var emptyRows = new bool[height];
        var populatedColumns = new bool[width];
        var populatedColumnsCount = 0;

        for (var y = 0; y < height; y++)
        {
            if (!lines[y].Contains('#')) emptyRows[y] = true;
            
            for (var x = 0; x < width; x++)
                if (lines[y][x] == '#')
                {
                    grid[x, y] = true;
                    if (!populatedColumns[x]) populatedColumnsCount++;
                    populatedColumns[x] = true;
                }
        }

        // Enlarge empty rows/columns
        var output = new List<string>();
        
        for (var y = 0; y < height; y++)
        {
            if (emptyRows[y])
                output.Add(new string('.', width * 2 - populatedColumnsCount));

            var newLine = "";
            for (var x = 0; x < width; x++)
            {
                if (!populatedColumns[x])
                    newLine += '.';

                newLine += grid[x, y] ? '#' : '.';
            }
            
            output.Add(newLine);
        }

        return ParseGrid(output);
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