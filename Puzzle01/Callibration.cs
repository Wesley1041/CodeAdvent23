namespace Puzzle01
{
    class ParseResult
    {
        public int? Digit { get; set; }
        public string RemainingInput { get; set; }

        public ParseResult(int? digit, string remainingInput)
        {
            Digit = digit;
            RemainingInput = remainingInput;
        }
    }

    class QueryResult
    {
        public int? Digit { get; set; }
        public bool SubstringValid { get; set; }

        public QueryResult(int? digit, bool substringValid)
        {
            Digit = digit;
            SubstringValid = substringValid;
        }
    }

    public class Callibration
    {
        private readonly Dictionary<string, int> _digits = new Dictionary<string, int>()
        {
            { "one",   1 },
            { "two",   2 },
            { "three", 3 },
            { "four",  4 },
            { "five",  5 },
            { "six",   6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine",  9 },
        };

        private string _input;

        public Callibration(string input)
        {
            _input = input;
        }

        public int GetValue()
        {
            var input = _input;

            var firstResult = GetFirstDigit(input);
            var secondResult = GetLastDigit(string.Concat(firstResult.RemainingInput.Reverse()));

            var value = int.Parse($"{firstResult.Digit}{secondResult.Digit ?? firstResult.Digit}");

            return value;
        }

        private ParseResult GetFirstDigit(string input)
        {
            var parsedCharacters = 0;
            int? result = null;

            for (int i = 1; i <= input.Length; i++)
            {
                var subString = input.Substring(0, i);
                var digit = QueryDigits(subString, input);
                if (digit.Digit != null)
                {
                    result = digit.Digit;
                    parsedCharacters = i;
                    break;
                }
                else if (!digit.SubstringValid)
                {
                    parsedCharacters = 1;
                    break;
                }
            }

            input = input.Substring(parsedCharacters);

            if (result == null && input.Length > 0)
            {
                return GetFirstDigit(input);
            }

            return new ParseResult(result, input);
        }

        private ParseResult GetLastDigit(string input)
        {
            var parsedCharacters = 0;
            int? result = null;

            for (int i = 1; i <= input.Length; i++)
            {
                var subString = input.Substring(0, i);
                var digit = QueryDigits(subString, input, true);
                if (digit.Digit != null)
                {
                    result = digit.Digit;
                    parsedCharacters = i;
                    break;
                }
                else if (!digit.SubstringValid)
                {
                    parsedCharacters = 1;
                    break;
                }
            }

            input = input.Substring(parsedCharacters);

            if (result == null && input.Length > 0)
            {
                return GetLastDigit(input);
            }

            return new ParseResult(result, input);
        }

        private QueryResult QueryDigits(string query, string fullString, bool backwards = false)
        {
            if (char.IsDigit(query.First()))
            {
                return new QueryResult(
                    int.Parse(query.Substring(0, 1)),
                    true);
            }

            var substringValid = _digits.Where(d => SubstringIsValid(query, d.Key, backwards) && fullString.Length >= d.Key.Length).Count() > 0;

            query = backwards ? string.Concat(query.Reverse()) : query;

            return new QueryResult(
                _digits.ContainsKey(query) ? _digits[query] : null,
                substringValid);
        }

        private bool SubstringIsValid(string substring, string key, bool backwards = false)
        {
            if (substring.Length > key.Length)
            {
                return false;
            }

            key = backwards ? string.Concat(key.Reverse()) : key;

            return key.Substring(0, substring.Length) == substring;
        }
    }
}
