namespace Puzzle09
{
    public static class Parser
    {
        public static List<Sequence> ParseSequences()
        {
            var list = new List<Sequence>();

            while (true)
            {
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input)) return list;

                list.Add(ParseSequence(input));
            }
        }

        private static Sequence ParseSequence(string input)
        {
            var numbersString = input.Split(' ');
            var numbers = numbersString.Select(int.Parse).ToList();

            return new Sequence(numbers);
        }
    }
}
