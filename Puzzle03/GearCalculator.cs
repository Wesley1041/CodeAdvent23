namespace Puzzle03
{
    public class GearCalculator
    {
        private Grid _grid;

        public GearCalculator(Grid grid)
        {
            _grid = grid;
        }

        public int GetGearRatioSum()
        {
            var sum = 0;

            var gears = GetGears();
            foreach (var gear in gears)
            {
                var items = gear.Value;

                if (items.Count != 2)
                {
                    throw new InvalidOperationException("A gear was supplied that does not have 2 numbers");
                }

                sum += items[0].Value * items[1].Value;
            }

            return sum;
        }

        private Dictionary<GridValue, List<GridNumber>> GetGears()
        {
            var dictionary = new Dictionary<GridValue, List<GridNumber>>();

            var gridNumbers = CollectNumbers();
            foreach (var number in gridNumbers)
            {
                var stars = number.GetSurroundingStars(_grid);
                foreach (var star in stars)
                {
                    if (!dictionary.ContainsKey(star))
                    {
                        dictionary.Add(star, new List<GridNumber>());
                    }

                    dictionary[star].Add(number);
                }
            }

            // Filter on stars that border exactly 2 numbers
            var invalidItems = dictionary.Where(item => item.Value.Count != 2);
            foreach (var item in invalidItems)
            {
                dictionary.Remove(item.Key);
            }

            return dictionary;
        }

        private List<GridNumber> CollectNumbers()
        {
            var gridNumbers = new List<GridNumber>();

            for (int y = 0; y < _grid.Height; y++)
            {
                var rowNumbers = CollectNumbersFromRow(y);
                gridNumbers = gridNumbers.Concat(rowNumbers).ToList();
            }

            return gridNumbers;
        }

        private List<GridNumber> CollectNumbersFromRow(int rowIndex)
        {
            List<GridNumber> gridNumbers = new List<GridNumber>();

            var newNumber = "";

            for (int x = 0; x < _grid.Width; x++)
            {
                var value = _grid.GridValues[x, rowIndex];

                switch (value.Type)
                {
                    // Read digit and check if it is surrounded by a symbol
                    case ValueType.Digit:
                        newNumber += value.Symbol;

                        if (x == _grid.Width - 1)
                        {
                            var numberStartPositionX = x - newNumber.Length + 1;
                            gridNumbers.Add(new GridNumber(
                                int.Parse(newNumber),
                                new Position(numberStartPositionX, rowIndex)));
                        }
                        break;
                    // Read something else and parse the last few digits if there are any
                    default:
                        if (newNumber != "")
                        {
                            var numberStartPositionX = x - newNumber.Length;
                            gridNumbers.Add(new GridNumber(
                                int.Parse(newNumber),
                                new Position(numberStartPositionX, rowIndex)));
                        }

                        newNumber = "";
                        break;
                }
            }

            return gridNumbers;
        }
    }
}
