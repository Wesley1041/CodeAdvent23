namespace Puzzle10
{
    public class PartOne
    {
        public Tile[,] Grid;
        public bool[,] Loop;

        public PartOne()
        {
            var parseResult = Arrange();
            Grid = parseResult.Grid;
            Loop = new bool[Grid.GetLength(0), Grid.GetLength(1)];

            GetPipeLoop(parseResult.Start);
        }

        ParseResult Arrange()
        {
            return Parser.ParseGrid();
        }

        bool IsInRange(int x, int y)
        {
            return x >= 0 && y >= 0 && x < Grid.GetLength(0) && y < Grid.GetLength(1);
        }

        Position GetFirstPipe(Position start)
        {
            for (var dx = -1; dx <= 1; dx++)
                for (var dy = -1; dy <= 1; dy++)
                {
                    var x = start.X + dx;
                    var y = start.Y + dy;

                    if (dy == dx || dy == -dx || !IsInRange(x, y)) continue;

                    if (CanUsePipe(new Position(x, y), start))
                    {
                        return new Position(x, y);
                    }
                }

            throw new Exception("No pipe found");
        }

        public bool CanUsePipe(Position pipePosition, Position currentPosition)
        {
            var tile = Grid[pipePosition.X, pipePosition.Y];
            var dx = pipePosition.X - currentPosition.X;
            var dy = pipePosition.Y - currentPosition.Y;

            switch (tile)
            {
                case Tile.Horizontal:
                    return dx != 0;
                case Tile.Vertical:
                    return dy != 0;
                case Tile.NorthEast:
                    return dy == 1 || dx == -1;
                case Tile.NorthWest:
                    return dy == 1 || dx == 1;
                case Tile.SouthEast:
                    return dy == -1 || dx == -1;
                case Tile.SouthWest:
                    return dy == -1 || dx == 1;
                default:
                    return false;
            }
        }

        Position? UsePipe(Position position, Position pipePosition)
        {
            //Console.WriteLine($"Go from ({position.X}, {position.Y}) to ({pipePosition.X}, {pipePosition.Y})");

            var tile = Grid[pipePosition.X, pipePosition.Y];
            var dx = pipePosition.X - position.X;
            var dy = pipePosition.Y - position.Y;

            switch (tile)
            {
                case Tile.Horizontal:
                    return pipePosition.Add(new Position(dx, 0));
                case Tile.Vertical:
                    return pipePosition.Add(new Position(0, dy));
                case Tile.NorthEast:
                    return pipePosition.Add(dy > 0 ? new Position(1, 0) : new Position(0, -1));
                case Tile.NorthWest:
                    return pipePosition.Add(dy > 0 ? new Position(-1, 0) : new Position(0, -1));
                case Tile.SouthEast:
                    return pipePosition.Add(dy < 0 ? new Position(1, 0) : new Position(0, 1));
                case Tile.SouthWest:
                    return pipePosition.Add(dy < 0 ? new Position(-1, 0) : new Position(0, 1));
                case Tile.Ground:
                    throw new Exception("Reached ground");
                default:
                    return null;
            }
        }

        void GetPipeLoop(Position start)
        {
            var currentPosition = start;
            var count = 0;

            // Get first pipe
            var pipePosition = GetFirstPipe(start);

            // Loop through pipes
            while (true)
            {
                Loop[currentPosition.X, currentPosition.Y] = true;
                var newPipePosition = UsePipe(currentPosition, pipePosition);
                count++;

                if (newPipePosition == null) break;

                currentPosition = pipePosition;
                pipePosition = (Position)newPipePosition;
            }

            // Print loop
            for (var y = 0; y < Loop.GetLength(1); y++)
            {
                var output = "";
                for (var x = 0; x < Loop.GetLength(0); x++)
                {
                    output += Loop[x, y] ? "X" : "-";
                }
                Console.WriteLine(output);
            }
        }
    }
}
