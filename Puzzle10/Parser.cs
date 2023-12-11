namespace Puzzle10
{
    public static class Parser
    {
        public static ParseResult ParseGrid()
        {
            var lines = ReadLines();
            var width = lines.First().Length;
            var height = lines.Count;

            var grid = new Tile[width, height];
            var start = new Position(0, 0);

            for (var y = 0; y < height; y++)
            {
                var line = lines[y];
                for (var x = 0; x < width; x++)
                {
                    if (line[x] == 'S') start = new Position(x, y);
                    grid[x, y] = (Tile)line[x];
                }
            }

            return new ParseResult(grid, start);
        }

        public static Tile[,] ParseGridWithBorders(Tile[,] firstGrid)
        {
            var width = firstGrid.GetLength(0) * 2 - 1;
            var height = firstGrid.GetLength(1) * 2 - 1;

            var grid = new Tile[width, height];

            for (var y = 0; y < height; y++)
                for (var x = 0; x < width; x++)
                {
                    if (x % 2 == 0 && y % 2 == 0)
                    {
                        grid[x, y] = firstGrid[x / 2, y / 2];
                    }
                    else
                    {
                        grid[x, y] = Tile.Border;
                    }
                }

            return grid;
        }

        private static List<string> ReadLines()
        {
            var lines = new List<string>();

            while (true)
            {
                var line = Console.ReadLine();

                if (string.IsNullOrEmpty(line)) return lines;

                lines.Add(line);
            }
        }
    }

    public class ParseResult
    {
        public Tile[,] Grid { get; }
        public Position Start { get; }

        public ParseResult(Tile[,] grid, Position start) 
        {
            Grid = grid;
            Start = start;
        }
    }

    public struct Position
    {
        public int X;
        public int Y;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Position Add(Position other)
        {
            return new Position(X + other.X, Y + other.Y);
        }
    }
}
