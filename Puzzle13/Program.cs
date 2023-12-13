using Puzzle13;

var grids = Parser.ParseInput();
var sum = 0;
var i = 0;

foreach (var grid in grids)
{
    i++;
    Console.WriteLine($"Check grid {i}");
    sum += FindMirror(grid);
}
    

Console.WriteLine($"Sum: {sum}");

// Functions
int FindMirror(bool[,] grid)
{
    // Check for horizontal mirror
    for (int y = 1; y < grid.GetLength(1); y++)
        if (CheckHorizontalMirror(grid, y))
            return y * 100;

    // Check for vertical mirror
    for (int x = 1; x < grid.GetLength(0); x++)
        if (CheckVerticalMirror(grid, x))
            return x;

    return 0;
}

bool CheckVerticalMirror(bool[,] grid, int rows)
{
    var width = grid.GetLength(0);
    var height = grid.GetLength(1);

    var x1 = rows - 1;
    var x2 = rows;

    while (x1 >= 0 && x2 < width)
    {
        for (int y = 0; y < height; y++)
        {
            if (grid[x1, y] != grid[x2, y]) return false;
        }
        x1--;
        x2++;
    }

    return true;
}

bool CheckHorizontalMirror(bool[,] grid, int rows)
{
    var width = grid.GetLength(0);
    var height = grid.GetLength(1);

    var y1 = rows - 1;
    var y2 = rows;

    while (y1 >= 0 && y2 < height)
    {
        for (int x = 0; x < width; x++)
        {
            if (grid[x, y1] != grid[x, y2]) return false;
        }
        y1--;
        y2++;
    }

    return true;
}