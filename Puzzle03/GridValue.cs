namespace Puzzle03
{
    public enum ValueType
    {
        Empty = 0,
        Digit = 1,
        Symbol = 2,
    }

    public class GridValue
    {
        public ValueType Type { get; set; }
        public int? Digit { get; set; }
        public char Symbol { get; set; }

        public GridValue(char symbol)
        {
            Symbol = symbol;

            if (char.IsDigit(symbol))
            {
                Type = ValueType.Digit;
                Digit = symbol;
            }
            else if (symbol == '.')
            {
                Type = ValueType.Empty;
            }
            else
            {
                Type = ValueType.Symbol;
            }
        }
    }
}
