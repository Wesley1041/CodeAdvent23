namespace Puzzle03
{
    public struct Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class GridNumber
    {
        public int Value { get; set; }
        public Position Position { get; set; }

        public GridNumber(int value, Position position)
        {
            Value = value;
            Position = position;
        }

        public List<GridValue> GetSurroundingStars(Grid grid)
        {
            List<GridValue> stars = new List<GridValue>();

            for (int x = Position.X - 1; x <= GetEndPositionX() + 1; x++)
                for (int y = Position.Y - 1; y <= Position.Y + 1; y++)
                {
                    if (!grid.CheckIfInBounds(x, y)) continue;

                    var gridValue = grid.GridValues[x, y];
                    if (!IsInNumber(x, y) && gridValue.Symbol == '*')
                    {
                        stars.Add(gridValue);
                    }
                }

            return stars;
        }

        private int GetEndPositionX()
        {
            return Position.X + Value.ToString().Length - 1;
        }

        private bool IsInNumber(int x, int y)
        {
            return y == Position.Y && x >= Position.X && x <= GetEndPositionX();
        }
    }
}
