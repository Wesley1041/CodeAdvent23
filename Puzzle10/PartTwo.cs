namespace Puzzle10
{
    public class PartTwo
    {
        private PartOne _partOne;
        private Tile[,] _grid;
        private bool[,] _loop;
        private Tile[,] _gridWithBorders;

        public PartTwo()
        {
            _partOne = new PartOne();
            _grid = _partOne.Grid;
            _loop = _partOne.Loop;
            _gridWithBorders = Parser.ParseGridWithBorders(_grid);

            Execute();
        }

        public void Execute()
        {
            var width = _gridWithBorders.GetLength(0);
            var height = _gridWithBorders.GetLength(1);
            var largeGrid = new bool[width, height];

            for (var y = 0; y < _gridWithBorders.GetLength(1); y++)
                for (var x = 0; x < _gridWithBorders.GetLength(0); x++)
                {
                    largeGrid[x, y] = !AccessiblePoint(x, y);
                }

            // Start finding all outer sections from the edges
            for (int x = 0; x < width; x++)
            {
                InfectGrid(largeGrid, x, 0);
                InfectGrid(largeGrid, x, height - 1);
            }

            for (int y = 0; y < height; y++)
            {
                InfectGrid(largeGrid, 0, y);
                InfectGrid(largeGrid, width - 1, y);
            }

            Console.WriteLine();

            var count = 0;
            for (var y = 0; y < height; y += 2)
            {
                var output = "";
                
                for (var x = 0; x < width; x += 2)
                {
                    output += largeGrid[x, y] ? 'X' : '-';
                    count += largeGrid[x, y] ? 0 : 1;
                }
                Console.WriteLine(output);
            }
            Console.WriteLine();
            Console.WriteLine(count);
        }

        private bool AccessiblePoint(int x, int y)
        {
            var tile = _gridWithBorders[x, y];

            if (tile == Tile.Ground) return true;
            
            if (tile != Tile.Border)
            {
                return !_loop[x / 2, y / 2];
            }

            // Is border
            // If neighbours are left and right
            if (y % 2 == 0)
            {
                return
                    _grid[x / 2, y / 2] == Tile.Ground ||
                    _grid[x / 2 + 1, y / 2] == Tile.Ground ||
                    !_partOne.CanUsePipe(new Position(x / 2, y / 2), new Position(x / 2 + 1, y / 2)) &&
                    !_partOne.CanUsePipe(new Position(x / 2 + 1, y / 2), new Position(x / 2, y / 2));
            }
            else if (x % 2 == 0)
            {
                return
                    _grid[x / 2, y / 2] == Tile.Ground ||
                    _grid[x / 2, y / 2 + 1] == Tile.Ground ||
                    !_partOne.CanUsePipe(new Position(x / 2, y / 2), new Position(x / 2, y / 2 + 1)) &&
                    !_partOne.CanUsePipe(new Position(x / 2, y / 2 + 1), new Position(x / 2, y / 2));
            }

            return true;
        }

        private void InfectGrid(bool[,] grid, int x, int y)
        {
            if (grid[x, y]) return;

            for (var dx = -1; dx <= 1; dx++)
                for (var dy = -1; dy <= 1; dy++)
                {
                    var nx = x + dx;
                    var ny = y + dy;

                    // Check if in range
                    if (dx == 0 && dy == 0) continue;
                    if (nx < 0 || ny < 0 || nx >= grid.GetLength(0) || ny >= grid.GetLength(1)) continue;

                    grid[x, y] = true;
                    InfectGrid(grid, nx, ny);
                }
        }
    }
}
