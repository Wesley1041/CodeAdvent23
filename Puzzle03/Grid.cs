namespace Puzzle03
{
    public class Grid
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public GridValue[,] GridValues { get; set; }

        public Grid(List<string> rowsInput)
        {
            if (rowsInput.Count == 0)
            {
                throw new ArgumentException("Provided input list is empty");
            }

            // Get Width and Length
            Width = rowsInput[0].Length;
            Height = rowsInput.Count;
            GridValues = new GridValue[Width, Height];

            ParseInput(rowsInput);
        }

        // Part 1
        public int GetSum()
        {
            var sum = 0;

            for (int i = 0; i < Height; i++)
            {
                sum += GetRowSum(i);
            }

            return sum;
        }

        public bool CheckIfInBounds(int x, int y)
        {
            return !(x < 0 || x >= Width || y < 0 || y >= Height);
        }

        private int GetRowSum(int rowIndex)
        {
            var sum = 0;
            var newNumber = "";
            var numberValid = false;

            for (int x = 0; x < Width; x++)
            {
                var value = GridValues[x, rowIndex];
                
                switch (value.Type)
                {
                    // Read digit and check if it is surrounded by a symbol
                    case ValueType.Digit: 
                        newNumber += value.Symbol;

                        if (CheckForSymbols(x, rowIndex))
                        {
                            numberValid = true;
                        }
                        
                        break;
                    // Read something else and parse the last few digits if there are any
                    default:
                        if (newNumber != "" && numberValid)
                        {
                            sum += int.Parse(newNumber);
                        }

                        newNumber = "";
                        numberValid = false;
                        break;
                }
            }

            // Handle digit as last character
            if (newNumber != "" && numberValid)
            {
                sum += int.Parse(newNumber);
            }

            return sum;
        }

        private bool CheckForSymbols(int x, int y)
        {
            for (int xi = x - 1; xi <= x + 1; xi++)
                for (int yi = y - 1; yi <= y + 1; yi++)
                {
                    if (!CheckIfInBounds(xi, yi)) continue;

                    if (GridValues[xi, yi].Type == ValueType.Symbol)
                    {
                        return true;
                    }
                }

            return false;
        }

        private void ParseInput(List<string> rowsInput)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    var input = rowsInput[y][x];
                    GridValues[x, y] = new GridValue(input);
                }
            }
        }
    }
}
