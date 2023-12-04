namespace Puzzle04
{
    public class Card
    {
        public int Id { get; set; }
        public Dictionary<int, bool> WinningNumbers { get; set; }
        public List<int> MatchingNumbers { get; set; }

        public Card(int id, string input)
        {
            var sections = input.Split(" | ");

            Id = id;
            WinningNumbers = ListWinningNumbers(sections[0]);
            MatchingNumbers = ListMatchingNumbers(sections[1]);
        }

        // Part 1
        public int GetScore()
        {
            var count = MatchingNumbers.Count;

            if (count == 0) return 0;

            return (int)Math.Pow(2, count - 1);
        }

        // Part 2
        public int GetScore2()
        {
            return MatchingNumbers.Count;
        }

        private Dictionary<int, bool> ListWinningNumbers(string input)
        {
            Dictionary<int, bool> list = new Dictionary<int, bool>();

            var numbers = Helper.SmartSplit(input, ' ');
            foreach (var numberString in numbers)
            {
                list.Add(int.Parse(numberString), false);
            }

            return list;
        }

        private List<int> ListMatchingNumbers(string input)
        {
            List<int> list = new List<int>();

            var numbers = Helper.SmartSplit(input, ' ');
            foreach (var numberString in numbers)
            {
                var number = int.Parse(numberString);
                if (WinningNumbers.ContainsKey(number))
                {
                    list.Add(number);
                }
            }

            return list;
        }
    }
}
