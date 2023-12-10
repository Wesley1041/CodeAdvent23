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
